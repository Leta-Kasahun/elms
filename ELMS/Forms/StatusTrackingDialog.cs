using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Common;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class StatusTrackingDialog : Form
    {
        private readonly LeaveRequest _request;

        public StatusTrackingDialog(LeaveRequest request)
        {
            _request = request;
            InitializeComponent();
            RefreshTrackingData();
        }

        private void RefreshTrackingData()
        {
            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == _request.EmployeeId);
            var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == _request.LeaveTypeId);
            var ent = LeaveService.Instance.GetEntitlement(_request.EmployeeId, _request.LeaveTypeId, _request.StartDate.Year);

            lblHeader.Text = $"{_request.RequestNumber} - {_request.Status}";
            lblSummary.Text =
                $"Employee: {emp?.FullName} ({emp?.EmployeeCode}) | Dept: {emp?.DepartmentName}\n" +
                $"Leave Type: {lt?.Name} | Days: {_request.DurationDays}\n" +
                $"Period: {_request.StartDate:yyyy-MM-dd} to {_request.EndDate:yyyy-MM-dd}\n" +
                $"Reason: {_request.Reason}";

            if (ent != null)
            {
                int balanceAfter = ent.BalanceDays - (_request.Status == RequestStatus.APPROVED ? 0 : _request.DurationDays);
                lblQuotaText.Text =
                    $"Allocated: {ent.TotalAllocatedDays}d   Carried: {ent.CarriedOverDays}d   Tenure Bonus: +{ent.TenureBonusDays}d\n" +
                    $"Taken: {ent.UsedDays}d   Available Balance: {ent.BalanceDays}d   Balance After Req: {balanceAfter}d";

                lblQuotaAlert.Visible = balanceAfter < 0 && _request.Status != RequestStatus.APPROVED;
            }

            var step1 = _request.ApprovalSteps.FirstOrDefault(s => s.StepOrder == 1);
            if (step1 != null)
            {
                string s1Audit = step1.Status == StepStatus.PENDING ? "Pending action..." :
                    $"By: {step1.ApproverName} ({step1.ActionDate:MM/dd HH:mm}) - {step1.Comments}";
                lblStep1.Text = $"Step 1: Department Head Review [{step1.Status}]\n{s1Audit}";
                lblStep1.ForeColor = step1.Status == StepStatus.APPROVED ? ElmsTheme.Success :
                    (step1.Status == StepStatus.REJECTED ? ElmsTheme.Danger : ElmsTheme.Warning);
            }

            var step2 = _request.ApprovalSteps.FirstOrDefault(s => s.StepOrder == 2);
            if (step2 != null)
            {
                string s2Audit = step2.Status == StepStatus.PENDING ?
                    (step1?.Status == StepStatus.APPROVED ? "Active Pending..." : "Gated (Awaiting Step 1)") :
                    $"By: {step2.ApproverName} ({step2.ActionDate:MM/dd HH:mm}) - {step2.Comments}";
                lblStep2.Text = $"Step 2: HR Director Authorization [{step2.Status}]\n{s2Audit}";
                lblStep2.ForeColor = step2.Status == StepStatus.APPROVED ? ElmsTheme.Success :
                    (step2.Status == StepStatus.REJECTED ? ElmsTheme.Danger : ElmsTheme.TextSecondary);
            }

            var activeStep = _request.ApprovalSteps.OrderBy(s => s.StepOrder).FirstOrDefault(s => s.Status == StepStatus.PENDING);
            bool canAct = false;
            if (activeStep != null && (_request.Status == RequestStatus.SUBMITTED || _request.Status == RequestStatus.UNDER_REVIEW))
            {
                bool previousApproved = _request.ApprovalSteps.Where(s => s.StepOrder < activeStep.StepOrder).All(s => s.Status == StepStatus.APPROVED);
                if (previousApproved)
                {
                    canAct = AuthService.Instance.HasRole(activeStep.RequiredRole) || AuthService.Instance.HasRole(SystemRole.Admin);
                    grpAction.Text = $"Reviewer Action for Step {activeStep.StepOrder} ({activeStep.RequiredRole})";
                }
            }

            grpAction.Enabled = canAct;
            btnApprove.Enabled = canAct;
            btnReject.Enabled = canAct;

            grpClearance.Visible = _request.RequiresClearance && _request.ClearanceChecklist.Any();
            pnlClearanceItems.Controls.Clear();
            if (grpClearance.Visible)
            {
                bool isClearanceOfficer = AuthService.Instance.HasRole(SystemRole.Clearance_Officer) ||
                                          AuthService.Instance.HasRole(SystemRole.Department_Head) ||
                                          AuthService.Instance.HasRole(SystemRole.Admin);

                foreach (var item in _request.ClearanceChecklist)
                {
                    var pnl = new Panel { Size = new Size(430, 36), BackColor = Color.FromArgb(248, 250, 252), Margin = new Padding(3) };
                    var lbl = new Label
                    {
                        Text = $"[{item.Status}] {item.ItemName} ({item.DepartmentOrUnit})",
                        Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                        ForeColor = item.Status == ClearanceStatus.CLEARED ? ElmsTheme.Success : ElmsTheme.Warning,
                        Location = new Point(6, 9),
                        AutoSize = true
                    };
                    pnl.Controls.Add(lbl);

                    if (item.Status != ClearanceStatus.CLEARED && isClearanceOfficer)
                    {
                        var btn = new Button
                        {
                            Text = "Clear",
                            Size = new Size(65, 26),
                            Location = new Point(355, 4),
                            BackColor = ElmsTheme.Success,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat
                        };
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Click += (s, e) =>
                        {
                            var res = LeaveService.Instance.ClearChecklistItem(_request.Id, item.Id);
                            MessageBox.Show(res.Message, "Clearance Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshTrackingData();
                        };
                        pnl.Controls.Add(btn);
                    }
                    pnlClearanceItems.Controls.Add(pnl);
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            var activeStep = _request.ApprovalSteps.OrderBy(s => s.StepOrder).FirstOrDefault(s => s.Status == StepStatus.PENDING);
            if (activeStep == null) return;

            var res = LeaveService.Instance.ProcessApprovalStep(_request.Id, activeStep.Id, true, txtReviewComments.Text.Trim());
            MessageBox.Show(res.Message, "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshTrackingData();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            var activeStep = _request.ApprovalSteps.OrderBy(s => s.StepOrder).FirstOrDefault(s => s.Status == StepStatus.PENDING);
            if (activeStep == null) return;

            var res = LeaveService.Instance.ProcessApprovalStep(_request.Id, activeStep.Id, false, txtReviewComments.Text.Trim());
            MessageBox.Show(res.Message, "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshTrackingData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
