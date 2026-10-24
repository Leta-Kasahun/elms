namespace ELMS.Forms
{
    partial class RoleDialog
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
            this.lblSub = new System.Windows.Forms.Label();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRoleKey = new System.Windows.Forms.Label();
            this.txtRoleKey = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.chkPermissionsList = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHeader.Location = new System.Drawing.Point(24, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(126, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Create Role";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSub.Location = new System.Drawing.Point(25, 50);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(370, 20);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Configure role identifier, description, and permissions";
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRoleName.Location = new System.Drawing.Point(25, 90);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(86, 20);
            this.lblRoleName.TabIndex = 2;
            this.lblRoleName.Text = "Role Name";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRoleName.Location = new System.Drawing.Point(28, 115);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.PlaceholderText = "e.g. Operations Coordinator";
            this.txtRoleName.Size = new System.Drawing.Size(420, 29);
            this.txtRoleName.TabIndex = 3;
            // 
            // lblRoleKey
            // 
            this.lblRoleKey.AutoSize = true;
            this.lblRoleKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleKey.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRoleKey.Location = new System.Drawing.Point(25, 160);
            this.lblRoleKey.Name = "lblRoleKey";
            this.lblRoleKey.Size = new System.Drawing.Size(70, 20);
            this.lblRoleKey.TabIndex = 4;
            this.lblRoleKey.Text = "Role Key";
            // 
            // txtRoleKey
            // 
            this.txtRoleKey.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRoleKey.Location = new System.Drawing.Point(28, 185);
            this.txtRoleKey.Name = "txtRoleKey";
            this.txtRoleKey.PlaceholderText = "e.g. ROLE_OPERATIONS_COORD";
            this.txtRoleKey.Size = new System.Drawing.Size(420, 29);
            this.txtRoleKey.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDesc.Location = new System.Drawing.Point(25, 230);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(89, 20);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.Location = new System.Drawing.Point(28, 255);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Functional responsibilities and scope of this role...";
            this.txtDescription.Size = new System.Drawing.Size(420, 60);
            this.txtDescription.TabIndex = 7;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkIsActive.Location = new System.Drawing.Point(28, 330);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(139, 24);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Role is active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPermissions.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPermissions.Location = new System.Drawing.Point(25, 365);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(155, 20);
            this.lblPermissions.TabIndex = 9;
            this.lblPermissions.Text = "Granted Permissions";
            // 
            // chkPermissionsList
            // 
            this.chkPermissionsList.CheckOnClick = true;
            this.chkPermissionsList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkPermissionsList.FormattingEnabled = true;
            this.chkPermissionsList.Location = new System.Drawing.Point(28, 390);
            this.chkPermissionsList.Name = "chkPermissionsList";
            this.chkPermissionsList.Size = new System.Drawing.Size(420, 114);
            this.chkPermissionsList.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(328, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save Role";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCancel.Location = new System.Drawing.Point(218, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoleDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 575);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkPermissionsList);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtRoleKey);
            this.Controls.Add(this.lblRoleKey);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Role Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleKey;
        private System.Windows.Forms.TextBox txtRoleKey;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.CheckedListBox chkPermissionsList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
