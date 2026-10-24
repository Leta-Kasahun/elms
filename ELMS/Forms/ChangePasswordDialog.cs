using System;
using System.Drawing;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class ChangePasswordDialog : Form
    {
        private readonly Employee _emp;
        private readonly User _user;

        public ChangePasswordDialog(Employee emp, User user)
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
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPass.Checked;
            txtNewPass.UseSystemPasswordChar = !show;
            txtConfirmPass.UseSystemPasswordChar = !show;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string newPass = txtNewPass.Text.Trim();
            string confirm = txtConfirmPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPass))
            {
                ShowError("New password cannot be empty.");
                return;
            }

            if (newPass.Length < 4)
            {
                ShowError("Password must be at least 4 characters.");
                return;
            }

            if (newPass != confirm)
            {
                ShowError("Passwords do not match.");
                return;
            }

            var result = EmployeeService.Instance.ResetPassword(_user.Id, newPass);
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
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