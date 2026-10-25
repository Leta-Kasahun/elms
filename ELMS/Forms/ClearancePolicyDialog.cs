using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class ClearancePolicyDialog : Form
    {
        private readonly ClearancePolicy? _policyToEdit;

        public ClearancePolicyDialog(ClearancePolicy? policy = null)
        {
            _policyToEdit = policy;
            InitializeComponent();
            PopulateRequestTypes();

            if (_policyToEdit != null)
            {
                lblTitle.Text = "Edit Clearance Policy";
                txtCode.Text = _policyToEdit.Code;
                txtCode.Enabled = false;
                txtName.Text = _policyToEdit.Name;
                cboRequestType.SelectedItem = _policyToEdit.RequestType;
                txtDescription.Text = _policyToEdit.Description;
                txtUnits.Text = string.Join(", ", _policyToEdit.RequiredUnits);
                chkSequential.Checked = _policyToEdit.IsSequential;
                chkGenerateLetter.Checked = _policyToEdit.GenerateClearanceLetter;
                chkActive.Checked = _policyToEdit.IsActive;
            }
            else
            {
                txtCode.Text = $"CLR-{DateTime.Now.Year}-{DataStore.Instance.ClearancePolicies.Count + 1:D2}";
                txtUnits.Text = "University Library, Department Hardware & Lab Access, Finance Office, HR Compliance";
            }
        }

        private void PopulateRequestTypes()
        {
            cboRequestType.Items.Clear();
            cboRequestType.Items.AddRange(new object[]
            {
                "Study & Sabbatical Leave",
                "Employment Termination",
                "Inter-Department Transfer",
                "Long-Term Medical Sabbatical"
            });
            cboRequestType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpperInvariant();
            string name = txtName.Text.Trim();
            string reqType = cboRequestType.SelectedItem?.ToString() ?? "Study & Sabbatical Leave";
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Policy Code and Policy Name are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var units = txtUnits.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(u => u.Trim())
                                     .Where(u => !string.IsNullOrEmpty(u))
                                     .ToList();

            if (!units.Any())
            {
                MessageBox.Show("Please specify at least one required handover unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_policyToEdit == null)
            {
                var newPolicy = new ClearancePolicy
                {
                    Id = DataStore.Instance.ClearancePolicies.Count + 1,
                    Code = code,
                    Name = name,
                    RequestType = reqType,
                    Description = desc,
                    IsSequential = chkSequential.Checked,
                    GenerateClearanceLetter = chkGenerateLetter.Checked,
                    IsActive = chkActive.Checked,
                    RequiredUnits = units
                };
                DataStore.Instance.ClearancePolicies.Add(newPolicy);
            }
            else
            {
                _policyToEdit.Name = name;
                _policyToEdit.RequestType = reqType;
                _policyToEdit.Description = desc;
                _policyToEdit.IsSequential = chkSequential.Checked;
                _policyToEdit.GenerateClearanceLetter = chkGenerateLetter.Checked;
                _policyToEdit.IsActive = chkActive.Checked;
                _policyToEdit.RequiredUnits = units;
            }

            DataStore.Instance.NotifyChanged();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
