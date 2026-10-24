namespace ELMS.Forms
{
    partial class AssignUserRolesDialog
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblUsernameVal = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmpCodeBadge = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblRolesHeading = new System.Windows.Forms.Label();
            this.chkRolesList = new System.Windows.Forms.CheckedListBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(24, 18, 24, 12);
            this.pnlTop.Size = new System.Drawing.Size(480, 76);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure role-based access control (RBAC) permissions.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assign User Roles";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCard.Controls.Add(this.lblUsernameVal);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.lblEmpCodeBadge);
            this.pnlCard.Controls.Add(this.lblEmpName);
            this.pnlCard.Location = new System.Drawing.Point(24, 90);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlCard.Size = new System.Drawing.Size(432, 62);
            this.pnlCard.TabIndex = 1;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblUsernameVal
            // 
            this.lblUsernameVal.AutoSize = true;
            this.lblUsernameVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsernameVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUsernameVal.Location = new System.Drawing.Point(82, 34);
            this.lblUsernameVal.Name = "lblUsernameVal";
            this.lblUsernameVal.Size = new System.Drawing.Size(61, 15);
            this.lblUsernameVal.TabIndex = 3;
            this.lblUsernameVal.Text = "username";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsername.Location = new System.Drawing.Point(12, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 15);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // lblEmpCodeBadge
            // 
            this.lblEmpCodeBadge.AutoSize = true;
            this.lblEmpCodeBadge.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.lblEmpCodeBadge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEmpCodeBadge.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblEmpCodeBadge.Location = new System.Drawing.Point(180, 11);
            this.lblEmpCodeBadge.Name = "lblEmpCodeBadge";
            this.lblEmpCodeBadge.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.lblEmpCodeBadge.Size = new System.Drawing.Size(64, 15);
            this.lblEmpCodeBadge.TabIndex = 1;
            this.lblEmpCodeBadge.Text = "EMP-001";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmpName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEmpName.Location = new System.Drawing.Point(12, 10);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(107, 17);
            this.lblEmpName.TabIndex = 0;
            this.lblEmpName.Text = "Employee Name";
            // 
            // lblRolesHeading
            // 
            this.lblRolesHeading.AutoSize = true;
            this.lblRolesHeading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRolesHeading.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblRolesHeading.Location = new System.Drawing.Point(24, 168);
            this.lblRolesHeading.Name = "lblRolesHeading";
            this.lblRolesHeading.Size = new System.Drawing.Size(126, 15);
            this.lblRolesHeading.TabIndex = 2;
            this.lblRolesHeading.Text = "Assigned Role Scopes";
            // 
            // chkRolesList
            // 
            this.chkRolesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkRolesList.CheckOnClick = true;
            this.chkRolesList.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkRolesList.FormattingEnabled = true;
            this.chkRolesList.Location = new System.Drawing.Point(24, 190);
            this.chkRolesList.Name = "chkRolesList";
            this.chkRolesList.Size = new System.Drawing.Size(432, 172);
            this.chkRolesList.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 382);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlFooter.Size = new System.Drawing.Size(480, 58);
            this.pnlFooter.TabIndex = 4;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnCancel.Location = new System.Drawing.Point(256, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(360, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Roles";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AssignUserRolesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 440);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.chkRolesList);
            this.Controls.Add(this.lblRolesHeading);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignUserRolesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign User Roles";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblEmpCodeBadge;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsernameVal;
        private System.Windows.Forms.Label lblRolesHeading;
        private System.Windows.Forms.CheckedListBox chkRolesList;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}