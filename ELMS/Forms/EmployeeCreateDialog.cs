using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class EmployeeCreateDialog : Form
    {
        private class DeptItem
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public override string ToString() => Name;
        }

        private class RoleItem
        {
            public SystemRole Role { get; set; }
            public string Name { get; set; } = string.Empty;
            public override string ToString() => Name;
        }

        public EmployeeCreateDialog()
        {
            InitializeComponent();
            PopulateDropdowns();

            int nextId = DataStore.Instance.Employees.Any() ? DataStore.Instance.Employees.Max(e => e.Id) + 1 : 1;
            txtEmpCode.Text = $"EMP-{nextId:D3}";
            cboGender.SelectedIndex = 0;
            dtpHireDate.Value = DateTime.Today;
        }

        private void PopulateDropdowns()
        {
            cboDept.Items.Clear();
            foreach (var d in DataStore.Instance.Departments.OrderBy(dept => dept.Name))
            {
                cboDept.Items.Add(new DeptItem { Id = d.Id, Name = d.Name });
            }
            if (cboDept.Items.Count > 0) cboDept.SelectedIndex = 0;

            cboRole.Items.Clear();
            cboRole.Items.Add(new RoleItem { Role = SystemRole.Employee, Name = "Employee (Standard Staff)" });
            cboRole.Items.Add(new RoleItem { Role = SystemRole.Department_Head, Name = "Department Head (Approver)" });
            cboRole.Items.Add(new RoleItem { Role = SystemRole.HR_Manager, Name = "HR Manager" });
            cboRole.Items.Add(new RoleItem { Role = SystemRole.Clearance_Officer, Name = "Clearance Officer" });
            cboRole.Items.Add(new RoleItem { Role = SystemRole.Admin, Name = "Administrator" });
            cboRole.SelectedIndex = 0;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim().ToLowerInvariant();
            string last = txtLastName.Text.Trim().ToLowerInvariant();

            if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
            {
                txtEmail.Text = $"{first}.{last}@elms.corp";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim();
            string last = txtLastName.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
            {
                MessageBox.Show("First and last names are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                MessageBox.Show("Job title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Corporate email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDept = cboDept.SelectedItem as DeptItem;
            int deptId = selectedDept?.Id ?? 1;
            string deptName = selectedDept?.Name ?? "General";

            int nextEmpId = DataStore.Instance.Employees.Any() ? DataStore.Instance.Employees.Max(emp => emp.Id) + 1 : 1;
            string empCode = $"EMP-{nextEmpId:D3}";

            var newEmp = new Employee
            {
                Id = nextEmpId,
                EmployeeCode = empCode,
                FirstName = first,
                LastName = last,
                Gender = cboGender.SelectedItem?.ToString() ?? "Male",
                DepartmentId = deptId,
                DepartmentName = deptName,
                JobTitle = jobTitle,
                Email = email,
                HireDate = dtpHireDate.Value,
                IsActive = true
            };
            DataStore.Instance.Employees.Add(newEmp);

            // Provision User Account
            int nextUserId = DataStore.Instance.Users.Any() ? DataStore.Instance.Users.Max(u => u.Id) + 1 : 1;
            string username = email.Split('@')[0];
            var roleItem = cboRole.SelectedItem as RoleItem;
            var assignedRole = roleItem?.Role ?? SystemRole.Employee;

            var newUser = new User
            {
                Id = nextUserId,
                Username = username,
                PasswordHash = password,
                EmployeeId = nextEmpId,
                IsActive = true,
                Roles = new List<SystemRole> { assignedRole }
            };
            DataStore.Instance.Users.Add(newUser);

            // Seed Initial Leave Entitlements
            int nextEntId = DataStore.Instance.Entitlements.Any() ? DataStore.Instance.Entitlements.Max(ent => ent.Id) + 1 : 1;
            int year = DateTime.Now.Year;

            foreach (var lt in DataStore.Instance.LeaveTypes)
            {
                DataStore.Instance.Entitlements.Add(new LeaveEntitlement
                {
                    Id = nextEntId++,
                    EmployeeId = nextEmpId,
                    LeaveTypeId = lt.Id,
                    FiscalYear = year,
                    BaseDays = lt.EntitlementDays,
                    CarriedOverDays = 0,
                    TenureBonusDays = 0,
                    UsedDays = 0
                });
            }

            DataStore.Instance.NotifyChanged();
            MessageBox.Show($"Employee '{newEmp.FullName}' ({empCode}) registered successfully with login username '{username}'.", "Employee Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
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