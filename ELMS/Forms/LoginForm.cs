using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class LoginForm : Form
    {
        private Control? _focusedInput;

        public LoginForm()
        {
            InitializeComponent();
            CenterCard();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void CenterCard()
        {
            if (pnlCenterCard != null)
            {
                int x = Math.Max(20, (this.ClientSize.Width - pnlCenterCard.Width) / 2);
                int y = Math.Max(20, (this.ClientSize.Height - pnlCenterCard.Height - 35) / 2);
                pnlCenterCard.Location = new Point(x, y);
            }
        }

        private void pnlCenterCard_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCenterCard.Width - 1, pnlCenterCard.Height - 1);
            }
        }

        private void InputBox_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;

            bool isFocused = (pnl == pnlUserBox && _focusedInput == txtUsername) ||
                             (pnl == pnlPassBox && _focusedInput == txtPassword);

            Color borderColor = isFocused ? Color.FromArgb(234, 88, 12) : Color.FromArgb(203, 213, 225);
            int penWidth = isFocused ? 2 : 1;

            using (var pen = new Pen(borderColor, penWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 3, pnl.Height - 3);
            }
        }

        private void Input_Enter(object sender, EventArgs e)
        {
            _focusedInput = sender as Control;
            pnlUserBox.Invalidate();
            pnlPassBox.Invalidate();
        }

        private void Input_Leave(object sender, EventArgs e)
        {
            _focusedInput = null;
            pnlUserBox.Invalidate();
            pnlPassBox.Invalidate();
        }

        private void btnTogglePass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePass.ForeColor = txtPassword.UseSystemPasswordChar
                ? Color.FromArgb(100, 116, 139)
                : Color.FromArgb(234, 88, 12);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var result = AuthService.Instance.Authenticate(username, password);
            if (result.Success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = result.Message ?? "Invalid username or password";
            }
        }
    }
}