namespace ELMS.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarNav = new System.Windows.Forms.Panel();
            this.btnNavRoles = new System.Windows.Forms.Button();
            this.btnNavApprovals = new System.Windows.Forms.Button();
            this.btnNavClearances = new System.Windows.Forms.Button();
            this.btnNavConfigurations = new System.Windows.Forms.Button();
            this.pnlConfigSubNav = new System.Windows.Forms.Panel();
            this.btnConfigTabClearance = new System.Windows.Forms.Button();
            this.btnConfigTabLeave = new System.Windows.Forms.Button();
            this.btnConfigTabApproval = new System.Windows.Forms.Button();
            this.btnNavDepartments = new System.Windows.Forms.Button();
            this.btnNavLedger = new System.Windows.Forms.Button();
            this.btnNavEmployees = new System.Windows.Forms.Button();
            this.btnNavLeaves = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlSidebarBottom = new System.Windows.Forms.Panel();
            this.pnlUserCard = new System.Windows.Forms.Panel();
            this.lblDropdownArrow = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserAvatar = new System.Windows.Forms.Label();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrandLogo = new System.Windows.Forms.Label();
            this.menuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBreadcrumb = new System.Windows.Forms.Label();
            this.btnToggleSidebar = new System.Windows.Forms.Button();
            this.pnlContentHost = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlDashTabs = new System.Windows.Forms.Panel();
            this.btnTabLeaves = new System.Windows.Forms.Button();
            this.btnTabEmployees = new System.Windows.Forms.Button();
            this.pnlTabEmployeesView = new System.Windows.Forms.Panel();
            this.pnlEmpContent = new System.Windows.Forms.Panel();
            this.cardEmpDemographics = new System.Windows.Forms.Panel();
            this.pnlDemographicsContainer = new System.Windows.Forms.Panel();
            this.lblDemoSub = new System.Windows.Forms.Label();
            this.lblDemoTitle = new System.Windows.Forms.Label();
            this.cardEmpDeptChart = new System.Windows.Forms.Panel();
            this.pnlEmpDeptBarContainer = new System.Windows.Forms.Panel();
            this.lblDeptChartSub = new System.Windows.Forms.Label();
            this.lblDeptChartTitle = new System.Windows.Forms.Label();
            this.pnlEmpKpiRow = new System.Windows.Forms.Panel();
            this.cardEmpKpi4 = new System.Windows.Forms.Panel();
            this.lblEmpKpi4Sub = new System.Windows.Forms.Label();
            this.lblEmpKpi4Val = new System.Windows.Forms.Label();
            this.lblEmpKpi4Title = new System.Windows.Forms.Label();
            this.cardEmpKpi3 = new System.Windows.Forms.Panel();
            this.lblEmpKpi3Sub = new System.Windows.Forms.Label();
            this.lblEmpKpi3Val = new System.Windows.Forms.Label();
            this.lblEmpKpi3Title = new System.Windows.Forms.Label();
            this.cardEmpKpi2 = new System.Windows.Forms.Panel();
            this.lblEmpKpi2Sub = new System.Windows.Forms.Label();
            this.lblEmpKpi2Val = new System.Windows.Forms.Label();
            this.lblEmpKpi2Title = new System.Windows.Forms.Label();
            this.cardEmpKpi1 = new System.Windows.Forms.Panel();
            this.lblEmpKpi1Sub = new System.Windows.Forms.Label();
            this.lblEmpKpi1Val = new System.Windows.Forms.Label();
            this.lblEmpKpi1Title = new System.Windows.Forms.Label();
            this.pnlTabLeavesView = new System.Windows.Forms.Panel();
            this.cardLeavePieChart = new System.Windows.Forms.Panel();
            this.pnlPieContainer = new System.Windows.Forms.Panel();
            this.lblPieChartSub = new System.Windows.Forms.Label();
            this.lblPieChartTitle = new System.Windows.Forms.Label();
            this.pnlLeaveKpiRow = new System.Windows.Forms.Panel();
            this.cardLeaveKpi4 = new System.Windows.Forms.Panel();
            this.lblLeaveKpi4Sub = new System.Windows.Forms.Label();
            this.lblLeaveKpi4Val = new System.Windows.Forms.Label();
            this.lblLeaveKpi4Title = new System.Windows.Forms.Label();
            this.cardLeaveKpi3 = new System.Windows.Forms.Panel();
            this.lblLeaveKpi3Sub = new System.Windows.Forms.Label();
            this.lblLeaveKpi3Val = new System.Windows.Forms.Label();
            this.lblLeaveKpi3Title = new System.Windows.Forms.Label();
            this.cardLeaveKpi2 = new System.Windows.Forms.Panel();
            this.lblLeaveKpi2Sub = new System.Windows.Forms.Label();
            this.lblLeaveKpi2Val = new System.Windows.Forms.Label();
            this.lblLeaveKpi2Title = new System.Windows.Forms.Label();
            this.cardLeaveKpi1 = new System.Windows.Forms.Panel();
            this.lblLeaveKpi1Sub = new System.Windows.Forms.Label();
            this.lblLeaveKpi1Val = new System.Windows.Forms.Label();
            this.lblLeaveKpi1Title = new System.Windows.Forms.Label();
            this.pnlGridView = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlLeaveSubNav = new System.Windows.Forms.Panel();
            this.btnLeaveTabRequests = new System.Windows.Forms.Button();
            this.btnLeaveTabApprovals = new System.Windows.Forms.Button();
            this.btnLeaveTabTypes = new System.Windows.Forms.Button();
            this.btnLeaveTabEntitlements = new System.Windows.Forms.Button();
            this.btnToolbarAction = new System.Windows.Forms.Button();
            this.cboFilter2 = new System.Windows.Forms.ComboBox();
            this.cboFilter1 = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ucConfigurations = new ELMS.Forms.ConfigurationsView();
            this.cboFilter3 = new System.Windows.Forms.ComboBox();
            this.btnSecondaryAction = new System.Windows.Forms.Button();
            this.pnlReportMetrics = new System.Windows.Forms.Panel();
            this.btnToggleSelectAll = new System.Windows.Forms.Button();
            this.lblReportSelectedCount = new System.Windows.Forms.Label();
            this.pnlKpiSummaryBadges = new System.Windows.Forms.Panel();
            this.lblReportKpiStaff = new System.Windows.Forms.Label();
            this.lblReportKpiAllocated = new System.Windows.Forms.Label();
            this.lblReportKpiUsed = new System.Windows.Forms.Label();
            this.lblReportKpiBalance = new System.Windows.Forms.Label();
            this.lblReportKpiUtil = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarNav.SuspendLayout();
            this.pnlSidebarBottom.SuspendLayout();
            this.pnlUserCard.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.menuUser.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContentHost.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlDashTabs.SuspendLayout();
            this.pnlTabEmployeesView.SuspendLayout();
            this.pnlEmpContent.SuspendLayout();
            this.cardEmpDemographics.SuspendLayout();
            this.cardEmpDeptChart.SuspendLayout();
            this.pnlEmpKpiRow.SuspendLayout();
            this.cardEmpKpi4.SuspendLayout();
            this.cardEmpKpi3.SuspendLayout();
            this.cardEmpKpi2.SuspendLayout();
            this.cardEmpKpi1.SuspendLayout();
            this.pnlTabLeavesView.SuspendLayout();
            this.cardLeavePieChart.SuspendLayout();
            this.pnlLeaveKpiRow.SuspendLayout();
            this.cardLeaveKpi4.SuspendLayout();
            this.cardLeaveKpi3.SuspendLayout();
            this.cardLeaveKpi2.SuspendLayout();
            this.cardLeaveKpi1.SuspendLayout();
            this.pnlGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlSidebarNav);
            this.pnlSidebar.Controls.Add(this.pnlSidebarBottom);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 750);
            this.pnlSidebar.TabIndex = 0;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // pnlSidebarNav
            // 
            this.pnlSidebarNav.Controls.Add(this.btnNavLedger);
            this.pnlSidebarNav.Controls.Add(this.btnNavConfigurations);
            this.pnlSidebarNav.Controls.Add(this.btnNavClearances);
            this.pnlSidebarNav.Controls.Add(this.btnNavApprovals);
            this.pnlSidebarNav.Controls.Add(this.btnNavLeaves);
            this.pnlSidebarNav.Controls.Add(this.btnNavRoles);
            this.pnlSidebarNav.Controls.Add(this.btnNavDepartments);
            this.pnlSidebarNav.Controls.Add(this.btnNavEmployees);
            this.pnlSidebarNav.Controls.Add(this.btnNavDashboard);
            this.pnlSidebarNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebarNav.Location = new System.Drawing.Point(0, 68);
            this.pnlSidebarNav.Name = "pnlSidebarNav";
            this.pnlSidebarNav.Padding = new System.Windows.Forms.Padding(10, 14, 10, 14);
            this.pnlSidebarNav.Size = new System.Drawing.Size(230, 614);
            this.pnlSidebarNav.TabIndex = 1;
            // 
            // btnNavRoles
            // 
            this.btnNavRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRoles.FlatAppearance.BorderSize = 0;
            this.btnNavRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRoles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavRoles.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavRoles.Location = new System.Drawing.Point(10, 140);
            this.btnNavRoles.Name = "btnNavRoles";
            this.btnNavRoles.Size = new System.Drawing.Size(210, 42);
            this.btnNavRoles.TabIndex = 3;
            this.btnNavRoles.Text = "User Roles";
            this.btnNavRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRoles.UseVisualStyleBackColor = true;
            this.btnNavRoles.Click += new System.EventHandler(this.btnNavRoles_Click);
            // 
            // btnNavLedger
            // 
            this.btnNavLedger.Location = new System.Drawing.Point(10, 182);
            this.btnNavLedger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLedger.FlatAppearance.BorderSize = 0;
            this.btnNavLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLedger.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLedger.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavLedger.Name = "btnNavLedger";
            this.btnNavLedger.Size = new System.Drawing.Size(210, 42);
            this.btnNavLedger.TabIndex = 4;
            this.btnNavLedger.Text = "Reports & Analytics";
            this.btnNavLedger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLedger.UseVisualStyleBackColor = true;
            this.btnNavLedger.Click += new System.EventHandler(this.btnNavLedger_Click);
            // 
            // btnNavDepartments
            // 
            this.btnNavDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDepartments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDepartments.FlatAppearance.BorderSize = 0;
            this.btnNavDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDepartments.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavDepartments.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavDepartments.Location = new System.Drawing.Point(10, 98);
            this.btnNavDepartments.Name = "btnNavDepartments";
            this.btnNavDepartments.Size = new System.Drawing.Size(210, 42);
            this.btnNavDepartments.TabIndex = 2;
            this.btnNavDepartments.Text = "Departments";
            this.btnNavDepartments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDepartments.UseVisualStyleBackColor = true;
            this.btnNavDepartments.Click += new System.EventHandler(this.btnNavDepartments_Click);
            // 
            // btnNavEmployees
            // 
            this.btnNavEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavEmployees.FlatAppearance.BorderSize = 0;
            this.btnNavEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEmployees.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavEmployees.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavEmployees.Location = new System.Drawing.Point(10, 98);
            this.btnNavEmployees.Name = "btnNavEmployees";
            this.btnNavEmployees.Size = new System.Drawing.Size(210, 42);
            this.btnNavEmployees.TabIndex = 2;
            this.btnNavEmployees.Text = "Employees";
            this.btnNavEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEmployees.UseVisualStyleBackColor = true;
            this.btnNavEmployees.Click += new System.EventHandler(this.btnNavEmployees_Click);
            // 
            // btnNavConfigurations
            // 
            this.btnNavConfigurations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavConfigurations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavConfigurations.FlatAppearance.BorderSize = 0;
            this.btnNavConfigurations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavConfigurations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavConfigurations.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavConfigurations.Location = new System.Drawing.Point(10, 224);
            this.btnNavConfigurations.Name = "btnNavConfigurations";
            this.btnNavConfigurations.Size = new System.Drawing.Size(210, 42);
            this.btnNavConfigurations.TabIndex = 6;
            this.btnNavConfigurations.Text = "Configurations";
            this.btnNavConfigurations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavConfigurations.UseVisualStyleBackColor = true;
            this.btnNavConfigurations.Click += new System.EventHandler(this.btnNavConfigurations_Click);
            // 
            // btnNavApprovals
            // 
            this.btnNavApprovals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavApprovals.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavApprovals.FlatAppearance.BorderSize = 0;
            this.btnNavApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavApprovals.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavApprovals.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavApprovals.Location = new System.Drawing.Point(10, 140);
            this.btnNavApprovals.Name = "btnNavApprovals";
            this.btnNavApprovals.Size = new System.Drawing.Size(210, 42);
            this.btnNavApprovals.TabIndex = 4;
            this.btnNavApprovals.Text = "Approvals";
            this.btnNavApprovals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavApprovals.UseVisualStyleBackColor = true;
            this.btnNavApprovals.Click += new System.EventHandler(this.btnNavApprovals_Click);
            // 
            // btnNavClearances
            // 
            this.btnNavClearances.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavClearances.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavClearances.FlatAppearance.BorderSize = 0;
            this.btnNavClearances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavClearances.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavClearances.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavClearances.Location = new System.Drawing.Point(10, 182);
            this.btnNavClearances.Name = "btnNavClearances";
            this.btnNavClearances.Size = new System.Drawing.Size(210, 42);
            this.btnNavClearances.TabIndex = 5;
            this.btnNavClearances.Text = "Clearance Desk";
            this.btnNavClearances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavClearances.UseVisualStyleBackColor = true;
            this.btnNavClearances.Click += new System.EventHandler(this.btnNavClearances_Click);
            // 
            // btnNavLeaves
            // 
            this.btnNavLeaves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLeaves.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLeaves.FlatAppearance.BorderSize = 0;
            this.btnNavLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLeaves.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLeaves.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavLeaves.Location = new System.Drawing.Point(10, 56);
            this.btnNavLeaves.Name = "btnNavLeaves";
            this.btnNavLeaves.Size = new System.Drawing.Size(210, 42);
            this.btnNavLeaves.TabIndex = 1;
            this.btnNavLeaves.Text = "Leave Requests";
            this.btnNavLeaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLeaves.UseVisualStyleBackColor = true;
            this.btnNavLeaves.Click += new System.EventHandler(this.btnNavLeaves_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnNavDashboard.Location = new System.Drawing.Point(10, 14);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(210, 42);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // pnlSidebarBottom
            // 
            this.pnlSidebarBottom.Controls.Add(this.pnlUserCard);
            this.pnlSidebarBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarBottom.Location = new System.Drawing.Point(0, 682);
            this.pnlSidebarBottom.Name = "pnlSidebarBottom";
            this.pnlSidebarBottom.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSidebarBottom.Size = new System.Drawing.Size(230, 68);
            this.pnlSidebarBottom.TabIndex = 2;
            this.pnlSidebarBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebarBottom_Paint);
            // 
            // pnlUserCard
            // 
            this.pnlUserCard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlUserCard.Controls.Add(this.lblDropdownArrow);
            this.pnlUserCard.Controls.Add(this.lblUserRole);
            this.pnlUserCard.Controls.Add(this.lblUserName);
            this.pnlUserCard.Controls.Add(this.lblUserAvatar);
            this.pnlUserCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlUserCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserCard.Location = new System.Drawing.Point(8, 8);
            this.pnlUserCard.Name = "pnlUserCard";
            this.pnlUserCard.Size = new System.Drawing.Size(214, 52);
            this.pnlUserCard.TabIndex = 0;
            this.pnlUserCard.Click += new System.EventHandler(this.UserCard_Click);
            // 
            // lblDropdownArrow
            // 
            this.lblDropdownArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDropdownArrow.AutoSize = true;
            this.lblDropdownArrow.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDropdownArrow.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDropdownArrow.Location = new System.Drawing.Point(192, 17);
            this.lblDropdownArrow.Name = "lblDropdownArrow";
            this.lblDropdownArrow.Size = new System.Drawing.Size(18, 19);
            this.lblDropdownArrow.TabIndex = 3;
            this.lblDropdownArrow.Text = "▾";
            this.lblDropdownArrow.Click += new System.EventHandler(this.UserCard_Click);
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUserRole.Location = new System.Drawing.Point(48, 28);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(140, 18);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Administrator";
            this.lblUserRole.Click += new System.EventHandler(this.UserCard_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUserName.Location = new System.Drawing.Point(48, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(140, 20);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Arthur Pendelton";
            this.lblUserName.Click += new System.EventHandler(this.UserCard_Click);
            // 
            // lblUserAvatar
            // 
            this.lblUserAvatar.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.lblUserAvatar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserAvatar.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblUserAvatar.Location = new System.Drawing.Point(6, 7);
            this.lblUserAvatar.Name = "lblUserAvatar";
            this.lblUserAvatar.Size = new System.Drawing.Size(36, 36);
            this.lblUserAvatar.TabIndex = 0;
            this.lblUserAvatar.Text = "AP";
            this.lblUserAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserAvatar.Click += new System.EventHandler(this.UserCard_Click);
            this.lblUserAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.lblUserAvatar_Paint);
            // 
            // pnlBrand
            // 
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.lblBrandLogo);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(230, 68);
            this.pnlBrand.TabIndex = 0;
            this.pnlBrand.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBrand_Paint);
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBrandSub.Location = new System.Drawing.Point(16, 42);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(198, 18);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "LEAVE MANAGEMENT";
            // 
            // lblBrandLogo
            // 
            this.lblBrandLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrandLogo.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblBrandLogo.Location = new System.Drawing.Point(14, 10);
            this.lblBrandLogo.Name = "lblBrandLogo";
            this.lblBrandLogo.Size = new System.Drawing.Size(200, 32);
            this.lblBrandLogo.TabIndex = 0;
            this.lblBrandLogo.Text = "ELMS";
            // 
            // menuUser
            // 
            this.menuUser.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProfile,
            this.menuItemLogout});
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(150, 56);
            // 
            // menuItemProfile
            // 
            this.menuItemProfile.Name = "menuItemProfile";
            this.menuItemProfile.Size = new System.Drawing.Size(149, 26);
            this.menuItemProfile.Text = "My Profile";
            this.menuItemProfile.Click += new System.EventHandler(this.menuItemProfile_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(149, 26);
            this.menuItemLogout.Text = "Log Out";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlMain.Controls.Add(this.pnlContentHost);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(230, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(970, 750);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblBreadcrumb);
            this.pnlHeader.Controls.Add(this.btnToggleSidebar);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(970, 48);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblBreadcrumb
            // 
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblBreadcrumb.Location = new System.Drawing.Point(52, 14);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(188, 21);
            this.lblBreadcrumb.TabIndex = 1;
            this.lblBreadcrumb.Text = "Dashboard  /  Employees";
            // 
            // btnToggleSidebar
            // 
            this.btnToggleSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleSidebar.FlatAppearance.BorderSize = 0;
            this.btnToggleSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleSidebar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnToggleSidebar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnToggleSidebar.Location = new System.Drawing.Point(8, 7);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(34, 34);
            this.btnToggleSidebar.TabIndex = 0;
            this.btnToggleSidebar.Text = "☰";
            this.btnToggleSidebar.UseVisualStyleBackColor = true;
            this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
            // 
            // pnlContentHost
            // 
            this.pnlContentHost.Controls.Add(this.pnlDashboard);
            this.pnlContentHost.Controls.Add(this.pnlGridView);
            this.pnlContentHost.Controls.Add(this.ucConfigurations);
            this.pnlContentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentHost.Location = new System.Drawing.Point(0, 48);
            this.pnlContentHost.Name = "pnlContentHost";
            this.pnlContentHost.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContentHost.Size = new System.Drawing.Size(970, 702);
            this.pnlContentHost.TabIndex = 1;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.AutoScroll = true;
            this.pnlDashboard.Controls.Add(this.pnlTabEmployeesView);
            this.pnlDashboard.Controls.Add(this.pnlTabLeavesView);
            this.pnlDashboard.Controls.Add(this.pnlDashTabs);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(20, 20);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(930, 662);
            this.pnlDashboard.TabIndex = 0;
            // 
            // pnlDashTabs
            // 
            this.pnlDashTabs.Controls.Add(this.btnTabLeaves);
            this.pnlDashTabs.Controls.Add(this.btnTabEmployees);
            this.pnlDashTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlDashTabs.Name = "pnlDashTabs";
            this.pnlDashTabs.Size = new System.Drawing.Size(930, 44);
            this.pnlDashTabs.TabIndex = 0;
            // 
            // btnTabLeaves
            // 
            this.btnTabLeaves.BackColor = System.Drawing.Color.Transparent;
            this.btnTabLeaves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabLeaves.FlatAppearance.BorderSize = 0;
            this.btnTabLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabLeaves.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTabLeaves.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnTabLeaves.Location = new System.Drawing.Point(125, 6);
            this.btnTabLeaves.Name = "btnTabLeaves";
            this.btnTabLeaves.Size = new System.Drawing.Size(120, 32);
            this.btnTabLeaves.TabIndex = 1;
            this.btnTabLeaves.Text = "Leaves";
            this.btnTabLeaves.UseVisualStyleBackColor = false;
            this.btnTabLeaves.Click += new System.EventHandler(this.btnTabLeaves_Click);
            // 
            // btnTabEmployees
            // 
            this.btnTabEmployees.BackColor = System.Drawing.Color.White;
            this.btnTabEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabEmployees.FlatAppearance.BorderSize = 0;
            this.btnTabEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabEmployees.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabEmployees.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnTabEmployees.Location = new System.Drawing.Point(0, 6);
            this.btnTabEmployees.Name = "btnTabEmployees";
            this.btnTabEmployees.Size = new System.Drawing.Size(120, 32);
            this.btnTabEmployees.TabIndex = 0;
            this.btnTabEmployees.Text = "Employees";
            this.btnTabEmployees.UseVisualStyleBackColor = false;
            this.btnTabEmployees.Click += new System.EventHandler(this.btnTabEmployees_Click);
            // 
            // pnlTabEmployeesView
            // 
            this.pnlTabEmployeesView.Controls.Add(this.pnlEmpContent);
            this.pnlTabEmployeesView.Controls.Add(this.pnlEmpKpiRow);
            this.pnlTabEmployeesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabEmployeesView.Location = new System.Drawing.Point(0, 44);
            this.pnlTabEmployeesView.Name = "pnlTabEmployeesView";
            this.pnlTabEmployeesView.Size = new System.Drawing.Size(930, 618);
            this.pnlTabEmployeesView.TabIndex = 1;
            // 
            // pnlEmpContent
            // 
            this.pnlEmpContent.Controls.Add(this.cardEmpDeptChart);
            this.pnlEmpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmpContent.Location = new System.Drawing.Point(0, 106);
            this.pnlEmpContent.Name = "pnlEmpContent";
            this.pnlEmpContent.Size = new System.Drawing.Size(930, 512);
            this.pnlEmpContent.TabIndex = 1;
            this.pnlEmpContent.Resize += new System.EventHandler(this.pnlEmpContent_Resize);
            // 
            // cardEmpDemographics
            // 
            this.cardEmpDemographics.BackColor = System.Drawing.Color.White;
            this.cardEmpDemographics.Controls.Add(this.pnlDemographicsContainer);
            this.cardEmpDemographics.Controls.Add(this.lblDemoSub);
            this.cardEmpDemographics.Controls.Add(this.lblDemoTitle);
            this.cardEmpDemographics.Location = new System.Drawing.Point(475, 0);
            this.cardEmpDemographics.Name = "cardEmpDemographics";
            this.cardEmpDemographics.Padding = new System.Windows.Forms.Padding(18);
            this.cardEmpDemographics.Size = new System.Drawing.Size(455, 500);
            this.cardEmpDemographics.TabIndex = 1;
            this.cardEmpDemographics.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // pnlDemographicsContainer
            // 
            this.pnlDemographicsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDemographicsContainer.Location = new System.Drawing.Point(18, 64);
            this.pnlDemographicsContainer.Name = "pnlDemographicsContainer";
            this.pnlDemographicsContainer.Size = new System.Drawing.Size(419, 418);
            this.pnlDemographicsContainer.TabIndex = 2;
            
            // 
            // lblDemoSub
            // 
            this.lblDemoSub.AutoSize = true;
            this.lblDemoSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDemoSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDemoSub.Location = new System.Drawing.Point(18, 38);
            this.lblDemoSub.Name = "lblDemoSub";
            this.lblDemoSub.Size = new System.Drawing.Size(262, 19);
            this.lblDemoSub.TabIndex = 1;
            this.lblDemoSub.Text = "Gender diversity and active work availability";
            // 
            // lblDemoTitle
            // 
            this.lblDemoTitle.AutoSize = true;
            this.lblDemoTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDemoTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDemoTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDemoTitle.Name = "lblDemoTitle";
            this.lblDemoTitle.Size = new System.Drawing.Size(326, 25);
            this.lblDemoTitle.TabIndex = 0;
            this.lblDemoTitle.Text = "Workforce Demographics & Status";
            // 
            // cardEmpDeptChart
            // 
            this.cardEmpDeptChart.BackColor = System.Drawing.Color.White;
            this.cardEmpDeptChart.Controls.Add(this.pnlEmpDeptBarContainer);
            this.cardEmpDeptChart.Controls.Add(this.lblDeptChartSub);
            this.cardEmpDeptChart.Controls.Add(this.lblDeptChartTitle);
            this.cardEmpDeptChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardEmpDeptChart.Location = new System.Drawing.Point(0, 0);
            this.cardEmpDeptChart.Name = "cardEmpDeptChart";
            this.cardEmpDeptChart.Padding = new System.Windows.Forms.Padding(20);
            this.cardEmpDeptChart.Size = new System.Drawing.Size(930, 512);
            this.cardEmpDeptChart.TabIndex = 0;
            this.cardEmpDeptChart.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // pnlEmpDeptBarContainer
            // 
            this.pnlEmpDeptBarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmpDeptBarContainer.Location = new System.Drawing.Point(20, 64);
            this.pnlEmpDeptBarContainer.Name = "pnlEmpDeptBarContainer";
            this.pnlEmpDeptBarContainer.Size = new System.Drawing.Size(890, 428);
            this.pnlEmpDeptBarContainer.TabIndex = 2;
            this.pnlEmpDeptBarContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEmpDeptBarContainer_Paint);
            this.pnlEmpDeptBarContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlEmpDeptBarContainer_MouseMove);
            this.pnlEmpDeptBarContainer.MouseLeave += new System.EventHandler(this.pnlEmpDeptBarContainer_MouseLeave);
            // 
            // lblDeptChartSub
            // 
            this.lblDeptChartSub.AutoSize = true;
            this.lblDeptChartSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDeptChartSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDeptChartSub.Location = new System.Drawing.Point(18, 38);
            this.lblDeptChartSub.Name = "lblDeptChartSub";
            this.lblDeptChartSub.Size = new System.Drawing.Size(268, 19);
            this.lblDeptChartSub.TabIndex = 1;
            this.lblDeptChartSub.Text = "Personnel allocation by operational department";
            // 
            // lblDeptChartTitle
            // 
            this.lblDeptChartTitle.AutoSize = true;
            this.lblDeptChartTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptChartTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDeptChartTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDeptChartTitle.Name = "lblDeptChartTitle";
            this.lblDeptChartTitle.Size = new System.Drawing.Size(325, 25);
            this.lblDeptChartTitle.TabIndex = 0;
            this.lblDeptChartTitle.Text = "Department Headcount Distribution";
            // 
            // pnlEmpKpiRow
            // 
            this.pnlEmpKpiRow.Controls.Add(this.cardEmpKpi4);
            this.pnlEmpKpiRow.Controls.Add(this.cardEmpKpi3);
            this.pnlEmpKpiRow.Controls.Add(this.cardEmpKpi2);
            this.pnlEmpKpiRow.Controls.Add(this.cardEmpKpi1);
            this.pnlEmpKpiRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEmpKpiRow.Location = new System.Drawing.Point(0, 0);
            this.pnlEmpKpiRow.Name = "pnlEmpKpiRow";
            this.pnlEmpKpiRow.Size = new System.Drawing.Size(930, 106);
            this.pnlEmpKpiRow.TabIndex = 0;
            this.pnlEmpKpiRow.Resize += new System.EventHandler(this.pnlEmpKpiRow_Resize);
            // 
            // cardEmpKpi4
            // 
            this.cardEmpKpi4.BackColor = System.Drawing.Color.White;
            this.cardEmpKpi4.Controls.Add(this.lblEmpKpi4Sub);
            this.cardEmpKpi4.Controls.Add(this.lblEmpKpi4Val);
            this.cardEmpKpi4.Controls.Add(this.lblEmpKpi4Title);
            this.cardEmpKpi4.Location = new System.Drawing.Point(690, 0);
            this.cardEmpKpi4.Name = "cardEmpKpi4";
            this.cardEmpKpi4.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardEmpKpi4.Size = new System.Drawing.Size(220, 96);
            this.cardEmpKpi4.TabIndex = 3;
            this.cardEmpKpi4.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblEmpKpi4Sub
            // 
            this.lblEmpKpi4Sub.AutoSize = true;
            this.lblEmpKpi4Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmpKpi4Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi4Sub.Location = new System.Drawing.Point(16, 68);
            this.lblEmpKpi4Sub.Name = "lblEmpKpi4Sub";
            this.lblEmpKpi4Sub.Size = new System.Drawing.Size(107, 19);
            this.lblEmpKpi4Sub.TabIndex = 2;
            this.lblEmpKpi4Sub.Text = "Operating Units";
            // 
            // lblEmpKpi4Val
            // 
            this.lblEmpKpi4Val.AutoSize = true;
            this.lblEmpKpi4Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi4Val.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEmpKpi4Val.Location = new System.Drawing.Point(14, 30);
            this.lblEmpKpi4Val.Name = "lblEmpKpi4Val";
            this.lblEmpKpi4Val.Size = new System.Drawing.Size(39, 46);
            this.lblEmpKpi4Val.TabIndex = 1;
            this.lblEmpKpi4Val.Text = "5";
            // 
            // lblEmpKpi4Title
            // 
            this.lblEmpKpi4Title.AutoSize = true;
            this.lblEmpKpi4Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi4Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi4Title.Location = new System.Drawing.Point(16, 12);
            this.lblEmpKpi4Title.Name = "lblEmpKpi4Title";
            this.lblEmpKpi4Title.Size = new System.Drawing.Size(108, 20);
            this.lblEmpKpi4Title.TabIndex = 0;
            this.lblEmpKpi4Title.Text = "DEPARTMENTS";
            // 
            // cardEmpKpi3
            // 
            this.cardEmpKpi3.BackColor = System.Drawing.Color.White;
            this.cardEmpKpi3.Controls.Add(this.lblEmpKpi3Sub);
            this.cardEmpKpi3.Controls.Add(this.lblEmpKpi3Val);
            this.cardEmpKpi3.Controls.Add(this.lblEmpKpi3Title);
            this.cardEmpKpi3.Location = new System.Drawing.Point(460, 0);
            this.cardEmpKpi3.Name = "cardEmpKpi3";
            this.cardEmpKpi3.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardEmpKpi3.Size = new System.Drawing.Size(220, 96);
            this.cardEmpKpi3.TabIndex = 2;
            this.cardEmpKpi3.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblEmpKpi3Sub
            // 
            this.lblEmpKpi3Sub.AutoSize = true;
            this.lblEmpKpi3Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmpKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblEmpKpi3Sub.Location = new System.Drawing.Point(16, 68);
            this.lblEmpKpi3Sub.Name = "lblEmpKpi3Sub";
            this.lblEmpKpi3Sub.Size = new System.Drawing.Size(117, 19);
            this.lblEmpKpi3Sub.TabIndex = 2;
            this.lblEmpKpi3Sub.Text = "Available / Online";
            // 
            // lblEmpKpi3Val
            // 
            this.lblEmpKpi3Val.AutoSize = true;
            this.lblEmpKpi3Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi3Val.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblEmpKpi3Val.Location = new System.Drawing.Point(14, 30);
            this.lblEmpKpi3Val.Name = "lblEmpKpi3Val";
            this.lblEmpKpi3Val.Size = new System.Drawing.Size(58, 46);
            this.lblEmpKpi3Val.TabIndex = 1;
            this.lblEmpKpi3Val.Text = "18";
            // 
            // lblEmpKpi3Title
            // 
            this.lblEmpKpi3Title.AutoSize = true;
            this.lblEmpKpi3Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi3Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi3Title.Location = new System.Drawing.Point(16, 12);
            this.lblEmpKpi3Title.Name = "lblEmpKpi3Title";
            this.lblEmpKpi3Title.Size = new System.Drawing.Size(118, 20);
            this.lblEmpKpi3Title.TabIndex = 0;
            this.lblEmpKpi3Title.Text = "ON DUTY STAFF";
            // 
            // cardEmpKpi2
            // 
            this.cardEmpKpi2.BackColor = System.Drawing.Color.White;
            this.cardEmpKpi2.Controls.Add(this.lblEmpKpi2Sub);
            this.cardEmpKpi2.Controls.Add(this.lblEmpKpi2Val);
            this.cardEmpKpi2.Controls.Add(this.lblEmpKpi2Title);
            this.cardEmpKpi2.Location = new System.Drawing.Point(230, 0);
            this.cardEmpKpi2.Name = "cardEmpKpi2";
            this.cardEmpKpi2.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardEmpKpi2.Size = new System.Drawing.Size(220, 96);
            this.cardEmpKpi2.TabIndex = 1;
            this.cardEmpKpi2.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblEmpKpi2Sub
            // 
            this.lblEmpKpi2Sub.AutoSize = true;
            this.lblEmpKpi2Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmpKpi2Sub.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblEmpKpi2Sub.Location = new System.Drawing.Point(16, 68);
            this.lblEmpKpi2Sub.Name = "lblEmpKpi2Sub";
            this.lblEmpKpi2Sub.Size = new System.Drawing.Size(107, 19);
            this.lblEmpKpi2Sub.TabIndex = 2;
            this.lblEmpKpi2Sub.Text = "Active Personnel";
            // 
            // lblEmpKpi2Val
            // 
            this.lblEmpKpi2Val.AutoSize = true;
            this.lblEmpKpi2Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi2Val.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblEmpKpi2Val.Location = new System.Drawing.Point(14, 30);
            this.lblEmpKpi2Val.Name = "lblEmpKpi2Val";
            this.lblEmpKpi2Val.Size = new System.Drawing.Size(58, 46);
            this.lblEmpKpi2Val.TabIndex = 1;
            this.lblEmpKpi2Val.Text = "19";
            // 
            // lblEmpKpi2Title
            // 
            this.lblEmpKpi2Title.AutoSize = true;
            this.lblEmpKpi2Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi2Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi2Title.Location = new System.Drawing.Point(16, 12);
            this.lblEmpKpi2Title.Name = "lblEmpKpi2Title";
            this.lblEmpKpi2Title.Size = new System.Drawing.Size(147, 20);
            this.lblEmpKpi2Title.TabIndex = 0;
            this.lblEmpKpi2Title.Text = "ACTIVE PERSONNEL";
            // 
            // cardEmpKpi1
            // 
            this.cardEmpKpi1.BackColor = System.Drawing.Color.White;
            this.cardEmpKpi1.Controls.Add(this.lblEmpKpi1Sub);
            this.cardEmpKpi1.Controls.Add(this.lblEmpKpi1Val);
            this.cardEmpKpi1.Controls.Add(this.lblEmpKpi1Title);
            this.cardEmpKpi1.Location = new System.Drawing.Point(0, 0);
            this.cardEmpKpi1.Name = "cardEmpKpi1";
            this.cardEmpKpi1.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardEmpKpi1.Size = new System.Drawing.Size(220, 96);
            this.cardEmpKpi1.TabIndex = 0;
            this.cardEmpKpi1.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblEmpKpi1Sub
            // 
            this.lblEmpKpi1Sub.AutoSize = true;
            this.lblEmpKpi1Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmpKpi1Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi1Sub.Location = new System.Drawing.Point(16, 68);
            this.lblEmpKpi1Sub.Name = "lblEmpKpi1Sub";
            this.lblEmpKpi1Sub.Size = new System.Drawing.Size(126, 19);
            this.lblEmpKpi1Sub.TabIndex = 2;
            this.lblEmpKpi1Sub.Text = "Total Regular Staff";
            // 
            // lblEmpKpi1Val
            // 
            this.lblEmpKpi1Val.AutoSize = true;
            this.lblEmpKpi1Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi1Val.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEmpKpi1Val.Location = new System.Drawing.Point(14, 30);
            this.lblEmpKpi1Val.Name = "lblEmpKpi1Val";
            this.lblEmpKpi1Val.Size = new System.Drawing.Size(58, 46);
            this.lblEmpKpi1Val.TabIndex = 1;
            this.lblEmpKpi1Val.Text = "20";
            // 
            // lblEmpKpi1Title
            // 
            this.lblEmpKpi1Title.AutoSize = true;
            this.lblEmpKpi1Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpKpi1Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEmpKpi1Title.Location = new System.Drawing.Point(16, 12);
            this.lblEmpKpi1Title.Name = "lblEmpKpi1Title";
            this.lblEmpKpi1Title.Size = new System.Drawing.Size(147, 20);
            this.lblEmpKpi1Title.TabIndex = 0;
            this.lblEmpKpi1Title.Text = "TOTAL WORKFORCE";
            // 
            // pnlTabLeavesView
            // 
            this.pnlTabLeavesView.Controls.Add(this.cardLeavePieChart);
            this.pnlTabLeavesView.Controls.Add(this.pnlLeaveKpiRow);
            this.pnlTabLeavesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabLeavesView.Location = new System.Drawing.Point(0, 44);
            this.pnlTabLeavesView.Name = "pnlTabLeavesView";
            this.pnlTabLeavesView.Size = new System.Drawing.Size(930, 618);
            this.pnlTabLeavesView.TabIndex = 2;
            this.pnlTabLeavesView.Visible = false;
            // 
            // cardLeavePieChart
            // 
            this.cardLeavePieChart.BackColor = System.Drawing.Color.White;
            this.cardLeavePieChart.Controls.Add(this.pnlPieContainer);
            this.cardLeavePieChart.Controls.Add(this.lblPieChartSub);
            this.cardLeavePieChart.Controls.Add(this.lblPieChartTitle);
            this.cardLeavePieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLeavePieChart.Location = new System.Drawing.Point(0, 106);
            this.cardLeavePieChart.Name = "cardLeavePieChart";
            this.cardLeavePieChart.Padding = new System.Windows.Forms.Padding(20);
            this.cardLeavePieChart.Size = new System.Drawing.Size(930, 512);
            this.cardLeavePieChart.TabIndex = 1;
            this.cardLeavePieChart.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // pnlPieContainer
            // 
            this.pnlPieContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPieContainer.Location = new System.Drawing.Point(20, 64);
            this.pnlPieContainer.Name = "pnlPieContainer";
            this.pnlPieContainer.Size = new System.Drawing.Size(890, 428);
            this.pnlPieContainer.TabIndex = 2;
            this.pnlPieContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPieContainer_Paint);
            this.pnlPieContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPieContainer_MouseMove);
            this.pnlPieContainer.MouseLeave += new System.EventHandler(this.pnlPieContainer_MouseLeave);
            // 
            // lblPieChartSub
            // 
            this.lblPieChartSub.AutoSize = true;
            this.lblPieChartSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPieChartSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPieChartSub.Location = new System.Drawing.Point(20, 38);
            this.lblPieChartSub.Name = "lblPieChartSub";
            this.lblPieChartSub.Size = new System.Drawing.Size(326, 19);
            this.lblPieChartSub.TabIndex = 1;
            this.lblPieChartSub.Text = "Hover over slices to inspect lifecycle status proportions";
            // 
            // lblPieChartTitle
            // 
            this.lblPieChartTitle.AutoSize = true;
            this.lblPieChartTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPieChartTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPieChartTitle.Location = new System.Drawing.Point(18, 14);
            this.lblPieChartTitle.Name = "lblPieChartTitle";
            this.lblPieChartTitle.Size = new System.Drawing.Size(276, 25);
            this.lblPieChartTitle.TabIndex = 0;
            this.lblPieChartTitle.Text = "Leave Request Status Breakdown";
            // 
            // pnlLeaveKpiRow
            // 
            this.pnlLeaveKpiRow.Controls.Add(this.cardLeaveKpi4);
            this.pnlLeaveKpiRow.Controls.Add(this.cardLeaveKpi3);
            this.pnlLeaveKpiRow.Controls.Add(this.cardLeaveKpi2);
            this.pnlLeaveKpiRow.Controls.Add(this.cardLeaveKpi1);
            this.pnlLeaveKpiRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeaveKpiRow.Location = new System.Drawing.Point(0, 0);
            this.pnlLeaveKpiRow.Name = "pnlLeaveKpiRow";
            this.pnlLeaveKpiRow.Size = new System.Drawing.Size(930, 106);
            this.pnlLeaveKpiRow.TabIndex = 0;
            this.pnlLeaveKpiRow.Resize += new System.EventHandler(this.pnlLeaveKpiRow_Resize);
            // 
            // cardLeaveKpi4
            // 
            this.cardLeaveKpi4.BackColor = System.Drawing.Color.White;
            this.cardLeaveKpi4.Controls.Add(this.lblLeaveKpi4Sub);
            this.cardLeaveKpi4.Controls.Add(this.lblLeaveKpi4Val);
            this.cardLeaveKpi4.Controls.Add(this.lblLeaveKpi4Title);
            this.cardLeaveKpi4.Location = new System.Drawing.Point(690, 0);
            this.cardLeaveKpi4.Name = "cardLeaveKpi4";
            this.cardLeaveKpi4.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardLeaveKpi4.Size = new System.Drawing.Size(220, 96);
            this.cardLeaveKpi4.TabIndex = 3;
            this.cardLeaveKpi4.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblLeaveKpi4Sub
            // 
            this.lblLeaveKpi4Sub.AutoSize = true;
            this.lblLeaveKpi4Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeaveKpi4Sub.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLeaveKpi4Sub.Location = new System.Drawing.Point(16, 68);
            this.lblLeaveKpi4Sub.Name = "lblLeaveKpi4Sub";
            this.lblLeaveKpi4Sub.Size = new System.Drawing.Size(104, 19);
            this.lblLeaveKpi4Sub.TabIndex = 2;
            this.lblLeaveKpi4Sub.Text = "Currently Away";
            this.lblLeaveKpi4Sub.Size = new System.Drawing.Size(188, 19);
            this.lblLeaveKpi4Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeaveKpi4Val
            // 
            this.lblLeaveKpi4Val.AutoSize = true;
            this.lblLeaveKpi4Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi4Val.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLeaveKpi4Val.Location = new System.Drawing.Point(14, 30);
            this.lblLeaveKpi4Val.Name = "lblLeaveKpi4Val";
            this.lblLeaveKpi4Val.Size = new System.Drawing.Size(188, 46);
            this.lblLeaveKpi4Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeaveKpi4Val.TabIndex = 1;
            this.lblLeaveKpi4Val.Text = "0";
            // 
            // lblLeaveKpi4Title
            // 
            this.lblLeaveKpi4Title.AutoSize = true;
            this.lblLeaveKpi4Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi4Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLeaveKpi4Title.Location = new System.Drawing.Point(16, 12);
            this.lblLeaveKpi4Title.Name = "lblLeaveKpi4Title";
            this.lblLeaveKpi4Title.Size = new System.Drawing.Size(126, 20);
            this.lblLeaveKpi4Title.TabIndex = 0;
            this.lblLeaveKpi4Title.Text = "ACTIVE ON LEAVE";
            // 
            // cardLeaveKpi3
            // 
            this.cardLeaveKpi3.BackColor = System.Drawing.Color.White;
            this.cardLeaveKpi3.Controls.Add(this.lblLeaveKpi3Sub);
            this.cardLeaveKpi3.Controls.Add(this.lblLeaveKpi3Val);
            this.cardLeaveKpi3.Controls.Add(this.lblLeaveKpi3Title);
            this.cardLeaveKpi3.Location = new System.Drawing.Point(460, 0);
            this.cardLeaveKpi3.Name = "cardLeaveKpi3";
            this.cardLeaveKpi3.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardLeaveKpi3.Size = new System.Drawing.Size(220, 96);
            this.cardLeaveKpi3.TabIndex = 2;
            this.cardLeaveKpi3.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblLeaveKpi3Sub
            // 
            this.lblLeaveKpi3Sub.AutoSize = true;
            this.lblLeaveKpi3Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeaveKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblLeaveKpi3Sub.Location = new System.Drawing.Point(16, 68);
            this.lblLeaveKpi3Sub.Name = "lblLeaveKpi3Sub";
            this.lblLeaveKpi3Sub.Size = new System.Drawing.Size(117, 19);
            this.lblLeaveKpi3Sub.TabIndex = 2;
            this.lblLeaveKpi3Sub.Text = "Clearance Review";
            this.lblLeaveKpi3Sub.Size = new System.Drawing.Size(188, 19);
            this.lblLeaveKpi3Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeaveKpi3Val
            // 
            this.lblLeaveKpi3Val.AutoSize = true;
            this.lblLeaveKpi3Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi3Val.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblLeaveKpi3Val.Location = new System.Drawing.Point(14, 30);
            this.lblLeaveKpi3Val.Name = "lblLeaveKpi3Val";
            this.lblLeaveKpi3Val.Size = new System.Drawing.Size(188, 46);
            this.lblLeaveKpi3Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeaveKpi3Val.TabIndex = 1;
            this.lblLeaveKpi3Val.Text = "0";
            // 
            // lblLeaveKpi3Title
            // 
            this.lblLeaveKpi3Title.AutoSize = true;
            this.lblLeaveKpi3Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi3Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLeaveKpi3Title.Location = new System.Drawing.Point(16, 12);
            this.lblLeaveKpi3Title.Name = "lblLeaveKpi3Title";
            this.lblLeaveKpi3Title.Size = new System.Drawing.Size(107, 20);
            this.lblLeaveKpi3Title.TabIndex = 0;
            this.lblLeaveKpi3Title.Text = "IN CLEARANCE";
            this.lblLeaveKpi3Title.Size = new System.Drawing.Size(188, 20);
            this.lblLeaveKpi3Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardLeaveKpi2
            // 
            this.cardLeaveKpi2.BackColor = System.Drawing.Color.White;
            this.cardLeaveKpi2.Controls.Add(this.lblLeaveKpi2Sub);
            this.cardLeaveKpi2.Controls.Add(this.lblLeaveKpi2Val);
            this.cardLeaveKpi2.Controls.Add(this.lblLeaveKpi2Title);
            this.cardLeaveKpi2.Location = new System.Drawing.Point(230, 0);
            this.cardLeaveKpi2.Name = "cardLeaveKpi2";
            this.cardLeaveKpi2.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardLeaveKpi2.Size = new System.Drawing.Size(220, 96);
            this.cardLeaveKpi2.TabIndex = 1;
            this.cardLeaveKpi2.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblLeaveKpi2Sub
            // 
            this.lblLeaveKpi2Sub.AutoSize = true;
            this.lblLeaveKpi2Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeaveKpi2Sub.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblLeaveKpi2Sub.Location = new System.Drawing.Point(16, 68);
            this.lblLeaveKpi2Sub.Name = "lblLeaveKpi2Sub";
            this.lblLeaveKpi2Sub.Size = new System.Drawing.Size(117, 19);
            this.lblLeaveKpi2Sub.TabIndex = 2;
            this.lblLeaveKpi2Sub.Text = "Awaiting Decision";
            this.lblLeaveKpi2Sub.Size = new System.Drawing.Size(188, 19);
            this.lblLeaveKpi2Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeaveKpi2Val
            // 
            this.lblLeaveKpi2Val.AutoSize = true;
            this.lblLeaveKpi2Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi2Val.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblLeaveKpi2Val.Location = new System.Drawing.Point(14, 30);
            this.lblLeaveKpi2Val.Name = "lblLeaveKpi2Val";
            this.lblLeaveKpi2Val.Size = new System.Drawing.Size(188, 46);
            this.lblLeaveKpi2Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeaveKpi2Val.TabIndex = 1;
            this.lblLeaveKpi2Val.Text = "0";
            // 
            // lblLeaveKpi2Title
            // 
            this.lblLeaveKpi2Title.AutoSize = true;
            this.lblLeaveKpi2Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi2Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLeaveKpi2Title.Location = new System.Drawing.Point(16, 12);
            this.lblLeaveKpi2Title.Name = "lblLeaveKpi2Title";
            this.lblLeaveKpi2Title.Size = new System.Drawing.Size(126, 20);
            this.lblLeaveKpi2Title.TabIndex = 0;
            this.lblLeaveKpi2Title.Text = "PENDING REVIEW";
            this.lblLeaveKpi2Title.Size = new System.Drawing.Size(188, 20);
            this.lblLeaveKpi2Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardLeaveKpi1
            // 
            this.cardLeaveKpi1.BackColor = System.Drawing.Color.White;
            this.cardLeaveKpi1.Controls.Add(this.lblLeaveKpi1Sub);
            this.cardLeaveKpi1.Controls.Add(this.lblLeaveKpi1Val);
            this.cardLeaveKpi1.Controls.Add(this.lblLeaveKpi1Title);
            this.cardLeaveKpi1.Location = new System.Drawing.Point(0, 0);
            this.cardLeaveKpi1.Name = "cardLeaveKpi1";
            this.cardLeaveKpi1.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.cardLeaveKpi1.Size = new System.Drawing.Size(220, 96);
            this.cardLeaveKpi1.TabIndex = 0;
            this.cardLeaveKpi1.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            // 
            // lblLeaveKpi1Sub
            // 
            this.lblLeaveKpi1Sub.AutoSize = true;
            this.lblLeaveKpi1Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeaveKpi1Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLeaveKpi1Sub.Location = new System.Drawing.Point(16, 68);
            this.lblLeaveKpi1Sub.Name = "lblLeaveKpi1Sub";
            this.lblLeaveKpi1Sub.Size = new System.Drawing.Size(117, 19);
            this.lblLeaveKpi1Sub.TabIndex = 2;
            this.lblLeaveKpi1Sub.Text = "All Active Ledgers";
            this.lblLeaveKpi1Sub.Size = new System.Drawing.Size(188, 19);
            this.lblLeaveKpi1Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeaveKpi1Val
            // 
            this.lblLeaveKpi1Val.AutoSize = true;
            this.lblLeaveKpi1Val.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi1Val.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblLeaveKpi1Val.Location = new System.Drawing.Point(14, 30);
            this.lblLeaveKpi1Val.Name = "lblLeaveKpi1Val";
            this.lblLeaveKpi1Val.Size = new System.Drawing.Size(188, 46);
            this.lblLeaveKpi1Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeaveKpi1Val.TabIndex = 1;
            this.lblLeaveKpi1Val.Text = "0";
            // 
            // lblLeaveKpi1Title
            // 
            this.lblLeaveKpi1Title.AutoSize = true;
            this.lblLeaveKpi1Title.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLeaveKpi1Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLeaveKpi1Title.Location = new System.Drawing.Point(16, 12);
            this.lblLeaveKpi1Title.Name = "lblLeaveKpi1Title";
            this.lblLeaveKpi1Title.Size = new System.Drawing.Size(123, 20);
            this.lblLeaveKpi1Title.TabIndex = 0;
            this.lblLeaveKpi1Title.Text = "TOTAL REQUESTS";
            this.lblLeaveKpi1Title.Size = new System.Drawing.Size(188, 20);
            this.lblLeaveKpi1Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGridView
            // 
            this.pnlGridView.Controls.Add(this.dgvData);
            this.pnlGridView.Controls.Add(this.pnlReportMetrics);
            this.pnlGridView.Controls.Add(this.pnlToolbar);
            this.pnlGridView.Controls.Add(this.pnlConfigSubNav);
            this.pnlGridView.Controls.Add(this.pnlLeaveSubNav);
            this.pnlGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridView.Location = new System.Drawing.Point(20, 20);
            this.pnlGridView.Name = "pnlGridView";
            this.pnlGridView.Size = new System.Drawing.Size(930, 662);
            this.pnlGridView.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 52);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 35;
            this.dgvData.Size = new System.Drawing.Size(930, 610);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // pnlConfigSubNav
            // 
            this.pnlConfigSubNav.BackColor = System.Drawing.Color.White;
            this.pnlConfigSubNav.Controls.Add(this.btnConfigTabApproval);
            this.pnlConfigSubNav.Controls.Add(this.btnConfigTabLeave);
            this.pnlConfigSubNav.Controls.Add(this.btnConfigTabClearance);
            this.pnlConfigSubNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfigSubNav.Location = new System.Drawing.Point(0, 0);
            this.pnlConfigSubNav.Name = "pnlConfigSubNav";
            this.pnlConfigSubNav.Size = new System.Drawing.Size(930, 44);
            this.pnlConfigSubNav.TabIndex = 3;
            this.pnlConfigSubNav.Visible = false;
            this.pnlConfigSubNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlConfigSubNav_Paint);
            // 
            // btnConfigTabClearance
            // 
            this.btnConfigTabClearance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigTabClearance.FlatAppearance.BorderSize = 0;
            this.btnConfigTabClearance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigTabClearance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfigTabClearance.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnConfigTabClearance.Location = new System.Drawing.Point(10, 4);
            this.btnConfigTabClearance.Name = "btnConfigTabClearance";
            this.btnConfigTabClearance.Size = new System.Drawing.Size(165, 34);
            this.btnConfigTabClearance.TabIndex = 0;
            this.btnConfigTabClearance.Text = "Clearance Policies";
            this.btnConfigTabClearance.UseVisualStyleBackColor = true;
            this.btnConfigTabClearance.Click += new System.EventHandler(this.btnConfigTabClearance_Click);
            // 
            // btnConfigTabLeave
            // 
            this.btnConfigTabLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigTabLeave.FlatAppearance.BorderSize = 0;
            this.btnConfigTabLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigTabLeave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnConfigTabLeave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnConfigTabLeave.Location = new System.Drawing.Point(180, 4);
            this.btnConfigTabLeave.Name = "btnConfigTabLeave";
            this.btnConfigTabLeave.Size = new System.Drawing.Size(145, 34);
            this.btnConfigTabLeave.TabIndex = 1;
            this.btnConfigTabLeave.Text = "Leave Policies";
            this.btnConfigTabLeave.UseVisualStyleBackColor = true;
            this.btnConfigTabLeave.Click += new System.EventHandler(this.btnConfigTabLeave_Click);
            // 
            // btnConfigTabApproval
            // 
            this.btnConfigTabApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigTabApproval.FlatAppearance.BorderSize = 0;
            this.btnConfigTabApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigTabApproval.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnConfigTabApproval.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnConfigTabApproval.Location = new System.Drawing.Point(330, 4);
            this.btnConfigTabApproval.Name = "btnConfigTabApproval";
            this.btnConfigTabApproval.Size = new System.Drawing.Size(165, 34);
            this.btnConfigTabApproval.TabIndex = 2;
            this.btnConfigTabApproval.Text = "Approval Workflows";
            this.btnConfigTabApproval.UseVisualStyleBackColor = true;
            this.btnConfigTabApproval.Click += new System.EventHandler(this.btnConfigTabApproval_Click);
            // 
            // pnlLeaveSubNav
            // 
            this.pnlLeaveSubNav.BackColor = System.Drawing.Color.White;
            this.pnlLeaveSubNav.Controls.Add(this.btnLeaveTabEntitlements);
            this.pnlLeaveSubNav.Controls.Add(this.btnLeaveTabTypes);
            this.pnlLeaveSubNav.Controls.Add(this.btnLeaveTabApprovals);
            this.pnlLeaveSubNav.Controls.Add(this.btnLeaveTabRequests);
            this.pnlLeaveSubNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeaveSubNav.Location = new System.Drawing.Point(0, 0);
            this.pnlLeaveSubNav.Name = "pnlLeaveSubNav";
            this.pnlLeaveSubNav.Size = new System.Drawing.Size(930, 44);
            this.pnlLeaveSubNav.TabIndex = 2;
            this.pnlLeaveSubNav.Visible = false;
            this.pnlLeaveSubNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeaveSubNav_Paint);
            // 
            // btnLeaveTabRequests
            // 
            this.btnLeaveTabRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveTabRequests.FlatAppearance.BorderSize = 0;
            this.btnLeaveTabRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveTabRequests.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeaveTabRequests.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLeaveTabRequests.Location = new System.Drawing.Point(10, 4);
            this.btnLeaveTabRequests.Name = "btnLeaveTabRequests";
            this.btnLeaveTabRequests.Size = new System.Drawing.Size(120, 36);
            this.btnLeaveTabRequests.TabIndex = 0;
            this.btnLeaveTabRequests.Text = "My Requests";
            this.btnLeaveTabRequests.UseVisualStyleBackColor = true;
            this.btnLeaveTabRequests.Click += new System.EventHandler(this.btnLeaveTabRequests_Click);
            // 
            // btnLeaveTabApprovals
            // 
            this.btnLeaveTabApprovals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveTabApprovals.FlatAppearance.BorderSize = 0;
            this.btnLeaveTabApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveTabApprovals.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeaveTabApprovals.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLeaveTabApprovals.Location = new System.Drawing.Point(136, 4);
            this.btnLeaveTabApprovals.Name = "btnLeaveTabApprovals";
            this.btnLeaveTabApprovals.Size = new System.Drawing.Size(110, 36);
            this.btnLeaveTabApprovals.TabIndex = 1;
            this.btnLeaveTabApprovals.Text = "Approvals";
            this.btnLeaveTabApprovals.UseVisualStyleBackColor = true;
            this.btnLeaveTabApprovals.Click += new System.EventHandler(this.btnLeaveTabApprovals_Click);
            // 
            // btnLeaveTabTypes
            // 
            this.btnLeaveTabTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveTabTypes.FlatAppearance.BorderSize = 0;
            this.btnLeaveTabTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveTabTypes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeaveTabTypes.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLeaveTabTypes.Location = new System.Drawing.Point(252, 4);
            this.btnLeaveTabTypes.Name = "btnLeaveTabTypes";
            this.btnLeaveTabTypes.Size = new System.Drawing.Size(110, 36);
            this.btnLeaveTabTypes.TabIndex = 2;
            this.btnLeaveTabTypes.Text = "Leave Types";
            this.btnLeaveTabTypes.UseVisualStyleBackColor = true;
            this.btnLeaveTabTypes.Click += new System.EventHandler(this.btnLeaveTabTypes_Click);
            // 
            // btnLeaveTabEntitlements
            // 
            this.btnLeaveTabEntitlements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaveTabEntitlements.FlatAppearance.BorderSize = 0;
            this.btnLeaveTabEntitlements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveTabEntitlements.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLeaveTabEntitlements.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLeaveTabEntitlements.Location = new System.Drawing.Point(368, 4);
            this.btnLeaveTabEntitlements.Name = "btnLeaveTabEntitlements";
            this.btnLeaveTabEntitlements.Size = new System.Drawing.Size(120, 36);
            this.btnLeaveTabEntitlements.TabIndex = 3;
            this.btnLeaveTabEntitlements.Text = "Entitlements";
            this.btnLeaveTabEntitlements.UseVisualStyleBackColor = true;
            this.btnLeaveTabEntitlements.Click += new System.EventHandler(this.btnLeaveTabEntitlements_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnToolbarAction);
            this.pnlToolbar.Controls.Add(this.btnSecondaryAction);
            this.pnlToolbar.Controls.Add(this.cboFilter3);
            this.pnlToolbar.Controls.Add(this.cboFilter2);
            this.pnlToolbar.Controls.Add(this.cboFilter1);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(930, 52);
            this.pnlToolbar.TabIndex = 0;
            this.pnlToolbar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlToolbar_Paint);
            // 
            // btnToolbarAction
            // 
            this.btnToolbarAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToolbarAction.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnToolbarAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToolbarAction.FlatAppearance.BorderSize = 0;
            this.btnToolbarAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolbarAction.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnToolbarAction.ForeColor = System.Drawing.Color.White;
            this.btnToolbarAction.Location = new System.Drawing.Point(778, 9);
            this.btnToolbarAction.Name = "btnToolbarAction";
            this.btnToolbarAction.Size = new System.Drawing.Size(140, 34);
            this.btnToolbarAction.TabIndex = 5;
            this.btnToolbarAction.Text = "+ New Request";
            this.btnToolbarAction.UseVisualStyleBackColor = false;
            this.btnToolbarAction.Click += new System.EventHandler(this.btnToolbarAction_Click);
            // 
            // btnSecondaryAction
            // 
            this.btnSecondaryAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecondaryAction.BackColor = System.Drawing.Color.White;
            this.btnSecondaryAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecondaryAction.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnSecondaryAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecondaryAction.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSecondaryAction.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnSecondaryAction.Location = new System.Drawing.Point(633, 9);
            this.btnSecondaryAction.Name = "btnSecondaryAction";
            this.btnSecondaryAction.Size = new System.Drawing.Size(135, 34);
            this.btnSecondaryAction.TabIndex = 4;
            this.btnSecondaryAction.Text = "📄 Export PDF";
            this.btnSecondaryAction.UseVisualStyleBackColor = false;
            this.btnSecondaryAction.Visible = false;
            this.btnSecondaryAction.Click += new System.EventHandler(this.btnSecondaryAction_Click);
            // 
            // cboFilter3
            // 
            this.cboFilter3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilter3.FormattingEnabled = true;
            this.cboFilter3.Location = new System.Drawing.Point(476, 11);
            this.cboFilter3.Name = "cboFilter3";
            this.cboFilter3.Size = new System.Drawing.Size(145, 29);
            this.cboFilter3.TabIndex = 3;
            this.cboFilter3.Visible = false;
            this.cboFilter3.SelectedIndexChanged += new System.EventHandler(this.FilterOrSearch_Changed);
            // 
            // cboFilter2
            // 
            this.cboFilter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilter2.FormattingEnabled = true;
            this.cboFilter2.Location = new System.Drawing.Point(348, 11);
            this.cboFilter2.Name = "cboFilter2";
            this.cboFilter2.Size = new System.Drawing.Size(120, 29);
            this.cboFilter2.TabIndex = 2;
            this.cboFilter2.SelectedIndexChanged += new System.EventHandler(this.FilterOrSearch_Changed);
            // 
            // cboFilter1
            // 
            this.cboFilter1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilter1.FormattingEnabled = true;
            this.cboFilter1.Location = new System.Drawing.Point(200, 11);
            this.cboFilter1.Name = "cboFilter1";
            this.cboFilter1.Size = new System.Drawing.Size(140, 29);
            this.cboFilter1.TabIndex = 1;
            this.cboFilter1.SelectedIndexChanged += new System.EventHandler(this.FilterOrSearch_Changed);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(12, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search records...";
            this.txtSearch.Size = new System.Drawing.Size(180, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.FilterOrSearch_Changed);
            // 
            // pnlReportMetrics
            // 
            this.pnlReportMetrics.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlReportMetrics.Controls.Add(this.pnlKpiSummaryBadges);
            this.pnlReportMetrics.Controls.Add(this.lblReportSelectedCount);
            this.pnlReportMetrics.Controls.Add(this.btnToggleSelectAll);
            this.pnlReportMetrics.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportMetrics.Location = new System.Drawing.Point(0, 52);
            this.pnlReportMetrics.Name = "pnlReportMetrics";
            this.pnlReportMetrics.Size = new System.Drawing.Size(930, 44);
            this.pnlReportMetrics.TabIndex = 4;
            this.pnlReportMetrics.Visible = false;
            this.pnlReportMetrics.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlReportMetrics_Paint);
            // 
            // btnToggleSelectAll
            // 
            this.btnToggleSelectAll.BackColor = System.Drawing.Color.White;
            this.btnToggleSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnToggleSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleSelectAll.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnToggleSelectAll.Location = new System.Drawing.Point(12, 8);
            this.btnToggleSelectAll.Name = "btnToggleSelectAll";
            this.btnToggleSelectAll.Size = new System.Drawing.Size(115, 28);
            this.btnToggleSelectAll.TabIndex = 0;
            this.btnToggleSelectAll.Text = "☑ Select All";
            this.btnToggleSelectAll.UseVisualStyleBackColor = false;
            this.btnToggleSelectAll.Click += new System.EventHandler(this.btnToggleSelectAll_Click);
            // 
            // lblReportSelectedCount
            // 
            this.lblReportSelectedCount.AutoSize = true;
            this.lblReportSelectedCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReportSelectedCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblReportSelectedCount.Location = new System.Drawing.Point(135, 12);
            this.lblReportSelectedCount.Name = "lblReportSelectedCount";
            this.lblReportSelectedCount.Size = new System.Drawing.Size(250, 20);
            this.lblReportSelectedCount.TabIndex = 1;
            this.lblReportSelectedCount.Text = "0 of 0 selected (generating for all filtered)";
            // 
            // pnlKpiSummaryBadges
            // 
            this.pnlKpiSummaryBadges.BackColor = System.Drawing.Color.Transparent;
            this.pnlKpiSummaryBadges.Controls.Add(this.lblReportKpiUtil);
            this.pnlKpiSummaryBadges.Controls.Add(this.lblReportKpiBalance);
            this.pnlKpiSummaryBadges.Controls.Add(this.lblReportKpiUsed);
            this.pnlKpiSummaryBadges.Controls.Add(this.lblReportKpiAllocated);
            this.pnlKpiSummaryBadges.Controls.Add(this.lblReportKpiStaff);
            this.pnlKpiSummaryBadges.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKpiSummaryBadges.Location = new System.Drawing.Point(460, 0);
            this.pnlKpiSummaryBadges.Name = "pnlKpiSummaryBadges";
            this.pnlKpiSummaryBadges.Size = new System.Drawing.Size(470, 44);
            this.pnlKpiSummaryBadges.TabIndex = 2;
            // 
            // lblReportKpiStaff
            // 
            this.lblReportKpiStaff.AutoSize = true;
            this.lblReportKpiStaff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportKpiStaff.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblReportKpiStaff.Location = new System.Drawing.Point(5, 12);
            this.lblReportKpiStaff.Name = "lblReportKpiStaff";
            this.lblReportKpiStaff.Size = new System.Drawing.Size(70, 20);
            this.lblReportKpiStaff.TabIndex = 0;
            this.lblReportKpiStaff.Text = "👥 Staff: 0";
            // 
            // lblReportKpiAllocated
            // 
            this.lblReportKpiAllocated.AutoSize = true;
            this.lblReportKpiAllocated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportKpiAllocated.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblReportKpiAllocated.Location = new System.Drawing.Point(85, 12);
            this.lblReportKpiAllocated.Name = "lblReportKpiAllocated";
            this.lblReportKpiAllocated.Size = new System.Drawing.Size(85, 20);
            this.lblReportKpiAllocated.TabIndex = 1;
            this.lblReportKpiAllocated.Text = "📊 Quota: 0d";
            // 
            // lblReportKpiUsed
            // 
            this.lblReportKpiUsed.AutoSize = true;
            this.lblReportKpiUsed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportKpiUsed.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblReportKpiUsed.Location = new System.Drawing.Point(185, 12);
            this.lblReportKpiUsed.Name = "lblReportKpiUsed";
            this.lblReportKpiUsed.Size = new System.Drawing.Size(80, 20);
            this.lblReportKpiUsed.TabIndex = 2;
            this.lblReportKpiUsed.Text = "🌴 Taken: 0d";
            // 
            // lblReportKpiBalance
            // 
            this.lblReportKpiBalance.AutoSize = true;
            this.lblReportKpiBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportKpiBalance.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblReportKpiBalance.Location = new System.Drawing.Point(280, 12);
            this.lblReportKpiBalance.Name = "lblReportKpiBalance";
            this.lblReportKpiBalance.Size = new System.Drawing.Size(90, 20);
            this.lblReportKpiBalance.TabIndex = 3;
            this.lblReportKpiBalance.Text = "⚖️ Balance: 0d";
            // 
            // lblReportKpiUtil
            // 
            this.lblReportKpiUtil.AutoSize = true;
            this.lblReportKpiUtil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportKpiUtil.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblReportKpiUtil.Location = new System.Drawing.Point(380, 12);
            this.lblReportKpiUtil.Name = "lblReportKpiUtil";
            this.lblReportKpiUtil.Size = new System.Drawing.Size(75, 20);
            this.lblReportKpiUtil.TabIndex = 4;
            this.lblReportKpiUtil.Text = "📈 Util: 0%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ELMS - Employee Leave Management System";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarNav.ResumeLayout(false);
            this.pnlSidebarBottom.ResumeLayout(false);
            this.pnlUserCard.ResumeLayout(false);
            this.pnlUserCard.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.menuUser.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContentHost.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashTabs.ResumeLayout(false);
            this.pnlTabEmployeesView.ResumeLayout(false);
            this.pnlEmpContent.ResumeLayout(false);
            this.cardEmpDemographics.ResumeLayout(false);
            this.cardEmpDemographics.PerformLayout();
            this.cardEmpDeptChart.ResumeLayout(false);
            this.cardEmpDeptChart.PerformLayout();
            this.pnlEmpKpiRow.ResumeLayout(false);
            this.cardEmpKpi4.ResumeLayout(false);
            this.cardEmpKpi4.PerformLayout();
            this.cardEmpKpi3.ResumeLayout(false);
            this.cardEmpKpi3.PerformLayout();
            this.cardEmpKpi2.ResumeLayout(false);
            this.cardEmpKpi2.PerformLayout();
            this.cardEmpKpi1.ResumeLayout(false);
            this.cardEmpKpi1.PerformLayout();
            this.pnlTabLeavesView.ResumeLayout(false);
            this.cardLeavePieChart.ResumeLayout(false);
            this.cardLeavePieChart.PerformLayout();
            this.pnlLeaveKpiRow.ResumeLayout(false);
            this.cardLeaveKpi4.ResumeLayout(false);
            this.cardLeaveKpi4.PerformLayout();
            this.cardLeaveKpi3.ResumeLayout(false);
            this.cardLeaveKpi3.PerformLayout();
            this.cardLeaveKpi2.ResumeLayout(false);
            this.cardLeaveKpi2.PerformLayout();
            this.cardLeaveKpi1.ResumeLayout(false);
            this.cardLeaveKpi1.PerformLayout();
            this.pnlGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrandLogo;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlSidebarNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavLeaves;
        private System.Windows.Forms.Button btnNavEmployees;
        private System.Windows.Forms.Button btnNavDepartments;
        private System.Windows.Forms.Button btnNavRoles;
        private System.Windows.Forms.Button btnNavApprovals;
        private System.Windows.Forms.Button btnNavClearances;
        private System.Windows.Forms.Button btnNavConfigurations;
        private System.Windows.Forms.Button btnNavLedger;
        private System.Windows.Forms.Panel pnlConfigSubNav;
        private System.Windows.Forms.Button btnConfigTabClearance;
        private System.Windows.Forms.Button btnConfigTabLeave;
        private System.Windows.Forms.Button btnConfigTabApproval;
        private System.Windows.Forms.Panel pnlSidebarBottom;
        private System.Windows.Forms.Panel pnlUserCard;
        private System.Windows.Forms.Label lblUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblDropdownArrow;
        private System.Windows.Forms.ContextMenuStrip menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuItemProfile;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnToggleSidebar;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Panel pnlContentHost;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlDashTabs;
        private System.Windows.Forms.Button btnTabEmployees;
        private System.Windows.Forms.Button btnTabLeaves;
        private System.Windows.Forms.Panel pnlTabEmployeesView;
        private System.Windows.Forms.Panel pnlEmpKpiRow;
        private System.Windows.Forms.Panel cardEmpKpi1;
        private System.Windows.Forms.Label lblEmpKpi1Val;
        private System.Windows.Forms.Label lblEmpKpi1Title;
        private System.Windows.Forms.Label lblEmpKpi1Sub;
        private System.Windows.Forms.Panel cardEmpKpi2;
        private System.Windows.Forms.Label lblEmpKpi2Val;
        private System.Windows.Forms.Label lblEmpKpi2Title;
        private System.Windows.Forms.Label lblEmpKpi2Sub;
        private System.Windows.Forms.Panel cardEmpKpi3;
        private System.Windows.Forms.Label lblEmpKpi3Val;
        private System.Windows.Forms.Label lblEmpKpi3Title;
        private System.Windows.Forms.Label lblEmpKpi3Sub;
        private System.Windows.Forms.Panel cardEmpKpi4;
        private System.Windows.Forms.Label lblEmpKpi4Val;
        private System.Windows.Forms.Label lblEmpKpi4Title;
        private System.Windows.Forms.Label lblEmpKpi4Sub;
        private System.Windows.Forms.Panel pnlEmpContent;
        private System.Windows.Forms.Panel cardEmpDeptChart;
        private System.Windows.Forms.Label lblDeptChartTitle;
        private System.Windows.Forms.Label lblDeptChartSub;
        private System.Windows.Forms.Panel pnlEmpDeptBarContainer;
        private System.Windows.Forms.Panel cardEmpDemographics;
        private System.Windows.Forms.Label lblDemoTitle;
        private System.Windows.Forms.Label lblDemoSub;
        private System.Windows.Forms.Panel pnlDemographicsContainer;
        private System.Windows.Forms.Panel pnlTabLeavesView;
        private System.Windows.Forms.Panel pnlLeaveKpiRow;
        private System.Windows.Forms.Panel cardLeaveKpi1;
        private System.Windows.Forms.Label lblLeaveKpi1Val;
        private System.Windows.Forms.Label lblLeaveKpi1Title;
        private System.Windows.Forms.Label lblLeaveKpi1Sub;
        private System.Windows.Forms.Panel cardLeaveKpi2;
        private System.Windows.Forms.Label lblLeaveKpi2Val;
        private System.Windows.Forms.Label lblLeaveKpi2Title;
        private System.Windows.Forms.Label lblLeaveKpi2Sub;
        private System.Windows.Forms.Panel cardLeaveKpi3;
        private System.Windows.Forms.Label lblLeaveKpi3Val;
        private System.Windows.Forms.Label lblLeaveKpi3Title;
        private System.Windows.Forms.Label lblLeaveKpi3Sub;
        private System.Windows.Forms.Panel cardLeaveKpi4;
        private System.Windows.Forms.Label lblLeaveKpi4Val;
        private System.Windows.Forms.Label lblLeaveKpi4Title;
        private System.Windows.Forms.Label lblLeaveKpi4Sub;
        private System.Windows.Forms.Panel cardLeavePieChart;
        private System.Windows.Forms.Label lblPieChartTitle;
        private System.Windows.Forms.Label lblPieChartSub;
        private System.Windows.Forms.Panel pnlPieContainer;
        private System.Windows.Forms.Panel pnlGridView;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlLeaveSubNav;
        private System.Windows.Forms.Button btnLeaveTabRequests;
        private System.Windows.Forms.Button btnLeaveTabApprovals;
        private System.Windows.Forms.Button btnLeaveTabTypes;
        private System.Windows.Forms.Button btnLeaveTabEntitlements;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilter1;
        private System.Windows.Forms.ComboBox cboFilter2;
        private System.Windows.Forms.ComboBox cboFilter3;
        private System.Windows.Forms.Button btnToolbarAction;
        private System.Windows.Forms.Button btnSecondaryAction;
        private System.Windows.Forms.Panel pnlReportMetrics;
        private System.Windows.Forms.Button btnToggleSelectAll;
        private System.Windows.Forms.Label lblReportSelectedCount;
        private System.Windows.Forms.Panel pnlKpiSummaryBadges;
        private System.Windows.Forms.Label lblReportKpiStaff;
        private System.Windows.Forms.Label lblReportKpiAllocated;
        private System.Windows.Forms.Label lblReportKpiUsed;
        private System.Windows.Forms.Label lblReportKpiBalance;
        private System.Windows.Forms.Label lblReportKpiUtil;
        private System.Windows.Forms.DataGridView dgvData;
        private ELMS.Forms.ConfigurationsView ucConfigurations;
    }
}
