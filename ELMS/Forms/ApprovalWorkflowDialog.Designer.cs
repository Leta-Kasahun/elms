namespace ELMS.Forms
{
    partial class ApprovalWorkflowDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.cboRequestType = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpSteps = new System.Windows.Forms.GroupBox();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.cboStep1Role = new System.Windows.Forms.ComboBox();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.cboStep2Role = new System.Windows.Forms.ComboBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.cboStep3Role = new System.Windows.Forms.ComboBox();
            this.chkSequential = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Configure Approval Workflow";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblName.Location = new System.Drawing.Point(24, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Workflow Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.Location = new System.Drawing.Point(24, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(466, 24);
            this.txtName.TabIndex = 2;
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRequestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRequestType.Location = new System.Drawing.Point(24, 120);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(130, 15);
            this.lblRequestType.TabIndex = 3;
            this.lblRequestType.Text = "Target Request Desk:";
            // 
            // cboRequestType
            // 
            this.cboRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequestType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRequestType.FormattingEnabled = true;
            this.cboRequestType.Location = new System.Drawing.Point(24, 140);
            this.cboRequestType.Name = "cboRequestType";
            this.cboRequestType.Size = new System.Drawing.Size(466, 24);
            this.cboRequestType.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescription.Location = new System.Drawing.Point(24, 180);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 15);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.Location = new System.Drawing.Point(24, 200);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(466, 45);
            this.txtDescription.TabIndex = 6;
            // 
            // grpSteps
            // 
            this.grpSteps.Controls.Add(this.cboStep3Role);
            this.grpSteps.Controls.Add(this.lblStep3);
            this.grpSteps.Controls.Add(this.cboStep2Role);
            this.grpSteps.Controls.Add(this.lblStep2);
            this.grpSteps.Controls.Add(this.cboStep1Role);
            this.grpSteps.Controls.Add(this.lblStep1);
            this.grpSteps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSteps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.grpSteps.Location = new System.Drawing.Point(24, 260);
            this.grpSteps.Name = "grpSteps";
            this.grpSteps.Size = new System.Drawing.Size(466, 175);
            this.grpSteps.TabIndex = 7;
            this.grpSteps.TabStop = false;
            this.grpSteps.Text = "Sequential Approval Steps";
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStep1.Location = new System.Drawing.Point(16, 28);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(126, 15);
            this.lblStep1.TabIndex = 0;
            this.lblStep1.Text = "Step 1 Initial Reviewer:";
            // 
            // cboStep1Role
            // 
            this.cboStep1Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep1Role.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStep1Role.FormattingEnabled = true;
            this.cboStep1Role.Location = new System.Drawing.Point(180, 24);
            this.cboStep1Role.Name = "cboStep1Role";
            this.cboStep1Role.Size = new System.Drawing.Size(265, 24);
            this.cboStep1Role.TabIndex = 1;
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStep2.Location = new System.Drawing.Point(16, 75);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(147, 15);
            this.lblStep2.TabIndex = 2;
            this.lblStep2.Text = "Step 2 Primary Authorizer:";
            // 
            // cboStep2Role
            // 
            this.cboStep2Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep2Role.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStep2Role.FormattingEnabled = true;
            this.cboStep2Role.Location = new System.Drawing.Point(180, 71);
            this.cboStep2Role.Name = "cboStep2Role";
            this.cboStep2Role.Size = new System.Drawing.Size(265, 24);
            this.cboStep2Role.TabIndex = 3;
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStep3.Location = new System.Drawing.Point(16, 122);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(155, 15);
            this.lblStep3.TabIndex = 4;
            this.lblStep3.Text = "Step 3 Final Clearer / Exec:";
            // 
            // cboStep3Role
            // 
            this.cboStep3Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep3Role.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStep3Role.FormattingEnabled = true;
            this.cboStep3Role.Location = new System.Drawing.Point(180, 118);
            this.cboStep3Role.Name = "cboStep3Role";
            this.cboStep3Role.Size = new System.Drawing.Size(265, 24);
            this.cboStep3Role.TabIndex = 5;
            // 
            // chkSequential
            // 
            this.chkSequential.AutoSize = true;
            this.chkSequential.Checked = true;
            this.chkSequential.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSequential.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSequential.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.chkSequential.Location = new System.Drawing.Point(24, 445);
            this.chkSequential.Name = "chkSequential";
            this.chkSequential.Size = new System.Drawing.Size(236, 19);
            this.chkSequential.TabIndex = 8;
            this.chkSequential.Text = "Strict Sequential Gate (No Skip Allowed)";
            this.chkSequential.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.chkActive.Location = new System.Drawing.Point(24, 470);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(183, 19);
            this.chkActive.TabIndex = 9;
            this.chkActive.Text = "Workflow Active & Operational";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(270, 505);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save Workflow";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancel.Location = new System.Drawing.Point(400, 505);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ApprovalWorkflowDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 555);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.chkSequential);
            this.Controls.Add(this.grpSteps);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cboRequestType);
            this.Controls.Add(this.lblRequestType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApprovalWorkflowDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Approval Workflow";
            this.grpSteps.ResumeLayout(false);
            this.grpSteps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.ComboBox cboRequestType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpSteps;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.ComboBox cboStep1Role;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.ComboBox cboStep2Role;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.ComboBox cboStep3Role;
        private System.Windows.Forms.CheckBox chkSequential;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
