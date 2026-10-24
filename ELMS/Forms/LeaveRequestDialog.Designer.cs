namespace ELMS.Forms
{
    partial class LeaveRequestDialog
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
            this.lblEmp = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboLeaveType = new System.Windows.Forms.ComboBox();
            this.lblDates = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblLiveInfo = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmp
            // 
            this.lblEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmp.Location = new System.Drawing.Point(24, 20);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(430, 20);
            this.lblEmp.TabIndex = 0;
            this.lblEmp.Text = "Target Employee";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(24, 44);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(430, 29);
            this.cboEmployee.TabIndex = 1;
            this.cboEmployee.SelectedIndexChanged += new System.EventHandler(this.cboEmployee_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(24, 85);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(430, 20);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Leave Type";
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLeaveType.FormattingEnabled = true;
            this.cboLeaveType.Location = new System.Drawing.Point(24, 109);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(430, 29);
            this.cboLeaveType.TabIndex = 3;
            this.cboLeaveType.SelectedIndexChanged += new System.EventHandler(this.cboLeaveType_SelectedIndexChanged);
            // 
            // lblDates
            // 
            this.lblDates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDates.Location = new System.Drawing.Point(24, 150);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(430, 20);
            this.lblDates.TabIndex = 4;
            this.lblDates.Text = "Date Range (Start - End)";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(24, 174);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(205, 29);
            this.dtpStartDate.TabIndex = 5;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpDates_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(249, 174);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(205, 29);
            this.dtpEndDate.TabIndex = 6;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpDates_ValueChanged);
            // 
            // lblLiveInfo
            // 
            this.lblLiveInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLiveInfo.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblLiveInfo.Location = new System.Drawing.Point(24, 212);
            this.lblLiveInfo.Name = "lblLiveInfo";
            this.lblLiveInfo.Size = new System.Drawing.Size(430, 24);
            this.lblLiveInfo.TabIndex = 7;
            this.lblLiveInfo.Text = "Calculating quota balance...";
            // 
            // lblReason
            // 
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReason.Location = new System.Drawing.Point(24, 245);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(430, 20);
            this.lblReason.TabIndex = 8;
            this.lblReason.Text = "Reason / Notes";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtReason.Location = new System.Drawing.Point(24, 269);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(430, 65);
            this.txtReason.TabIndex = 9;
            // 
            // btnDraft
            // 
            this.btnDraft.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraft.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDraft.Location = new System.Drawing.Point(120, 355);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(155, 38);
            this.btnDraft.TabIndex = 10;
            this.btnDraft.Text = "Save as Draft";
            this.btnDraft.UseVisualStyleBackColor = false;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(285, 355);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(170, 38);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit Request";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // LeaveRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 415);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDraft);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblLiveInfo);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblDates);
            this.Controls.Add(this.cboLeaveType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.lblEmp);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeaveRequestDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Leave Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboLeaveType;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblLiveInfo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.Button btnSubmit;
    }
}
