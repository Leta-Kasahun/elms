using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class AssignUserRolesDialog : Form
    {
        private readonly Employee _emp;
        private readonly User _user;

        private class RoleItem
        {
            public SystemRole Role { get; set; }
            public string Display { get; set; } = string.Empty;
            public override string ToString() => Display;
        }

        public AssignUserRolesDialog(Employee emp, User user)
        {
            _emp = emp ?? throw new ArgumentNullException(nameof(emp));
            _user = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();

            lblEmpName.Text = _emp.FullName;
            lblEmpCodeBadge.Text = _emp.EmployeeCode;
            lblUsernameVal.Text = _user.Username;

            using (var g = lblEmpName.CreateGraphics())
            {
                var sz = g.MeasureString(lblEmpName.Text, lblEmpName.Font);
                lblEmpCodeBadge.Location = new Point((int)sz.Width + 20, lblEmpCodeBadge.Location.Y);
            }

            PopulateRoles();
        }

        private void PopulateRoles()
        {
            chkRolesList.Items.Clear();

            var available = new[]
            {
                new RoleItem { Role = SystemRole.Admin, Display = "Admin (Operational governance & workflow admin)" },
                new RoleItem { Role = SystemRole.HR_Manager, Display = "HR Manager (Personnel, leave quotas & final approval)" },
                new RoleItem { Role = SystemRole.Department_Head, Display = "Department Head (Step 1 department endorsement)" },
                new RoleItem { Role = SystemRole.Clearance_Officer, Display = "Clearance Officer (Checklist & equipment handover)" },
                new RoleItem { Role = SystemRole.Employee, Display = "Employee (Staff self-service & leave applications)" }
            };

            for (int i = 0; i < available.Length; i++)
            {
                var item = available[i];
                bool isChecked = _user.Roles.Contains(item.Role);
                chkRolesList.Items.Add(item, isChecked);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selected = new List<SystemRole>();
            foreach (var obj in chkRolesList.CheckedItems)
            {
                if (obj is RoleItem ri)
                {
                    selected.Add(ri.Role);
                }
            }

            if (selected.Count == 0)
            {
                MessageBox.Show("Please select at least one role scope (e.g. Employee).", "Role Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = EmployeeService.Instance.UpdateUserRoles(_user.Id, selected);
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Roles Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                var r = pnlCard.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                e.Graphics.DrawRectangle(pen, r);
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