using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class ApprovalWorkflowDialog : Form
    {
        private readonly ApprovalWorkflowDefinition? _workflowToEdit;

        public ApprovalWorkflowDialog(ApprovalWorkflowDefinition? workflow = null)
        {
            _workflowToEdit = workflow;
            InitializeComponent();
            PopulateCombos();

            if (_workflowToEdit != null)
            {
                lblTitle.Text = "Edit Approval Workflow";
                txtName.Text = _workflowToEdit.Name;
                cboRequestType.SelectedItem = _workflowToEdit.RequestType;
                txtDescription.Text = _workflowToEdit.Description;
                chkSequential.Checked = _workflowToEdit.IsSequential;
                chkActive.Checked = _workflowToEdit.IsActive;

                var s1 = _workflowToEdit.Steps.FirstOrDefault(s => s.StepOrder == 1);
                var s2 = _workflowToEdit.Steps.FirstOrDefault(s => s.StepOrder == 2);
                var s3 = _workflowToEdit.Steps.FirstOrDefault(s => s.StepOrder == 3);

                if (s1 != null) cboStep1Role.SelectedItem = s1.ApproverRole.ToString();
                if (s2 != null) cboStep2Role.SelectedItem = s2.ApproverRole.ToString();
                else cboStep2Role.SelectedIndex = 0;
                if (s3 != null) cboStep3Role.SelectedItem = s3.ApproverRole.ToString();
                else cboStep3Role.SelectedIndex = 0;
            }
            else
            {
                cboStep1Role.SelectedItem = SystemRole.Department_Head.ToString();
                cboStep2Role.SelectedItem = SystemRole.HR_Manager.ToString();
                cboStep3Role.SelectedIndex = 0; // (None)
            }
        }

        private void PopulateCombos()
        {
            cboRequestType.Items.Clear();
            cboRequestType.Items.AddRange(new object[]
            {
                "Annual / Medical Leave",
                "Study & Sabbatical Leave",
                "Executive Leave",
                "Inter-Department Transfer",
                "General Request Desk"
            });
            cboRequestType.SelectedIndex = 0;

            var rolesWithNone = new List<string> { "(None / Optional)" };
            foreach (var r in Enum.GetNames(typeof(SystemRole)))
            {
                rolesWithNone.Add(r);
            }

            cboStep1Role.Items.Clear();
            foreach (var r in Enum.GetNames(typeof(SystemRole))) cboStep1Role.Items.Add(r);
            cboStep1Role.SelectedIndex = 0;

            cboStep2Role.Items.Clear();
            foreach (var r in rolesWithNone) cboStep2Role.Items.Add(r);
            cboStep2Role.SelectedIndex = 0;

            cboStep3Role.Items.Clear();
            foreach (var r in rolesWithNone) cboStep3Role.Items.Add(r);
            cboStep3Role.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string reqType = cboRequestType.SelectedItem?.ToString() ?? "Leave Request";
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Workflow Name is a required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var steps = new List<ApprovalStepDefinition>();
            int order = 1;

            if (Enum.TryParse<SystemRole>(cboStep1Role.SelectedItem?.ToString(), out var r1))
            {
                steps.Add(new ApprovalStepDefinition { StepOrder = order++, StepName = $"{r1} Review", ApproverRole = r1, IsMandatory = true });
            }

            if (Enum.TryParse<SystemRole>(cboStep2Role.SelectedItem?.ToString(), out var r2))
            {
                steps.Add(new ApprovalStepDefinition { StepOrder = order++, StepName = $"{r2} Authorization", ApproverRole = r2, IsMandatory = true });
            }

            if (Enum.TryParse<SystemRole>(cboStep3Role.SelectedItem?.ToString(), out var r3))
            {
                steps.Add(new ApprovalStepDefinition { StepOrder = order++, StepName = $"{r3} Sign-off", ApproverRole = r3, IsMandatory = true });
            }

            if (!steps.Any())
            {
                MessageBox.Show("At least one active approver step is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_workflowToEdit == null)
            {
                var newWf = new ApprovalWorkflowDefinition
                {
                    Id = DataStore.Instance.ApprovalWorkflows.Count + 1,
                    Name = name,
                    RequestType = reqType,
                    Description = desc,
                    IsSequential = chkSequential.Checked,
                    IsActive = chkActive.Checked,
                    Steps = steps
                };
                DataStore.Instance.ApprovalWorkflows.Add(newWf);
            }
            else
            {
                _workflowToEdit.Name = name;
                _workflowToEdit.RequestType = reqType;
                _workflowToEdit.Description = desc;
                _workflowToEdit.IsSequential = chkSequential.Checked;
                _workflowToEdit.IsActive = chkActive.Checked;
                _workflowToEdit.Steps = steps;
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
