namespace ELMS.Forms
{
    partial class LeaveTypeDialog
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
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.lblMonths = new System.Windows.Forms.Label();
            this.nudMonths = new System.Windows.Forms.NumericUpDown();
            this.chkClearance = new System.Windows.Forms.CheckBox();
            this.chkCertificate = new System.Windows.Forms.CheckBox();
            this.chkCarryForward = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).BeginInit();
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
            this.pnlTop.Size = new System.Drawing.Size(460, 76);
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
            this.lblSubtitle.Size = new System.Drawing.Size(326, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure leave entitlement quotas, rules, and policy clearance.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Leave Type Policy";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblCode.Location = new System.Drawing.Point(24, 95);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(97, 15);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Leave Type Code";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCode.Location = new System.Drawing.Point(24, 115);
            this.txtCode.Name = "txtCode";
            this.txtCode.PlaceholderText = "e.g. ANNUAL, SICK, STUDY";
            this.txtCode.Size = new System.Drawing.Size(412, 24);
            this.txtCode.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblName.Location = new System.Drawing.Point(24, 150);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(101, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Leave Type Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.Location = new System.Drawing.Point(24, 170);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "e.g. Annual Vacation Leave";
            this.txtName.Size = new System.Drawing.Size(412, 24);
            this.txtName.TabIndex = 4;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDays.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDays.Location = new System.Drawing.Point(24, 208);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(142, 15);
            this.lblDays.TabIndex = 5;
            this.lblDays.Text = "Default Entitlement Days";
            // 
            // nudDays
            // 
            this.nudDays.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudDays.Location = new System.Drawing.Point(24, 228);
            this.nudDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.nudDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(190, 24);
            this.nudDays.TabIndex = 6;
            this.nudDays.Value = new decimal(new int[] { 21, 0, 0, 0 });
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonths.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMonths.Location = new System.Drawing.Point(246, 208);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(126, 15);
            this.lblMonths.TabIndex = 7;
            this.lblMonths.Text = "Min Service (Months)";
            // 
            // nudMonths
            // 
            this.nudMonths.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudMonths.Location = new System.Drawing.Point(246, 228);
            this.nudMonths.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.nudMonths.Name = "nudMonths";
            this.nudMonths.Size = new System.Drawing.Size(190, 24);
            this.nudMonths.TabIndex = 8;
            this.nudMonths.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // chkClearance
            // 
            this.chkClearance.AutoSize = true;
            this.chkClearance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkClearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkClearance.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.chkClearance.Location = new System.Drawing.Point(24, 270);
            this.chkClearance.Name = "chkClearance";
            this.chkClearance.Size = new System.Drawing.Size(262, 19);
            this.chkClearance.TabIndex = 9;
            this.chkClearance.Text = "Requires Multi-Department Handover Clearance";
            this.chkClearance.UseVisualStyleBackColor = true;
            // 
            // chkCertificate
            // 
            this.chkCertificate.AutoSize = true;
            this.chkCertificate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCertificate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCertificate.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.chkCertificate.Location = new System.Drawing.Point(24, 298);
            this.chkCertificate.Name = "chkCertificate";
            this.chkCertificate.Size = new System.Drawing.Size(252, 19);
            this.chkCertificate.TabIndex = 10;
            this.chkCertificate.Text = "Requires Medical or Supporting Certification";
            this.chkCertificate.UseVisualStyleBackColor = true;
            // 
            // chkCarryForward
            // 
            this.chkCarryForward.AutoSize = true;
            this.chkCarryForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCarryForward.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCarryForward.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.chkCarryForward.Location = new System.Drawing.Point(24, 326);
            this.chkCarryForward.Name = "chkCarryForward";
            this.chkCarryForward.Size = new System.Drawing.Size(232, 19);
            this.chkCarryForward.TabIndex = 11;
            this.chkCarryForward.Text = "Permit Unused Quota Carry-Forward";
            this.chkCarryForward.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 362);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlFooter.Size = new System.Drawing.Size(460, 58);
            this.pnlFooter.TabIndex = 12;
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
            this.btnCancel.Location = new System.Drawing.Point(224, 12);
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
            this.btnSave.Location = new System.Drawing.Point(328, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Policy";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LeaveTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 420);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.chkCarryForward);
            this.Controls.Add(this.chkCertificate);
            this.Controls.Add(this.chkClearance);
            this.Controls.Add(this.nudMonths);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.nudDays);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeaveTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Leave Type Policy";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.NumericUpDown nudMonths;
        private System.Windows.Forms.CheckBox chkClearance;
        private System.Windows.Forms.CheckBox chkCertificate;
        private System.Windows.Forms.CheckBox chkCarryForward;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}