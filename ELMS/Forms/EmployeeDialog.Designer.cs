namespace ELMS.Forms
{
    partial class EmployeeDialog
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblProfileDetails = new System.Windows.Forms.Label();
            this.grpPassword = new System.Windows.Forms.GroupBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.chkRolesList = new System.Windows.Forms.CheckedListBox();
            this.btnSaveRoles = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpPassword.SuspendLayout();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(460, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Employee Details & Admin Actions";
            // 
            // lblProfileDetails
            // 
            this.lblProfileDetails.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblProfileDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProfileDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileDetails.Location = new System.Drawing.Point(20, 48);
            this.lblProfileDetails.Name = "lblProfileDetails";
            this.lblProfileDetails.Padding = new System.Windows.Forms.Padding(8);
            this.lblProfileDetails.Size = new System.Drawing.Size(460, 95);
            this.lblProfileDetails.TabIndex = 1;
            this.lblProfileDetails.Text = "Loading details...";
            // 
            // grpPassword
            // 
            this.grpPassword.Controls.Add(this.btnResetPass);
            this.grpPassword.Controls.Add(this.txtNewPassword);
            this.grpPassword.Controls.Add(this.lblNewPass);
            this.grpPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPassword.Location = new System.Drawing.Point(20, 155);
            this.grpPassword.Name = "grpPassword";
            this.grpPassword.Size = new System.Drawing.Size(460, 85);
            this.grpPassword.TabIndex = 2;
            this.grpPassword.TabStop = false;
            this.grpPassword.Text = "Admin Password Reset";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNewPass.Location = new System.Drawing.Point(15, 28);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(107, 19);
            this.lblNewPass.TabIndex = 0;
            this.lblNewPass.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNewPassword.Location = new System.Drawing.Point(15, 48);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(270, 29);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnResetPass.FlatAppearance.BorderSize = 0;
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetPass.ForeColor = System.Drawing.Color.White;
            this.btnResetPass.Location = new System.Drawing.Point(295, 48);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(150, 29);
            this.btnResetPass.TabIndex = 2;
            this.btnResetPass.Text = "Update Password";
            this.btnResetPass.UseVisualStyleBackColor = false;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.btnSaveRoles);
            this.grpRoles.Controls.Add(this.chkRolesList);
            this.grpRoles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpRoles.Location = new System.Drawing.Point(20, 250);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(460, 150);
            this.grpRoles.TabIndex = 3;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Assign System Roles (RBAC)";
            // 
            // chkRolesList
            // 
            this.chkRolesList.CheckOnClick = true;
            this.chkRolesList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRolesList.FormattingEnabled = true;
            this.chkRolesList.Location = new System.Drawing.Point(15, 28);
            this.chkRolesList.Name = "chkRolesList";
            this.chkRolesList.Size = new System.Drawing.Size(270, 100);
            this.chkRolesList.TabIndex = 0;
            // 
            // btnSaveRoles
            // 
            this.btnSaveRoles.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSaveRoles.FlatAppearance.BorderSize = 0;
            this.btnSaveRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRoles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveRoles.ForeColor = System.Drawing.Color.White;
            this.btnSaveRoles.Location = new System.Drawing.Point(295, 28);
            this.btnSaveRoles.Name = "btnSaveRoles";
            this.btnSaveRoles.Size = new System.Drawing.Size(150, 32);
            this.btnSaveRoles.TabIndex = 1;
            this.btnSaveRoles.Text = "Save Roles";
            this.btnSaveRoles.UseVisualStyleBackColor = false;
            this.btnSaveRoles.Click += new System.EventHandler(this.btnSaveRoles_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.Location = new System.Drawing.Point(380, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EmployeeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 460);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpRoles);
            this.Controls.Add(this.grpPassword);
            this.Controls.Add(this.lblProfileDetails);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Profile & Actions";
            this.grpPassword.ResumeLayout(false);
            this.grpPassword.PerformLayout();
            this.grpRoles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblProfileDetails;
        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.CheckedListBox chkRolesList;
        private System.Windows.Forms.Button btnSaveRoles;
        private System.Windows.Forms.Button btnClose;
    }
}
