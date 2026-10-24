namespace ELMS.Forms
{
    partial class ManageRolePermissionsDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlRoleCard = new System.Windows.Forms.Panel();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblRoleKeyBadge = new System.Windows.Forms.Label();
            this.lblRoleDescription = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlRoleCard.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.pnlRoleCard);
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(24, 18, 24, 14);
            this.pnlTop.Size = new System.Drawing.Size(664, 150);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Role Permissions";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(342, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Assign or revoke permission scopes for this role.";
            // 
            // pnlRoleCard
            // 
            this.pnlRoleCard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlRoleCard.Controls.Add(this.lblRoleDescription);
            this.pnlRoleCard.Controls.Add(this.lblRoleKeyBadge);
            this.pnlRoleCard.Controls.Add(this.lblRoleName);
            this.pnlRoleCard.Location = new System.Drawing.Point(24, 70);
            this.pnlRoleCard.Name = "pnlRoleCard";
            this.pnlRoleCard.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlRoleCard.Size = new System.Drawing.Size(616, 66);
            this.pnlRoleCard.TabIndex = 2;
            this.pnlRoleCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRoleCard_Paint);
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRoleName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRoleName.Location = new System.Drawing.Point(12, 10);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(83, 19);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "Role Name";
            // 
            // lblRoleKeyBadge
            // 
            this.lblRoleKeyBadge.AutoSize = true;
            this.lblRoleKeyBadge.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.lblRoleKeyBadge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRoleKeyBadge.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblRoleKeyBadge.Location = new System.Drawing.Point(140, 13);
            this.lblRoleKeyBadge.Name = "lblRoleKeyBadge";
            this.lblRoleKeyBadge.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.lblRoleKeyBadge.Size = new System.Drawing.Size(76, 15);
            this.lblRoleKeyBadge.TabIndex = 1;
            this.lblRoleKeyBadge.Text = "ROLE_KEY";
            // 
            // lblRoleDescription
            // 
            this.lblRoleDescription.AutoEllipsis = true;
            this.lblRoleDescription.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRoleDescription.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRoleDescription.Location = new System.Drawing.Point(12, 34);
            this.lblRoleDescription.Name = "lblRoleDescription";
            this.lblRoleDescription.Size = new System.Drawing.Size(590, 22);
            this.lblRoleDescription.TabIndex = 2;
            this.lblRoleDescription.Text = "Role description text goes here...";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Controls.Add(this.btnDeselectAll);
            this.pnlSearch.Controls.Add(this.btnSelectAll);
            this.pnlSearch.Controls.Add(this.btnClearSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 150);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(664, 48);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtSearch.Location = new System.Drawing.Point(24, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search permissions by name, key, or module...";
            this.txtSearch.Size = new System.Drawing.Size(280, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.White;
            this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnClearSearch.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClearSearch.Location = new System.Drawing.Point(308, 10);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(28, 25);
            this.btnClearSearch.TabIndex = 1;
            this.btnClearSearch.Text = "✕";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.White;
            this.btnSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSelectAll.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnSelectAll.Location = new System.Drawing.Point(346, 10);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(76, 26);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.BackColor = System.Drawing.Color.White;
            this.btnDeselectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeselectAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDeselectAll.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDeselectAll.Location = new System.Drawing.Point(428, 10);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(86, 26);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(520, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(120, 23);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Selected: 0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 198);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24, 8, 24, 8);
            this.pnlContent.Size = new System.Drawing.Size(664, 402);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 600);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlFooter.Size = new System.Drawing.Size(664, 60);
            this.pnlFooter.TabIndex = 3;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnCancel.Location = new System.Drawing.Point(404, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(514, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Permissions";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ManageRolePermissionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(664, 660);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageRolePermissionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Role Permissions";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlRoleCard.ResumeLayout(false);
            this.pnlRoleCard.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlRoleCard;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblRoleKeyBadge;
        private System.Windows.Forms.Label lblRoleDescription;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}