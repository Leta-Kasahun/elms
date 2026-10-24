using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class DepartmentDialog : Form
    {
        private readonly Department? _editingDept;

        private class HeadItem
        {
            public int? EmployeeId { get; set; }
            public string Name { get; set; } = string.Empty;
            public override string ToString() => Name;
        }

        public DepartmentDialog(Department? deptToEdit = null)
        {
            _editingDept = deptToEdit;
            InitializeComponent();
            PopulateDepartmentHeads();

            if (_editingDept != null)
            {
                lblTitle.Text = "Edit Department";
                txtCode.Text = _editingDept.Code;
                txtName.Text = _editingDept.Name;

                for (int i = 0; i < cboHead.Items.Count; i++)
                {
                    if (cboHead.Items[i] is HeadItem hi && hi.EmployeeId == _editingDept.DepartmentHeadEmployeeId)
                    {
                        cboHead.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                lblTitle.Text = "Create Department";
                if (cboHead.Items.Count > 0) cboHead.SelectedIndex = 0;
            }
        }

        private void PopulateDepartmentHeads()
        {
            cboHead.Items.Clear();
            cboHead.Items.Add(new HeadItem { EmployeeId = null, Name = "(None / Unassigned)" });

            foreach (var emp in DataStore.Instance.Employees.Where(e => e.IsActive).OrderBy(e => e.FullName))
            {
                cboHead.Items.Add(new HeadItem
                {
                    EmployeeId = emp.Id,
                    Name = $"{emp.FullName} ({emp.JobTitle})"
                });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpperInvariant();
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Department code is required (e.g. HR, IT).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Department name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HeadItem? selectedHead = cboHead.SelectedItem as HeadItem;
            int? headId = selectedHead?.EmployeeId;
            string? headName = headId.HasValue ? DataStore.Instance.Employees.FirstOrDefault(e => e.Id == headId.Value)?.FullName : null;

            if (_editingDept == null)
            {
                int newId = DataStore.Instance.Departments.Any() ? DataStore.Instance.Departments.Max(d => d.Id) + 1 : 1;
                var newDept = new Department
                {
                    Id = newId,
                    Code = code,
                    Name = name,
                    DepartmentHeadEmployeeId = headId,
                    DepartmentHeadName = headName,
                    ActiveStaffCount = 0
                };
                DataStore.Instance.Departments.Add(newDept);
            }
            else
            {
                _editingDept.Code = code;
                _editingDept.Name = name;
                _editingDept.DepartmentHeadEmployeeId = headId;
                _editingDept.DepartmentHeadName = headName;
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