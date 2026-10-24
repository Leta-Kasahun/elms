namespace ELMS.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlCenterCard = new System.Windows.Forms.Panel();
            this.pnlLogoBadge = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlUserBox = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlPassBox = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePass = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblPageFooter = new System.Windows.Forms.Label();
            this.pnlCenterCard.SuspendLayout();
            this.pnlLogoBadge.SuspendLayout();
            this.pnlUserBox.SuspendLayout();
            this.pnlPassBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenterCard
            // 
            this.pnlCenterCard.BackColor = System.Drawing.Color.White;
            this.pnlCenterCard.Controls.Add(this.btnSignIn);
            this.pnlCenterCard.Controls.Add(this.lblError);
            this.pnlCenterCard.Controls.Add(this.pnlPassBox);
            this.pnlCenterCard.Controls.Add(this.lblPassword);
            this.pnlCenterCard.Controls.Add(this.pnlUserBox);
            this.pnlCenterCard.Controls.Add(this.lblUsername);
            this.pnlCenterCard.Controls.Add(this.lblSubtitle);
            this.pnlCenterCard.Controls.Add(this.lblTitle);
            this.pnlCenterCard.Controls.Add(this.pnlLogoBadge);
            this.pnlCenterCard.Location = new System.Drawing.Point(320, 90);
            this.pnlCenterCard.Name = "pnlCenterCard";
            this.pnlCenterCard.Size = new System.Drawing.Size(520, 500);
            this.pnlCenterCard.TabIndex = 0;
            this.pnlCenterCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCenterCard_Paint);
            // 
            // pnlLogoBadge
            // 
            this.pnlLogoBadge.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.pnlLogoBadge.Controls.Add(this.lblLogoIcon);
            this.pnlLogoBadge.Location = new System.Drawing.Point(235, 36);
            this.pnlLogoBadge.Name = "pnlLogoBadge";
            this.pnlLogoBadge.Size = new System.Drawing.Size(50, 50);
            this.pnlLogoBadge.TabIndex = 0;
            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLogoIcon.ForeColor = System.Drawing.Color.White;
            this.lblLogoIcon.Location = new System.Drawing.Point(0, 0);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(50, 50);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "📅";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(30, 96);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Leave Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(30, 142);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(460, 26);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Login to your account";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUsername.Location = new System.Drawing.Point(48, 190);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(89, 23);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // pnlUserBox
            // 
            this.pnlUserBox.BackColor = System.Drawing.Color.White;
            this.pnlUserBox.Controls.Add(this.txtUsername);
            this.pnlUserBox.Location = new System.Drawing.Point(48, 218);
            this.pnlUserBox.Name = "pnlUserBox";
            this.pnlUserBox.Size = new System.Drawing.Size(424, 46);
            this.pnlUserBox.TabIndex = 4;
            this.pnlUserBox.Paint += new System.Windows.Forms.PaintEventHandler(this.InputBox_Paint);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtUsername.Location = new System.Drawing.Point(14, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Enter username";
            this.txtUsername.Size = new System.Drawing.Size(395, 26);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.Input_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPassword.Location = new System.Drawing.Point(48, 278);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(84, 23);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // pnlPassBox
            // 
            this.pnlPassBox.BackColor = System.Drawing.Color.White;
            this.pnlPassBox.Controls.Add(this.btnTogglePass);
            this.pnlPassBox.Controls.Add(this.txtPassword);
            this.pnlPassBox.Location = new System.Drawing.Point(48, 306);
            this.pnlPassBox.Name = "pnlPassBox";
            this.pnlPassBox.Size = new System.Drawing.Size(424, 46);
            this.pnlPassBox.TabIndex = 6;
            this.pnlPassBox.Paint += new System.Windows.Forms.PaintEventHandler(this.InputBox_Paint);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPassword.Location = new System.Drawing.Point(14, 11);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "••••••••••••";
            this.txtPassword.Size = new System.Drawing.Size(350, 26);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.Input_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // btnTogglePass
            // 
            this.btnTogglePass.BackColor = System.Drawing.Color.Transparent;
            this.btnTogglePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePass.FlatAppearance.BorderSize = 0;
            this.btnTogglePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTogglePass.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnTogglePass.Location = new System.Drawing.Point(375, 6);
            this.btnTogglePass.Name = "btnTogglePass";
            this.btnTogglePass.Size = new System.Drawing.Size(40, 34);
            this.btnTogglePass.TabIndex = 1;
            this.btnTogglePass.Text = "👁";
            this.btnTogglePass.UseVisualStyleBackColor = false;
            this.btnTogglePass.Click += new System.EventHandler(this.btnTogglePass_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblError.Location = new System.Drawing.Point(48, 360);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(424, 22);
            this.lblError.TabIndex = 7;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(48, 395);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(424, 48);
            this.btnSignIn.TabIndex = 8;
            this.btnSignIn.Text = "Login";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblPageFooter
            // 
            this.lblPageFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPageFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageFooter.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblPageFooter.Location = new System.Drawing.Point(0, 715);
            this.lblPageFooter.Name = "lblPageFooter";
            this.lblPageFooter.Size = new System.Drawing.Size(1200, 35);
            this.lblPageFooter.TabIndex = 1;
            this.lblPageFooter.Text = "© 2026 Employee Leave Management System — All rights reserved.";
            this.lblPageFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.lblPageFooter);
            this.Controls.Add(this.pnlCenterCard);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.LoginForm_Resize);
            this.pnlCenterCard.ResumeLayout(false);
            this.pnlCenterCard.PerformLayout();
            this.pnlLogoBadge.ResumeLayout(false);
            this.pnlUserBox.ResumeLayout(false);
            this.pnlUserBox.PerformLayout();
            this.pnlPassBox.ResumeLayout(false);
            this.pnlPassBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenterCard;
        private System.Windows.Forms.Panel pnlLogoBadge;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUserBox;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPassBox;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTogglePass;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label lblPageFooter;
    }
}