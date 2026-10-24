namespace ELMS.Forms
{
    partial class EmployeeCreateDialog
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
            this.lblEmpCode = new System.Windows.Forms.Label();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
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
            this.pnlTop.Size = new System.Drawing.Size(520, 76);
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
            this.lblSubtitle.Size = new System.Drawing.Size(350, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Provision personal profile, job position, and system credentials.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Register New Employee";
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.AutoSize = true;
            this.lblEmpCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmpCode.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblEmpCode.Location = new System.Drawing.Point(24, 90);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(92, 15);
            this.lblEmpCode.TabIndex = 1;
            this.lblEmpCode.Text = "Employee Code";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtEmpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEmpCode.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.txtEmpCode.Location = new System.Drawing.Point(24, 108);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.ReadOnly = true;
            this.txtEmpCode.Size = new System.Drawing.Size(130, 24);
            this.txtEmpCode.TabIndex = 2;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblGender.Location = new System.Drawing.Point(170, 90);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(48, 15);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] { "Male", "Female" });
            this.cboGender.Location = new System.Drawing.Point(170, 108);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(140, 24);
            this.cboGender.TabIndex = 4;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHireDate.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblHireDate.Location = new System.Drawing.Point(326, 90);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(60, 15);
            this.lblHireDate.TabIndex = 5;
            this.lblHireDate.Text = "Hire Date";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.CustomFormat = "yyyy-MM-dd";
            this.dtpHireDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHireDate.Location = new System.Drawing.Point(326, 108);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(170, 24);
            this.dtpHireDate.TabIndex = 6;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblFirstName.Location = new System.Drawing.Point(24, 146);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(68, 15);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFirstName.Location = new System.Drawing.Point(24, 166);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "e.g. Arthur";
            this.txtFirstName.Size = new System.Drawing.Size(226, 24);
            this.txtFirstName.TabIndex = 8;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblLastName.Location = new System.Drawing.Point(270, 146);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(66, 15);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLastName.Location = new System.Drawing.Point(270, 166);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "e.g. Pendelton";
            this.txtLastName.Size = new System.Drawing.Size(226, 24);
            this.txtLastName.TabIndex = 10;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDept.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDept.Location = new System.Drawing.Point(24, 204);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(76, 15);
            this.lblDept.TabIndex = 11;
            this.lblDept.Text = "Department";
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(24, 224);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(226, 24);
            this.cboDept.TabIndex = 12;
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJobTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblJobTitle.Location = new System.Drawing.Point(270, 204);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(54, 15);
            this.lblJobTitle.TabIndex = 13;
            this.lblJobTitle.Text = "Job Title";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtJobTitle.Location = new System.Drawing.Point(270, 224);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.PlaceholderText = "e.g. Senior Specialist";
            this.txtJobTitle.Size = new System.Drawing.Size(226, 24);
            this.txtJobTitle.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblEmail.Location = new System.Drawing.Point(24, 262);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(91, 15);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Corporate Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(24, 282);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "firstname.lastname@elms.corp";
            this.txtEmail.Size = new System.Drawing.Size(472, 24);
            this.txtEmail.TabIndex = 16;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblPassword.Location = new System.Drawing.Point(24, 320);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(127, 15);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Initial Login Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.Location = new System.Drawing.Point(24, 340);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(226, 24);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.Text = "password123";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblRole.Location = new System.Drawing.Point(270, 320);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(107, 15);
            this.lblRole.TabIndex = 19;
            this.lblRole.Text = "Assigned RBAC Role";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(270, 340);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(226, 24);
            this.cboRole.TabIndex = 20;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 396);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlFooter.Size = new System.Drawing.Size(520, 58);
            this.pnlFooter.TabIndex = 21;
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
            this.btnCancel.Location = new System.Drawing.Point(280, 12);
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
            this.btnSave.Location = new System.Drawing.Point(384, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Create Employee";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EmployeeCreateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 454);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.lblJobTitle);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.lblEmpCode);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeCreateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Employee";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblEmpCode;
        private System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}