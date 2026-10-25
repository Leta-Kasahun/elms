namespace ELMS.Forms
{
    partial class LeaveClearanceDialog
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblEmpInfo = new System.Windows.Forms.Label();
            this.lblPeriodInfo = new System.Windows.Forms.Label();
            this.lblStatusBadge = new System.Windows.Forms.Label();
            this.lblProgressInfo = new System.Windows.Forms.Label();
            this.dgvClearance = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSignOffItem = new System.Windows.Forms.Button();
            this.btnCompleteAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRoleNotice = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearance)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 18, 24, 14);
            this.pnlHeader.Size = new System.Drawing.Size(760, 72);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Study Leave Clearance Verification";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(462, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Verify and record multi-department handover clearances for academic and sabbatical leaves.";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary.Controls.Add(this.lblProgressInfo);
            this.pnlSummary.Controls.Add(this.lblStatusBadge);
            this.pnlSummary.Controls.Add(this.lblPeriodInfo);
            this.pnlSummary.Controls.Add(this.lblEmpInfo);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 72);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlSummary.Size = new System.Drawing.Size(760, 78);
            this.pnlSummary.TabIndex = 1;
            this.pnlSummary.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSummary_Paint);
            // 
            // lblEmpInfo
            // 
            this.lblEmpInfo.AutoSize = true;
            this.lblEmpInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmpInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblEmpInfo.Location = new System.Drawing.Point(22, 14);
            this.lblEmpInfo.Name = "lblEmpInfo";
            this.lblEmpInfo.Size = new System.Drawing.Size(265, 19);
            this.lblEmpInfo.TabIndex = 0;
            this.lblEmpInfo.Text = "John Doe (EMP-003)  |  Engineering Dept";
            // 
            // lblPeriodInfo
            // 
            this.lblPeriodInfo.AutoSize = true;
            this.lblPeriodInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPeriodInfo.Location = new System.Drawing.Point(23, 40);
            this.lblPeriodInfo.Name = "lblPeriodInfo";
            this.lblPeriodInfo.Size = new System.Drawing.Size(378, 15);
            this.lblPeriodInfo.TabIndex = 1;
            this.lblPeriodInfo.Text = "Request # LR-2026-002  |  Study Leave (60 days)  |  2026-11-20 to 2027-01-20";
            // 
            // lblStatusBadge
            // 
            this.lblStatusBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.lblStatusBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblStatusBadge.Location = new System.Drawing.Point(580, 14);
            this.lblStatusBadge.Name = "lblStatusBadge";
            this.lblStatusBadge.Size = new System.Drawing.Size(155, 26);
            this.lblStatusBadge.TabIndex = 2;
            this.lblStatusBadge.Text = "CLEARANCE IN PROGRESS";
            this.lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgressInfo
            // 
            this.lblProgressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgressInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProgressInfo.Location = new System.Drawing.Point(580, 43);
            this.lblProgressInfo.Name = "lblProgressInfo";
            this.lblProgressInfo.Size = new System.Drawing.Size(155, 20);
            this.lblProgressInfo.TabIndex = 3;
            this.lblProgressInfo.Text = "Progress: 1 of 3 Cleared";
            this.lblProgressInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvClearance
            // 
            this.dgvClearance.AllowUserToAddRows = false;
            this.dgvClearance.AllowUserToDeleteRows = false;
            this.dgvClearance.BackgroundColor = System.Drawing.Color.White;
            this.dgvClearance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClearance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClearance.Location = new System.Drawing.Point(0, 150);
            this.dgvClearance.Name = "dgvClearance";
            this.dgvClearance.ReadOnly = true;
            this.dgvClearance.RowHeadersVisible = false;
            this.dgvClearance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClearance.Size = new System.Drawing.Size(760, 270);
            this.dgvClearance.TabIndex = 2;
            this.dgvClearance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClearance_CellFormatting);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBottom.Controls.Add(this.lblRoleNotice);
            this.pnlBottom.Controls.Add(this.btnSignOffItem);
            this.pnlBottom.Controls.Add(this.btnCompleteAll);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 420);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.pnlBottom.Size = new System.Drawing.Size(760, 68);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // btnSignOffItem
            // 
            this.btnSignOffItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnSignOffItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignOffItem.FlatAppearance.BorderSize = 0;
            this.btnSignOffItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOffItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSignOffItem.ForeColor = System.Drawing.Color.White;
            this.btnSignOffItem.Location = new System.Drawing.Point(24, 16);
            this.btnSignOffItem.Name = "btnSignOffItem";
            this.btnSignOffItem.Size = new System.Drawing.Size(185, 36);
            this.btnSignOffItem.TabIndex = 0;
            this.btnSignOffItem.Text = "✓ Sign Off Selected Item";
            this.btnSignOffItem.UseVisualStyleBackColor = false;
            this.btnSignOffItem.Click += new System.EventHandler(this.btnSignOffItem_Click);
            // 
            // btnCompleteAll
            // 
            this.btnCompleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCompleteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteAll.FlatAppearance.BorderSize = 0;
            this.btnCompleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteAll.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCompleteAll.ForeColor = System.Drawing.Color.White;
            this.btnCompleteAll.Location = new System.Drawing.Point(219, 16);
            this.btnCompleteAll.Name = "btnCompleteAll";
            this.btnCompleteAll.Size = new System.Drawing.Size(185, 36);
            this.btnCompleteAll.TabIndex = 1;
            this.btnCompleteAll.Text = "✓ Complete Clearance";
            this.btnCompleteAll.UseVisualStyleBackColor = false;
            this.btnCompleteAll.Click += new System.EventHandler(this.btnCompleteAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClose.Location = new System.Drawing.Point(646, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRoleNotice
            // 
            this.lblRoleNotice.AutoSize = true;
            this.lblRoleNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRoleNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRoleNotice.Location = new System.Drawing.Point(24, 26);
            this.lblRoleNotice.Name = "lblRoleNotice";
            this.lblRoleNotice.Size = new System.Drawing.Size(420, 15);
            this.lblRoleNotice.TabIndex = 3;
            this.lblRoleNotice.Text = "Read-Only View: Clearance sign-offs are conducted by authorized unit officers.";
            this.lblRoleNotice.Visible = false;
            // 
            // LeaveClearanceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 488);
            this.Controls.Add(this.dgvClearance);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeaveClearanceDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Study Leave Clearance Verification";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearance)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblEmpInfo;
        private System.Windows.Forms.Label lblPeriodInfo;
        private System.Windows.Forms.Label lblStatusBadge;
        private System.Windows.Forms.Label lblProgressInfo;
        private System.Windows.Forms.DataGridView dgvClearance;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSignOffItem;
        private System.Windows.Forms.Button btnCompleteAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRoleNotice;
    }
}
