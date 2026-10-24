using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class LeaveTypeDialog : Form
    {
        private readonly LeaveType? _editingType;

        public LeaveTypeDialog(LeaveType? typeToEdit = null)
        {
            _editingType = typeToEdit;
            InitializeComponent();

            if (_editingType != null)
            {
                lblTitle.Text = "Edit Leave Type Policy";
                txtCode.Text = _editingType.Code;
                txtName.Text = _editingType.Name;
                nudDays.Value = Math.Max(nudDays.Minimum, Math.Min(nudDays.Maximum, _editingType.EntitlementDays));
                nudMonths.Value = Math.Max(nudMonths.Minimum, Math.Min(nudMonths.Maximum, _editingType.MinimumServiceMonths));
                chkClearance.Checked = _editingType.RequiresClearance;
                chkCertificate.Checked = _editingType.RequiresCertificate;
                chkCarryForward.Checked = _editingType.IsCarryForwardAllowed;
            }
            else
            {
                lblTitle.Text = "Create Leave Type Policy";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpperInvariant();
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Leave type code is required (e.g. ANNUAL, MATERNITY).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Leave type title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingType == null)
            {
                int newId = DataStore.Instance.LeaveTypes.Any() ? DataStore.Instance.LeaveTypes.Max(l => l.Id) + 1 : 1;
                var newType = new LeaveType
                {
                    Id = newId,
                    Code = code,
                    Name = name,
                    EntitlementDays = (int)nudDays.Value,
                    MinimumServiceMonths = (int)nudMonths.Value,
                    RequiresClearance = chkClearance.Checked,
                    RequiresCertificate = chkCertificate.Checked,
                    IsCarryForwardAllowed = chkCarryForward.Checked,
                    IsActive = true
                };
                DataStore.Instance.LeaveTypes.Add(newType);

                // Provision default entitlements for existing employees
                int currentYear = DateTime.Now.Year;
                int nextEntId = DataStore.Instance.Entitlements.Any() ? DataStore.Instance.Entitlements.Max(ent => ent.Id) + 1 : 1;
                foreach (var emp in DataStore.Instance.Employees)
                {
                    DataStore.Instance.Entitlements.Add(new LeaveEntitlement
                    {
                        Id = nextEntId++,
                        EmployeeId = emp.Id,
                        LeaveTypeId = newType.Id,
                        FiscalYear = currentYear,
                        BaseDays = newType.EntitlementDays,
                        CarriedOverDays = 0,
                        TenureBonusDays = 0,
                        UsedDays = 0
                    });
                }
            }
            else
            {
                _editingType.Code = code;
                _editingType.Name = name;
                _editingType.EntitlementDays = (int)nudDays.Value;
                _editingType.MinimumServiceMonths = (int)nudMonths.Value;
                _editingType.RequiresClearance = chkClearance.Checked;
                _editingType.RequiresCertificate = chkCertificate.Checked;
                _editingType.IsCarryForwardAllowed = chkCarryForward.Checked;
            }

            DataStore.Instance.NotifyChanged();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);
            }
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
            }
        }
    }
}