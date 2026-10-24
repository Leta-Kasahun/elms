using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class EmployeeDialog : Form
    {
        private readonly Employee _employee;
        private readonly User? _user;

        public EmployeeDialog(Employee employee)
        {
            _employee = employee;
            _user = DataStore.Instance.Users.FirstOrDefault(u => u.EmployeeId == employee.Id);
            InitializeComponent();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            lblHeader.Text = $"[{_employee.EmployeeCode}] {_employee.FullName}";
            lblProfileDetails.Text =
                $"Department: {_employee.DepartmentName}\n" +
                $"Job Title: {_employee.JobTitle}\n" +
                $"Email: {_employee.Email}\n" +
                $"Hire Date: {_employee.HireDate:yyyy-MM-dd} (Tenure: {_employee.CompletedYearsOfService} yrs, {_employee.MonthsOfService} mos)\n" +
                $"Status: {(_employee.IsActive ? "ACTIVE" : "INACTIVE")} | Linked Username: {_user?.Username ?? "None"}";

            chkRolesList.Items.Clear();
            var allRoles = Enum.GetValues(typeof(SystemRole)).Cast<SystemRole>().ToList();
            for (int i = 0; i < allRoles.Count; i++)
            {
                var role = allRoles[i];
                bool isChecked = _user != null && _user.Roles.Contains(role);
                chkRolesList.Items.Add(role, isChecked);
            }

            bool isAdmin = AuthService.Instance.HasRole(SystemRole.Admin);
            grpPassword.Enabled = isAdmin && _user != null;
            grpRoles.Enabled = isAdmin && _user != null;
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (_user == null) return;
            string newPass = txtNewPassword.Text.Trim();
            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please enter a new password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = EmployeeService.Instance.ResetPassword(_user.Id, newPass);
            MessageBox.Show(res.Message, "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNewPassword.Text = "";
        }

        private void btnSaveRoles_Click(object sender, EventArgs e)
        {
            if (_user == null) return;
            var selectedRoles = new List<SystemRole>();
            foreach (var item in chkRolesList.CheckedItems)
            {
                selectedRoles.Add((SystemRole)item);
            }

            var res = EmployeeService.Instance.UpdateUserRoles(_user.Id, selectedRoles);
            MessageBox.Show(res.Message, "Roles Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
