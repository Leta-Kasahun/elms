using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Common;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class LeaveRequestDialog : Form
    {
        private class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        public LeaveRequestDialog()
        {
            InitializeComponent();
            PopulateControls();
        }

        private void PopulateControls()
        {
            dtpStartDate.Value = DateTime.Today.AddDays(1);
            dtpEndDate.Value = DateTime.Today.AddDays(5);

            foreach (var emp in DataStore.Instance.Employees.Where(e => e.IsActive))
            {
                cboEmployee.Items.Add(new ComboBoxItem
                {
                    Text = $"{emp.FullName} ({emp.EmployeeCode}) - {emp.DepartmentName}",
                    Value = emp.Id
                });
            }

            bool isAdmin = AuthService.Instance.HasRole(SystemRole.Admin) || AuthService.Instance.HasRole(SystemRole.HR_Manager);
            if (!isAdmin && AuthService.Instance.CurrentEmployee != null)
            {
                for (int i = 0; i < cboEmployee.Items.Count; i++)
                {
                    var itm = cboEmployee.Items[i] as ComboBoxItem;
                    if (itm != null && AuthService.Instance.CurrentEmployee != null && itm.Value == AuthService.Instance.CurrentEmployee.Id)
                    {
                        cboEmployee.SelectedIndex = i;
                        break;
                    }
                }
                cboEmployee.Enabled = false;
            }
            else if (cboEmployee.Items.Count > 0)
            {
                cboEmployee.SelectedIndex = 0;
            }

            foreach (var lt in DataStore.Instance.LeaveTypes.Where(l => l.IsActive))
            {
                string extra = lt.RequiresClearance ? " [Requires Clearance]" : "";
                cboLeaveType.Items.Add(new ComboBoxItem
                {
                    Text = $"{lt.Name} ({lt.EntitlementDays}d/yr){extra}",
                    Value = lt.Id
                });
            }
            if (cboLeaveType.Items.Count > 0) cboLeaveType.SelectedIndex = 0;

            UpdateLiveBalance();
        }

        private void UpdateLiveBalance()
        {
            int days = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;
            if (days <= 0)
            {
                lblLiveInfo.Text = "Invalid Date Range: End date must be on or after start date.";
                lblLiveInfo.ForeColor = ElmsTheme.Danger;
                return;
            }

            int empId = (cboEmployee.SelectedItem as ComboBoxItem)?.Value ?? 0;
            int typeId = (cboLeaveType.SelectedItem as ComboBoxItem)?.Value ?? 0;
            var ent = LeaveService.Instance.GetEntitlement(empId, typeId, DateTime.Now.Year);
            int bal = ent?.BalanceDays ?? 0;

            lblLiveInfo.Text = $"Requested: {days} day(s) | Available Balance: {bal} day(s)";
            lblLiveInfo.ForeColor = days > bal ? ElmsTheme.Danger : ElmsTheme.Success;
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e) => UpdateLiveBalance();
        private void cboLeaveType_SelectedIndexChanged(object sender, EventArgs e) => UpdateLiveBalance();
        private void dtpDates_ValueChanged(object sender, EventArgs e) => UpdateLiveBalance();

        private void btnDraft_Click(object sender, EventArgs e)
        {
            int empId = (cboEmployee.SelectedItem as ComboBoxItem)?.Value ?? 0;
            int typeId = (cboLeaveType.SelectedItem as ComboBoxItem)?.Value ?? 0;

            var res = LeaveService.Instance.CreateDraftRequest(empId, typeId, dtpStartDate.Value.Date, dtpEndDate.Value.Date, txtReason.Text);
            if (res.Success)
            {
                MessageBox.Show(res.Message, "Draft Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int empId = (cboEmployee.SelectedItem as ComboBoxItem)?.Value ?? 0;
            int typeId = (cboLeaveType.SelectedItem as ComboBoxItem)?.Value ?? 0;

            var draftRes = LeaveService.Instance.CreateDraftRequest(empId, typeId, dtpStartDate.Value.Date, dtpEndDate.Value.Date, txtReason.Text);
            if (!draftRes.Success || draftRes.Request == null)
            {
                MessageBox.Show(draftRes.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subRes = LeaveService.Instance.SubmitLeaveRequest(draftRes.Request.Id);
            if (subRes.Success)
            {
                MessageBox.Show(subRes.Message, "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(subRes.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
