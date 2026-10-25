using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Common;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class LeaveClearanceDialog : Form
    {
        private readonly LeaveRequest _request;

        public LeaveClearanceDialog(LeaveRequest request)
        {
            _request = request;
            InitializeComponent();
            ElmsTheme.ApplyGridStyle(dgvClearance);
            SetupColumns();
            LoadData();
        }

        private void SetupColumns()
        {
            dgvClearance.Columns.Clear();
            dgvClearance.Columns.Add("Unit", "Handover Unit / Dept");
            dgvClearance.Columns.Add("Item", "Requirement / Asset Handover");
            dgvClearance.Columns.Add("Status", "Clearance Status");
            dgvClearance.Columns.Add("ClearedBy", "Cleared By");
            dgvClearance.Columns.Add("ClearedDate", "Sign-Off Date");

            if (dgvClearance.Columns["Unit"] != null) dgvClearance.Columns["Unit"]!.Width = 160;
            if (dgvClearance.Columns["Item"] != null) dgvClearance.Columns["Item"]!.Width = 240;
            if (dgvClearance.Columns["Status"] != null) dgvClearance.Columns["Status"]!.Width = 110;
            if (dgvClearance.Columns["ClearedBy"] != null) dgvClearance.Columns["ClearedBy"]!.Width = 120;
            if (dgvClearance.Columns["ClearedDate"] != null) dgvClearance.Columns["ClearedDate"]!.Width = 120;
        }

        private void LoadData()
        {
            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == _request.EmployeeId);
            var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == _request.LeaveTypeId);

            string empName = emp?.FullName ?? "Unknown";
            string empCode = emp?.EmployeeCode ?? "N/A";
            string dept = emp?.DepartmentName ?? "N/A";
            string typeName = lt?.Name ?? "Study & Sabbatical Leave";

            lblEmpInfo.Text = $"{empName} ({empCode})  |  {dept}";
            lblPeriodInfo.Text = $"Request # {_request.RequestNumber}  |  {typeName} ({_request.DurationDays} days)  |  {_request.StartDate:yyyy-MM-dd} to {_request.EndDate:yyyy-MM-dd}";

            int total = _request.ClearanceChecklist.Count;
            int cleared = _request.ClearanceChecklist.Count(c => c.Status == ClearanceStatus.CLEARED);

            lblProgressInfo.Text = $"Progress: {cleared} of {total} Cleared";

            if (_request.Status == RequestStatus.APPROVED)
            {
                lblStatusBadge.Text = "CLEARANCE COMPLETED";
                lblStatusBadge.BackColor = Color.FromArgb(220, 252, 231);
                lblStatusBadge.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblStatusBadge.Text = "CLEARANCE IN PROGRESS";
                lblStatusBadge.BackColor = Color.FromArgb(254, 243, 199);
                lblStatusBadge.ForeColor = Color.FromArgb(180, 83, 9);
            }

            dgvClearance.Rows.Clear();
            foreach (var item in _request.ClearanceChecklist)
            {
                string statusText = item.Status == ClearanceStatus.CLEARED ? "CLEARED" : "PENDING";
                string clearedBy = !string.IsNullOrEmpty(item.ClearedByName) ? item.ClearedByName : "—";
                string clearedDate = item.ClearedDate.HasValue ? item.ClearedDate.Value.ToString("yyyy-MM-dd HH:mm") : "—";

                int idx = dgvClearance.Rows.Add(item.DepartmentOrUnit, item.ItemName, statusText, clearedBy, clearedDate);
                dgvClearance.Rows[idx].Tag = item;
            }

            bool canAction = AuthService.Instance.HasAnyRole(
                SystemRole.Clearance_Officer,
                SystemRole.Admin,
                SystemRole.Department_Head,
                SystemRole.HR_Manager
            );

            bool isAllCleared = _request.ClearanceChecklist.All(c => c.Status == ClearanceStatus.CLEARED);

            btnSignOffItem.Visible = canAction && !isAllCleared;
            btnCompleteAll.Visible = canAction && !isAllCleared;
            lblRoleNotice.Visible = !canAction;
        }

        private void btnSignOffItem_Click(object sender, EventArgs e)
        {
            if (dgvClearance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a pending clearance item from the table to sign off.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = dgvClearance.SelectedRows[0].Tag as ClearanceItem;
            if (item == null) return;

            if (item.Status == ClearanceStatus.CLEARED)
            {
                MessageBox.Show($"'{item.ItemName}' is already signed off and cleared by {item.ClearedByName}.", "Already Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = LeaveService.Instance.ClearChecklistItem(_request.Id, item.Id);
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Clearance Item Signed Off", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCompleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to sign off and complete all remaining clearance items for {_request.RequestNumber}?", "Confirm Complete Clearance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            foreach (var item in _request.ClearanceChecklist.Where(c => c.Status != ClearanceStatus.CLEARED))
            {
                LeaveService.Instance.ClearChecklistItem(_request.Id, item.Id);
            }

            MessageBox.Show($"All study leave clearances completed for {_request.RequestNumber}. Request status updated to APPROVED.", "Clearances Finalized", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void dgvClearance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            if (dgvClearance.Columns[e.ColumnIndex].Name == "Status")
            {
                string val = e.Value.ToString() ?? "";
                if (val == "CLEARED")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                    e.CellStyle.Font = new Font(dgvClearance.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);
                    e.CellStyle.Font = new Font(dgvClearance.Font, FontStyle.Bold);
                }
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }

        private void pnlSummary_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlSummary.Height - 1, pnlSummary.Width, pnlSummary.Height - 1);
            }
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlBottom.Width, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
