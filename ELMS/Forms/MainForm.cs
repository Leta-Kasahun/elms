using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ELMS.Common;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class MainForm : Form
    {
        private enum ActiveView
        {
            Dashboard,
            Leaves,
            Approvals,
            Employees,
            Departments,
            Roles,
            Clearances,
            Configurations,
            Ledger
        }

        private enum LeaveSubTab
        {
            Requests,
            Approvals,
            Types,
            Entitlements
        }

        private LeaveSubTab _currentLeaveSubTab = LeaveSubTab.Requests;

        private enum ConfigSubTab
        {
            Clearance,
            Leave,
            Approval
        }

        private ConfigSubTab _currentConfigSubTab = ConfigSubTab.Clearance;

        private ActiveView _currentView = ActiveView.Dashboard;
        private bool _isSidebarCollapsed = false;
        private int _hoveredPieSlice = -1;
        private DataTablePagination paginationControl = null!;

        public MainForm()
        {
            InitializeComponent();
            ApplyThemeAndStyles();
            ConfigureSession();
            SwitchView(ActiveView.Dashboard);
            ShowEmployeesTab();
            DataStore.Instance.DataChanged += (s, e) => RefreshActiveData();
        }

        private void ApplyThemeAndStyles()
        {
            ElmsTheme.ApplyGridStyle(dgvData);
            paginationControl = new DataTablePagination();
            pnlGridView.Controls.Add(paginationControl);
            dgvData.BringToFront();
            dgvData.CurrentCellDirtyStateChanged += dgvData_CurrentCellDirtyStateChanged;
            dgvData.CellValueChanged += dgvData_CellValueChanged;

            SetupNavHover(btnNavDashboard);
            SetupNavHover(btnNavLeaves);
            SetupNavHover(btnNavApprovals);
            SetupNavHover(btnNavEmployees);
            SetupNavHover(btnNavRoles);
            SetupNavHover(btnNavClearances);
            SetupNavHover(btnNavConfigurations);
            SetupNavHover(btnNavLedger);

            pnlUserCard.MouseEnter += (s, e) => pnlUserCard.BackColor = Color.FromArgb(241, 245, 249);
            pnlUserCard.MouseLeave += (s, e) => pnlUserCard.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void SetupNavHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                if (btn.Tag?.ToString() != "active")
                    btn.BackColor = Color.FromArgb(248, 250, 252);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn.Tag?.ToString() != "active")
                    btn.BackColor = Color.Transparent;
            };
        }

        private void ConfigureSession()
        {
            var user = AuthService.Instance.CurrentUser;
            var emp = AuthService.Instance.CurrentEmployee;

            string fullName = emp?.FullName ?? user?.Username ?? "User";
            lblUserName.Text = fullName;
            lblUserRole.Text = user != null && user.Roles.Any() ? user.Roles[0].ToString() : "Employee";

            string initials = "U";
            if (emp != null && !string.IsNullOrWhiteSpace(emp.FirstName))
            {
                initials = emp.FirstName.Substring(0, 1) + 
                    (!string.IsNullOrWhiteSpace(emp.LastName) ? emp.LastName.Substring(0, 1) : "");
            }
            lblUserAvatar.Text = initials.ToUpperInvariant();

            bool isPrivileged = AuthService.Instance.HasRole(SystemRole.Admin) || 
                                AuthService.Instance.HasRole(SystemRole.HR_Manager);
            btnNavEmployees.Visible = isPrivileged;
            btnNavRoles.Visible = isPrivileged;
            btnNavConfigurations.Visible = isPrivileged;

            bool canApprove = AuthService.Instance.HasAnyRole(
                SystemRole.Admin,
                SystemRole.HR_Manager,
                SystemRole.Department_Head,
                SystemRole.Clearance_Officer
            );
            btnNavApprovals.Visible = canApprove;
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _isSidebarCollapsed = !_isSidebarCollapsed;
            if (_isSidebarCollapsed)
            {
                pnlSidebar.Width = 64;
                lblBrandLogo.Text = "E";
                lblBrandSub.Visible = false;
                btnNavDashboard.Text = "D";
                btnNavLeaves.Text = "L";
                btnNavApprovals.Text = "A";
                btnNavEmployees.Text = "E";
                btnNavRoles.Text = "R";
                btnNavClearances.Text = "C";
                btnNavConfigurations.Text = "S";
                btnNavLedger.Text = "R";
                lblUserName.Visible = false;
                lblUserRole.Visible = false;
                lblDropdownArrow.Visible = false;
            }
            else
            {
                pnlSidebar.Width = 230;
                lblBrandLogo.Text = "ELMS";
                lblBrandSub.Visible = true;
                btnNavDashboard.Text = "Dashboard";
                btnNavLeaves.Text = "Leave Requests";
                btnNavApprovals.Text = "Approvals";
                btnNavEmployees.Text = "Employees";
                btnNavRoles.Text = "User Roles";
                btnNavClearances.Text = "Clearances";
                btnNavConfigurations.Text = "Configurations";
                btnNavLedger.Text = "Reports & Analytics";
                lblUserName.Visible = true;
                lblUserRole.Visible = true;
                lblDropdownArrow.Visible = true;
            }
        }

        private void UserCard_Click(object sender, EventArgs e)
        {
            menuUser.Show(pnlUserCard, new Point(0, -menuUser.Height - 4));
        }

        private void menuItemProfile_Click(object sender, EventArgs e)
        {
            var emp = AuthService.Instance.CurrentEmployee ?? DataStore.Instance.Employees.FirstOrDefault();
            if (emp != null)
            {
                using (var dlg = new EmployeeDialog(emp))
                {
                    dlg.ShowDialog(this);
                }
                RefreshActiveData();
            }
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            AuthService.Instance.SignOut();
            this.Close();
        }

        private void SwitchView(ActiveView view)
        {
            _currentView = view;
            ResetNavButtons();

            pnlDashboard.Visible = (view == ActiveView.Dashboard);
            pnlGridView.Visible = (view != ActiveView.Dashboard && view != ActiveView.Configurations);
            pnlLeaveSubNav.Visible = (view == ActiveView.Leaves);
            pnlConfigSubNav.Visible = false;
            pnlReportMetrics.Visible = (view == ActiveView.Ledger);
            cboFilter3.Visible = (view == ActiveView.Ledger);
            btnSecondaryAction.Visible = (view == ActiveView.Ledger);
            if (ucConfigurations != null) ucConfigurations.Visible = (view == ActiveView.Configurations);

            switch (view)
            {
                case ActiveView.Dashboard:
                    HighlightNav(btnNavDashboard);
                    paginationControl?.ResetPage();
                    lblBreadcrumb.Text = "Dashboard  /  Overview";
                    if (pnlTabEmployeesView.Visible) ShowEmployeesTab();
                    else ShowLeavesTab();
                    break;
                case ActiveView.Leaves:
                    HighlightNav(btnNavLeaves);
                    btnLeaveTabApprovals.Visible = false;
                    btnLeaveTabTypes.Location = new System.Drawing.Point(136, 4);
                    btnLeaveTabEntitlements.Location = new System.Drawing.Point(252, 4);
                    SelectLeaveSubTab(LeaveSubTab.Requests);
                    break;
                case ActiveView.Approvals:
                    HighlightNav(btnNavApprovals);
                    lblBreadcrumb.Text = "Approvals Desk  /  Leave Approvals Queue";
                    SetupLeaveApprovalsToolbar();
                    LoadLeaveApprovalsSubGrid();
                    break;
                case ActiveView.Employees:
                    HighlightNav(btnNavEmployees);
                    lblBreadcrumb.Text = "Employee Directory  /  Personnel";
                    SetupEmployeesToolbar();
                    LoadEmployeesGrid();
                    break;
                case ActiveView.Departments:
                    HighlightNav(btnNavDepartments);
                    lblBreadcrumb.Text = "Organization  /  Departments";
                    SetupDepartmentsToolbar();
                    LoadDepartmentsGrid();
                    break;
                                case ActiveView.Roles:
                    HighlightNav(btnNavRoles);
                    lblBreadcrumb.Text = "User Roles  /  Roles & Permissions";
                    SetupRolesToolbar();
                    LoadRolesGrid();
                    break;
                case ActiveView.Clearances:
                    HighlightNav(btnNavClearances);
                    lblBreadcrumb.Text = "Clearance Desk  /  Study Leave Clearances";
                    SetupClearancesToolbar();
                    LoadClearancesGrid();
                    break;
                case ActiveView.Configurations:
                    HighlightNav(btnNavConfigurations);
                    lblBreadcrumb.Text = "System Administration  /  Configurations Desk";
                    pnlDashboard.Visible = false;
                    pnlGridView.Visible = false;
                    if (ucConfigurations != null)
                    {
                        ucConfigurations.Visible = true;
                        ucConfigurations.BringToFront();
                        ucConfigurations.RefreshData();
                    }
                    break;
                case ActiveView.Ledger:
                    HighlightNav(btnNavLedger);
                    lblBreadcrumb.Text = "Reports & Analytics  /  Leave Summary & Quota Analytics";
                    pnlReportMetrics.BringToFront();
                    pnlToolbar.BringToFront();
                    SetupLedgerToolbar();
                    LoadLedgerGrid();
                    break;
            }
        }

        private void ResetNavButtons()
        {
            foreach (var btn in new[] { btnNavDashboard, btnNavLeaves, btnNavApprovals, btnNavEmployees, btnNavDepartments, btnNavRoles, btnNavClearances, btnNavConfigurations, btnNavLedger })
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(71, 85, 105);
                btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                btn.Tag = "normal";
            }
        }

        private void HighlightNav(Button btn)
        {
            btn.BackColor = Color.FromArgb(255, 247, 237);
            btn.ForeColor = Color.FromArgb(234, 88, 12);
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.Tag = "active";
        }

        private void btnNavDashboard_Click(object sender, EventArgs e) => SwitchView(ActiveView.Dashboard);
        private void btnNavLeaves_Click(object sender, EventArgs e) => SwitchView(ActiveView.Leaves);
        private void btnNavEmployees_Click(object sender, EventArgs e) => SwitchView(ActiveView.Employees);
        private void btnNavDepartments_Click(object sender, EventArgs e) => SwitchView(ActiveView.Departments);
        private void btnNavRoles_Click(object sender, EventArgs e) => SwitchView(ActiveView.Roles);
        private void btnNavApprovals_Click(object sender, EventArgs e) => SwitchView(ActiveView.Approvals);
        private void btnNavClearances_Click(object sender, EventArgs e) => SwitchView(ActiveView.Clearances);
        private void btnNavConfigurations_Click(object sender, EventArgs e) => SwitchView(ActiveView.Configurations);
        private void btnNavLedger_Click(object sender, EventArgs e) => SwitchView(ActiveView.Ledger);

        private void btnTabEmployees_Click(object sender, EventArgs e) => ShowEmployeesTab();
        private void btnTabLeaves_Click(object sender, EventArgs e) => ShowLeavesTab();

        private void ShowEmployeesTab()
        {
            btnTabEmployees.BackColor = Color.White;
            btnTabEmployees.ForeColor = Color.FromArgb(234, 88, 12);
            btnTabEmployees.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            btnTabLeaves.BackColor = Color.Transparent;
            btnTabLeaves.ForeColor = Color.FromArgb(100, 116, 139);
            btnTabLeaves.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            pnlTabEmployeesView.Visible = true;
            pnlTabLeavesView.Visible = false;
            lblBreadcrumb.Text = "Dashboard  /  Employees";
            LoadEmployeeMetrics();
        }

        private void ShowLeavesTab()
        {
            btnTabLeaves.BackColor = Color.White;
            btnTabLeaves.ForeColor = Color.FromArgb(234, 88, 12);
            btnTabLeaves.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            btnTabEmployees.BackColor = Color.Transparent;
            btnTabEmployees.ForeColor = Color.FromArgb(100, 116, 139);
            btnTabEmployees.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            pnlTabEmployeesView.Visible = false;
            pnlTabLeavesView.Visible = true;
            lblBreadcrumb.Text = "Dashboard  /  Leaves";
            LoadLeaveMetrics();
        }

        private void LoadEmployeeMetrics()
        {
            var employees = DataStore.Instance.Employees;
            var requests = DataStore.Instance.LeaveRequests;

            int total = employees.Count;
            int active = employees.Count(e => e.IsActive);
            int onLeave = requests.Count(r => r.Status == RequestStatus.APPROVED &&
                DateTime.Today >= r.StartDate.Date && DateTime.Today <= r.EndDate.Date);
            int onDuty = Math.Max(0, active - onLeave);
            int depts = DataStore.Instance.Departments.Count;

            lblEmpKpi1Title.Text = "TOTAL EMPLOYEES";
            lblEmpKpi1Val.Text = total.ToString();
            lblEmpKpi1Sub.Text = "Total Regular Staff";

            lblEmpKpi2Title.Text = "ACTIVE ON-DUTY";
            lblEmpKpi2Val.Text = onDuty.ToString();
            lblEmpKpi2Sub.Text = "Online & Present";

            lblEmpKpi3Title.Text = "AWAY ON LEAVE";
            lblEmpKpi3Val.Text = onLeave.ToString();
            lblEmpKpi3Sub.Text = "Approved Absences";

            lblEmpKpi4Title.Text = "DEPARTMENTS";
            lblEmpKpi4Val.Text = depts.ToString();
            lblEmpKpi4Sub.Text = "Operational Units";

            pnlEmpDeptBarContainer.Invalidate();
        }

        private int _hoveredEmpSlice = -1;

        private (int centerX, int centerY, int outerRadius, int innerRadius, dynamic[] segments, float[] startAngles, float[] sweepAngles, int leftRegionW) GetEmpPieGeometry()
        {
            var employees = DataStore.Instance.Employees;
            var requests = DataStore.Instance.LeaveRequests;

            int total = employees.Count;
            int active = employees.Count(e => e.IsActive);
            int onLeave = requests.Count(r => r.Status == RequestStatus.APPROVED &&
                DateTime.Today >= r.StartDate.Date && DateTime.Today <= r.EndDate.Date);
            int onDuty = Math.Max(0, active - onLeave);
            int inClearance = requests.Count(r => r.Status == RequestStatus.CLEARANCE_IN_PROGRESS);
            int inactive = employees.Count(e => !e.IsActive);

            int safeTotal = Math.Max(1, total);

            int totalW = pnlEmpDeptBarContainer.ClientSize.Width;
            int totalH = pnlEmpDeptBarContainer.ClientSize.Height;

            int leftRegionW = Math.Max(320, (int)(totalW * 0.44f));
            int chartDiameter = Math.Min(220, Math.Min(leftRegionW - 40, totalH - 90));
            chartDiameter = Math.Max(160, chartDiameter);

            int outerRadius = chartDiameter / 2;
            int innerRadius = (int)(outerRadius * 0.65);

            int centerX = leftRegionW / 2;
            int centerY = 24 + outerRadius;

            var segments = new[]
            {
                new { Label = "Active On-Duty", Count = onDuty, Color = Color.FromArgb(22, 163, 74) },      // #16A34A
                new { Label = "On Leave", Count = onLeave, Color = Color.FromArgb(234, 88, 12) },          // #EA580C
                new { Label = "In Clearance", Count = inClearance, Color = Color.FromArgb(37, 99, 235) },   // #2563EB
                new { Label = "Inactive", Count = inactive, Color = Color.FromArgb(148, 163, 184) }        // #94A3B8
            };

            float startAngle = -90f;
            float[] startAngles = new float[segments.Length];
            float[] sweepAngles = new float[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                float sweep = ((float)segments[i].Count / safeTotal) * 360f;
                startAngles[i] = startAngle;
                sweepAngles[i] = sweep;
                startAngle += sweep;
            }

            return (centerX, centerY, outerRadius, innerRadius, segments, startAngles, sweepAngles, leftRegionW);
        }

        private void pnlEmpDeptBarContainer_MouseMove(object sender, MouseEventArgs e)
        {
            var geo = GetEmpPieGeometry();
            int dx = e.X - geo.centerX;
            int dy = e.Y - geo.centerY;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            int hoveredIndex = -1;
            if (dist >= geo.innerRadius - 4 && dist <= geo.outerRadius + 8)
            {
                double angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;
                double adjAngle = (angle + 90.0 + 360.0) % 360.0;

                for (int i = 0; i < geo.segments.Length; i++)
                {
                    double sAngle = (geo.startAngles[i] + 90.0 + 360.0) % 360.0;
                    double eAngle = sAngle + geo.sweepAngles[i];

                    if (adjAngle >= sAngle && adjAngle < eAngle)
                    {
                        hoveredIndex = i;
                        break;
                    }
                }
            }

            if (hoveredIndex != _hoveredEmpSlice)
            {
                _hoveredEmpSlice = hoveredIndex;
                pnlEmpDeptBarContainer.Invalidate();
            }
        }

        private void pnlEmpDeptBarContainer_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredEmpSlice != -1)
            {
                _hoveredEmpSlice = -1;
                pnlEmpDeptBarContainer.Invalidate();
            }
        }

        private void pnlEmpDeptBarContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var geo = GetEmpPieGeometry();
            var employees = DataStore.Instance.Employees;
            int total = employees.Count;
            int safeTotal = Math.Max(1, total);

            Rectangle outerRect = new Rectangle(geo.centerX - geo.outerRadius, geo.centerY - geo.outerRadius, geo.outerRadius * 2, geo.outerRadius * 2);
            Rectangle innerRect = new Rectangle(geo.centerX - geo.innerRadius, geo.centerY - geo.innerRadius, geo.innerRadius * 2, geo.innerRadius * 2);

            // =====================================================================
            // 1. LEFT SIDE: CIRCLE DONUT CHART (Personnel Status & Availability)
            // =====================================================================
            for (int i = 0; i < geo.segments.Length; i++)
            {
                if (geo.sweepAngles[i] <= 0) continue;

                var seg = geo.segments[i];
                Rectangle drawRect = outerRect;

                if (i == _hoveredEmpSlice)
                {
                    double midAngle = (geo.startAngles[i] + geo.sweepAngles[i] / 2.0) * Math.PI / 180.0;
                    int explodeX = (int)(Math.Cos(midAngle) * 5);
                    int explodeY = (int)(Math.Sin(midAngle) * 5);
                    drawRect.Offset(explodeX, explodeY);
                }

                using (var brush = new SolidBrush(seg.Color))
                {
                    e.Graphics.FillPie(brush, drawRect, geo.startAngles[i], geo.sweepAngles[i]);
                }
            }

            // Cut out inner hole
            using (var holeBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(holeBrush, innerRect);
            }

            // Radial crisp white separators
            for (int i = 0; i < geo.segments.Length; i++)
            {
                if (geo.sweepAngles[i] <= 0) continue;

                double rad = geo.startAngles[i] * Math.PI / 180.0;
                float cos = (float)Math.Cos(rad);
                float sin = (float)Math.Sin(rad);

                PointF pInner = new PointF(geo.centerX + cos * geo.innerRadius, geo.centerY + sin * geo.innerRadius);
                PointF pOuter = new PointF(geo.centerX + cos * (geo.outerRadius + 1), geo.centerY + sin * (geo.outerRadius + 1));

                using (var sepPen = new Pen(Color.White, 2.5f))
                {
                    e.Graphics.DrawLine(sepPen, pInner, pOuter);
                }
            }

            // Outer and inner rim borders
            using (var rimPen = new Pen(Color.FromArgb(241, 245, 249), 1.5f))
            {
                e.Graphics.DrawEllipse(rimPen, outerRect);
                e.Graphics.DrawEllipse(rimPen, innerRect);
            }

            // Center Text inside Donut Hole: Total Employees count + "Total Staff"
            using (var fontTotal = new Font("Segoe UI", 22f, FontStyle.Bold))
            using (var fontTotalSub = new Font("Segoe UI", 8.5f, FontStyle.Regular))
            using (var valBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (var subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                string valStr = total.ToString();
                string subStr = "Total Staff";

                var valSz = e.Graphics.MeasureString(valStr, fontTotal);
                var subSz = e.Graphics.MeasureString(subStr, fontTotalSub);

                float blockH = valSz.Height + subSz.Height - 6;
                float startY = innerRect.Y + (innerRect.Height - blockH) / 2f;

                float valX = innerRect.X + (innerRect.Width - valSz.Width) / 2f;
                float subX = innerRect.X + (innerRect.Width - subSz.Width) / 2f;

                e.Graphics.DrawString(valStr, fontTotal, valBrush, valX, startY);
                e.Graphics.DrawString(subStr, fontTotalSub, subBrush, subX, startY + valSz.Height - 6);
            }

            // Hover tooltip
            if (_hoveredEmpSlice >= 0 && _hoveredEmpSlice < geo.segments.Length)
            {
                var hSeg = geo.segments[_hoveredEmpSlice];
                double hPct = ((double)hSeg.Count / safeTotal) * 100.0;
                string hoverText = $"{hSeg.Label}: {hSeg.Count} staff ({hPct:F1}%)";

                using (var fontTip = new Font("Segoe UI", 9f, FontStyle.Bold))
                using (var bgBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sz = e.Graphics.MeasureString(hoverText, fontTip);
                    int tipX = geo.centerX - (int)(sz.Width / 2);
                    int tipY = outerRect.Y - 18;

                    var tipRect = new Rectangle(tipX - 8, tipY - 3, (int)sz.Width + 16, (int)sz.Height + 6);
                    e.Graphics.FillRectangle(bgBrush, tipRect);
                    e.Graphics.DrawString(hoverText, fontTip, textBrush, tipX, tipY);
                }
            }

            // =====================================================================
            // 2. BOTTOM LEGEND: CLEAN ONLY, STRICTLY NO PERCENTAGES
            // =====================================================================
            int legendY = outerRect.Bottom + 26;
            int totalLegW = 0;
            Size[] legSizes = new Size[geo.segments.Length];

            using (var fontLeg = new Font("Segoe UI", 9f, FontStyle.Regular))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    legSizes[i] = TextRenderer.MeasureText(geo.segments[i].Label, fontLeg);
                    totalLegW += 10 + 6 + legSizes[i].Width + 16;
                }
            }

            int curLegX = Math.Max(10, (geo.leftRegionW - totalLegW) / 2);

            using (var fontLeg = new Font("Segoe UI", 9f, FontStyle.Regular))
            using (var fontBold = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    var seg = geo.segments[i];
                    bool isHover = (i == _hoveredEmpSlice);

                    using (var bulletBrush = new SolidBrush(seg.Color))
                    {
                        e.Graphics.FillEllipse(bulletBrush, curLegX, legendY + 4, 9, 9);
                    }

                    var f = isHover ? fontBold : fontLeg;
                    e.Graphics.DrawString(seg.Label, f, textBrush, curLegX + 15, legendY);

                    curLegX += 15 + legSizes[i].Width + 16;
                }
            }

            // =====================================================================
            // 3. VERTICAL DIVIDER SEPARATING CIRCLE CHART AND ASIDE BAR LIST
            // =====================================================================
            int dividerX = geo.leftRegionW + 12;
            using (var divPen = new Pen(Color.FromArgb(241, 245, 249), 1.5f))
            {
                e.Graphics.DrawLine(divPen, dividerX, 16, dividerX, pnlEmpDeptBarContainer.ClientSize.Height - 16);
            }

            // =====================================================================
            // 4. RIGHT ASIDE BAR LIST: WORKFORCE BY DEPARTMENT (HRMS BarList Style)
            // =====================================================================
            int asideX = dividerX + 24;
            int asideW = pnlEmpDeptBarContainer.ClientSize.Width - asideX - 20;

            if (asideW > 120)
            {
                // Aside Header
                using (var fontHeaderTitle = new Font("Segoe UI", 10.5f, FontStyle.Bold))
                using (var fontHeaderSub = new Font("Segoe UI", 8.5f, FontStyle.Regular))
                using (var titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    e.Graphics.DrawString("Workforce by Department", fontHeaderTitle, titleBrush, asideX, 12);
                    e.Graphics.DrawString("Ranked headcount distribution and share across operational divisions", fontHeaderSub, subBrush, asideX, 32);
                }

                // Compute Department Staff Counts & Percentages
                var depts = DataStore.Instance.Departments;
                Color[] deptColors = new[]
                {
                    Color.FromArgb(37, 99, 235),   // #2563EB Blue
                    Color.FromArgb(234, 88, 12),   // #EA580C Orange
                    Color.FromArgb(22, 163, 74),   // #16A34A Green
                    Color.FromArgb(139, 92, 246),  // #8B5CF6 Purple
                    Color.FromArgb(13, 148, 136)   // #0D9488 Teal
                };

                var deptRows = depts.Select((d, idx) =>
                {
                    int count = employees.Count(emp => emp.DepartmentId == d.Id || emp.DepartmentName == d.Name);
                    double share = ((double)count / safeTotal) * 100.0;
                    Color color = deptColors[idx % deptColors.Length];
                    return new { d.Id, d.Name, d.Code, Count = count, Share = share, Color = color };
                }).OrderByDescending(x => x.Count).ToList();

                int curY = 64;
                int rowGap = 46;
                int trackHeight = 7;
                int trackWidth = asideW - 10;

                using (var fontLabel = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (var fontVal = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var fontPct = new Font("Segoe UI", 9f, FontStyle.Regular))
                using (var labelBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (var valBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var pctBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                using (var trackBgBrush = new SolidBrush(Color.FromArgb(241, 245, 249)))
                {
                    foreach (var item in deptRows)
                    {
                        if (curY + 30 > pnlEmpDeptBarContainer.ClientSize.Height) break;

                        // Bullet indicator
                        using (var dotBrush = new SolidBrush(item.Color))
                        {
                            e.Graphics.FillEllipse(dotBrush, asideX, curY + 4, 8, 8);
                        }

                        // Label (Left)
                        e.Graphics.DrawString(item.Name, fontLabel, labelBrush, asideX + 14, curY);

                        // Value & Share (Right)
                        string valText = $"{item.Count} staff";
                        string pctText = $"  {item.Share:F1}%";

                        var valSz = e.Graphics.MeasureString(valText, fontVal);
                        var pctSz = e.Graphics.MeasureString(pctText, fontPct);

                        float rightTextX = asideX + trackWidth - (valSz.Width + pctSz.Width);
                        e.Graphics.DrawString(valText, fontVal, valBrush, rightTextX, curY);
                        e.Graphics.DrawString(pctText, fontPct, pctBrush, rightTextX + valSz.Width, curY);

                        // Horizontal Meter Track
                        int barTrackY = curY + 22;
                        Rectangle trackRect = new Rectangle(asideX, barTrackY, trackWidth, trackHeight);

                        using (var pathBg = CreateRoundedRectanglePath(trackRect, 3))
                        {
                            e.Graphics.FillPath(trackBgBrush, pathBg);
                        }

                        int fillWidth = Math.Max(0, (int)(trackWidth * (item.Share / 100.0)));
                        if (fillWidth > 2)
                        {
                            Rectangle fillRect = new Rectangle(asideX, barTrackY, fillWidth, trackHeight);
                            using (var pathFill = CreateRoundedRectanglePath(fillRect, 3))
                            using (var fillBrush = new SolidBrush(item.Color))
                            {
                                e.Graphics.FillPath(fillBrush, pathFill);
                            }
                        }

                        curY += rowGap;
                    }
                }
            }
        }

        private void LoadLeaveMetrics()
        {
            var reqs = DataStore.Instance.LeaveRequests;
            int total = reqs.Count;
            int pending = reqs.Count(r => r.Status == RequestStatus.SUBMITTED || r.Status == RequestStatus.UNDER_REVIEW);
            int clearance = reqs.Count(r => r.Status == RequestStatus.CLEARANCE_IN_PROGRESS);
            int active = reqs.Count(r => r.Status == RequestStatus.APPROVED &&
                DateTime.Today >= r.StartDate.Date && DateTime.Today <= r.EndDate.Date);

            lblLeaveKpi1Val.Text = total.ToString();
            lblLeaveKpi1Sub.Text = "All Submitted Requests";
            lblLeaveKpi2Val.Text = pending.ToString();
            lblLeaveKpi2Sub.Text = "Awaiting Decision";
            lblLeaveKpi3Val.Text = clearance.ToString();
            lblLeaveKpi3Sub.Text = "Clearance Review";
            lblLeaveKpi4Val.Text = active.ToString();
            lblLeaveKpi4Sub.Text = "Currently Away";

            pnlPieContainer.Invalidate();
        }

        private (int centerX, int centerY, int outerRadius, int innerRadius, dynamic[] segments, float[] startAngles, float[] sweepAngles, int leftRegionW) GetPieGeometry()
        {
            var reqs = DataStore.Instance.LeaveRequests;
            int total = reqs.Count;
            int approved = reqs.Count(r => r.Status == RequestStatus.APPROVED);
            int pending = reqs.Count(r => r.Status == RequestStatus.SUBMITTED || r.Status == RequestStatus.UNDER_REVIEW);
            int clearance = reqs.Count(r => r.Status == RequestStatus.CLEARANCE_IN_PROGRESS);
            int rejected = reqs.Count(r => r.Status == RequestStatus.REJECTED);

            int safeTotal = Math.Max(1, total);

            int totalW = pnlPieContainer.ClientSize.Width;
            int totalH = pnlPieContainer.ClientSize.Height;

            int leftRegionW = Math.Max(320, (int)(totalW * 0.44f));
            int chartDiameter = Math.Min(220, Math.Min(leftRegionW - 40, totalH - 90));
            chartDiameter = Math.Max(160, chartDiameter);

            int outerRadius = chartDiameter / 2;
            int innerRadius = (int)(outerRadius * 0.65);

            int centerX = leftRegionW / 2;
            int centerY = 24 + outerRadius;

            var segments = new[]
            {
                new { Label = "Approved", Count = approved, Color = Color.FromArgb(22, 163, 74) },       // #16A34A
                new { Label = "Under Review", Count = pending, Color = Color.FromArgb(234, 88, 12) },    // #EA580C
                new { Label = "In Clearance", Count = clearance, Color = Color.FromArgb(37, 99, 235) },  // #2563EB
                new { Label = "Rejected", Count = rejected, Color = Color.FromArgb(220, 38, 38) }        // #DC2626
            };

            float startAngle = -90f;
            float[] startAngles = new float[segments.Length];
            float[] sweepAngles = new float[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                float sweep = ((float)segments[i].Count / safeTotal) * 360f;
                startAngles[i] = startAngle;
                sweepAngles[i] = sweep;
                startAngle += sweep;
            }

            return (centerX, centerY, outerRadius, innerRadius, segments, startAngles, sweepAngles, leftRegionW);
        }

        private void pnlPieContainer_MouseMove(object sender, MouseEventArgs e)
        {
            var geo = GetPieGeometry();
            int dx = e.X - geo.centerX;
            int dy = e.Y - geo.centerY;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            int hoveredIndex = -1;
            if (dist >= geo.innerRadius - 4 && dist <= geo.outerRadius + 8)
            {
                double angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;
                double adjAngle = (angle + 90.0 + 360.0) % 360.0;

                for (int i = 0; i < geo.segments.Length; i++)
                {
                    double sAngle = (geo.startAngles[i] + 90.0 + 360.0) % 360.0;
                    double eAngle = sAngle + geo.sweepAngles[i];

                    if (adjAngle >= sAngle && adjAngle < eAngle)
                    {
                        hoveredIndex = i;
                        break;
                    }
                }
            }

            if (hoveredIndex != _hoveredPieSlice)
            {
                _hoveredPieSlice = hoveredIndex;
                pnlPieContainer.Invalidate();
            }
        }

        private void pnlPieContainer_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredPieSlice != -1)
            {
                _hoveredPieSlice = -1;
                pnlPieContainer.Invalidate();
            }
        }

        private void pnlPieContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var geo = GetPieGeometry();
            var reqs = DataStore.Instance.LeaveRequests;
            int total = reqs.Count;
            int safeTotal = Math.Max(1, total);

            Rectangle outerRect = new Rectangle(geo.centerX - geo.outerRadius, geo.centerY - geo.outerRadius, geo.outerRadius * 2, geo.outerRadius * 2);
            Rectangle innerRect = new Rectangle(geo.centerX - geo.innerRadius, geo.centerY - geo.innerRadius, geo.innerRadius * 2, geo.innerRadius * 2);

            // =====================================================================
            // 1. LEFT SIDE: CIRCLE DONUT CHART (HRMS Style - Clean Donut Ring)
            // =====================================================================
            for (int i = 0; i < geo.segments.Length; i++)
            {
                if (geo.sweepAngles[i] <= 0) continue;

                var seg = geo.segments[i];
                Rectangle drawRect = outerRect;

                if (i == _hoveredPieSlice)
                {
                    double midAngle = (geo.startAngles[i] + geo.sweepAngles[i] / 2.0) * Math.PI / 180.0;
                    int explodeX = (int)(Math.Cos(midAngle) * 5);
                    int explodeY = (int)(Math.Sin(midAngle) * 5);
                    drawRect.Offset(explodeX, explodeY);
                }

                using (var brush = new SolidBrush(seg.Color))
                {
                    e.Graphics.FillPie(brush, drawRect, geo.startAngles[i], geo.sweepAngles[i]);
                }
            }

            // Cut out inner hole to create authentic HRMS Donut Ring
            using (var holeBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(holeBrush, innerRect);
            }

            // Radial crisp white separators between slices
            for (int i = 0; i < geo.segments.Length; i++)
            {
                if (geo.sweepAngles[i] <= 0) continue;

                double rad = geo.startAngles[i] * Math.PI / 180.0;
                float cos = (float)Math.Cos(rad);
                float sin = (float)Math.Sin(rad);

                PointF pInner = new PointF(geo.centerX + cos * geo.innerRadius, geo.centerY + sin * geo.innerRadius);
                PointF pOuter = new PointF(geo.centerX + cos * (geo.outerRadius + 1), geo.centerY + sin * (geo.outerRadius + 1));

                using (var sepPen = new Pen(Color.White, 2.5f))
                {
                    e.Graphics.DrawLine(sepPen, pInner, pOuter);
                }
            }

            // Subtle outer and inner rim rings for clean modern polish
            using (var rimPen = new Pen(Color.FromArgb(241, 245, 249), 1.5f))
            {
                e.Graphics.DrawEllipse(rimPen, outerRect);
                e.Graphics.DrawEllipse(rimPen, innerRect);
            }

            // Center Text inside Donut Hole: Total Count + "Total Requests"
            using (var fontTotal = new Font("Segoe UI", 22f, FontStyle.Bold))
            using (var fontTotalSub = new Font("Segoe UI", 8.5f, FontStyle.Regular))
            using (var valBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (var subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                string valStr = total.ToString();
                string subStr = "Total Requests";

                var valSz = e.Graphics.MeasureString(valStr, fontTotal);
                var subSz = e.Graphics.MeasureString(subStr, fontTotalSub);

                float blockH = valSz.Height + subSz.Height - 6;
                float startY = innerRect.Y + (innerRect.Height - blockH) / 2f;

                float valX = innerRect.X + (innerRect.Width - valSz.Width) / 2f;
                float subX = innerRect.X + (innerRect.Width - subSz.Width) / 2f;

                e.Graphics.DrawString(valStr, fontTotal, valBrush, valX, startY);
                e.Graphics.DrawString(subStr, fontTotalSub, subBrush, subX, startY + valSz.Height - 6);
            }

            // Hover tooltip if slice is hovered
            if (_hoveredPieSlice >= 0 && _hoveredPieSlice < geo.segments.Length)
            {
                var hSeg = geo.segments[_hoveredPieSlice];
                double hPct = ((double)hSeg.Count / safeTotal) * 100.0;
                string hoverText = $"{hSeg.Label}: {hSeg.Count} requests ({hPct:F1}%)";

                using (var fontTip = new Font("Segoe UI", 9f, FontStyle.Bold))
                using (var bgBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sz = e.Graphics.MeasureString(hoverText, fontTip);
                    int tipX = geo.centerX - (int)(sz.Width / 2);
                    int tipY = outerRect.Y - 18;

                    var tipRect = new Rectangle(tipX - 8, tipY - 3, (int)sz.Width + 16, (int)sz.Height + 6);
                    e.Graphics.FillRectangle(bgBrush, tipRect);
                    e.Graphics.DrawString(hoverText, fontTip, textBrush, tipX, tipY);
                }
            }

            // =====================================================================
            // 2. BOTTOM LEGEND (UNDER THE CIRCLE): CLEAN ONLY, STRICTLY NO PERCENTAGES
            // =====================================================================
            int legendY = outerRect.Bottom + 26;
            int totalLegW = 0;
            Size[] legSizes = new Size[geo.segments.Length];

            using (var fontLeg = new Font("Segoe UI", 9f, FontStyle.Regular))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    legSizes[i] = TextRenderer.MeasureText(geo.segments[i].Label, fontLeg);
                    totalLegW += 10 + 6 + legSizes[i].Width + 16;
                }
            }

            int curLegX = Math.Max(10, (geo.leftRegionW - totalLegW) / 2);

            using (var fontLeg = new Font("Segoe UI", 9f, FontStyle.Regular))
            using (var fontBold = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    var seg = geo.segments[i];
                    bool isHover = (i == _hoveredPieSlice);

                    using (var bulletBrush = new SolidBrush(seg.Color))
                    {
                        e.Graphics.FillEllipse(bulletBrush, curLegX, legendY + 4, 9, 9);
                    }

                    var f = isHover ? fontBold : fontLeg;
                    e.Graphics.DrawString(seg.Label, f, textBrush, curLegX + 15, legendY);

                    curLegX += 15 + legSizes[i].Width + 16;
                }
            }

            // =====================================================================
            // 3. VERTICAL DIVIDER SEPARATING CIRCLE CHART AND ASIDE BAR LIST
            // =====================================================================
            int dividerX = geo.leftRegionW + 12;
            using (var divPen = new Pen(Color.FromArgb(241, 245, 249), 1.5f))
            {
                e.Graphics.DrawLine(divPen, dividerX, 16, dividerX, pnlPieContainer.ClientSize.Height - 16);
            }

            // =====================================================================
            // 4. RIGHT ASIDE BAR LIST: REQUEST LEAVE TYPE PERCENTAGES (HRMS BarList Style)
            // =====================================================================
            int asideX = dividerX + 24;
            int asideW = pnlPieContainer.ClientSize.Width - asideX - 20;

            if (asideW > 120)
            {
                // Aside Header
                using (var fontHeaderTitle = new Font("Segoe UI", 10.5f, FontStyle.Bold))
                using (var fontHeaderSub = new Font("Segoe UI", 8.5f, FontStyle.Regular))
                using (var titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    e.Graphics.DrawString("Request Volume by Leave Type", fontHeaderTitle, titleBrush, asideX, 12);
                    e.Graphics.DrawString("Ranked distribution and percentage share of all leave categories", fontHeaderSub, subBrush, asideX, 32);
                }

                // Compute Leave Type Counts & Percentages
                var leaveTypes = DataStore.Instance.LeaveTypes;
                var typeRows = leaveTypes.Select(lt =>
                {
                    int count = reqs.Count(r => r.LeaveTypeId == lt.Id);
                    double share = ((double)count / safeTotal) * 100.0;
                    Color color = lt.Code switch
                    {
                        "ANNUAL" => Color.FromArgb(234, 88, 12),      // #EA580C Orange
                        "SICK" => Color.FromArgb(37, 99, 235),        // #2563EB Blue
                        "STUDY" => Color.FromArgb(139, 92, 246),      // #8B5CF6 Purple
                        "MATERNITY" => Color.FromArgb(236, 72, 153),  // #EC4899 Pink
                        _ => Color.FromArgb(16, 185, 129)             // #10B981 Emerald
                    };
                    return new { lt.Id, lt.Name, lt.Code, Count = count, Share = share, Color = color };
                }).OrderByDescending(x => x.Count).ToList();

                int curY = 64;
                int rowGap = 46;
                int trackHeight = 7;
                int trackWidth = asideW - 10;

                using (var fontLabel = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (var fontVal = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var fontPct = new Font("Segoe UI", 9f, FontStyle.Regular))
                using (var labelBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (var valBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var pctBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                using (var trackBgBrush = new SolidBrush(Color.FromArgb(241, 245, 249)))
                {
                    foreach (var item in typeRows)
                    {
                        if (curY + 30 > pnlPieContainer.ClientSize.Height) break;

                        // Bullet indicator
                        using (var dotBrush = new SolidBrush(item.Color))
                        {
                            e.Graphics.FillEllipse(dotBrush, asideX, curY + 4, 8, 8);
                        }

                        // Label (Left)
                        e.Graphics.DrawString(item.Name, fontLabel, labelBrush, asideX + 14, curY);

                        // Value & Share (Right)
                        string valText = $"{item.Count} requests";
                        string pctText = $"  {item.Share:F1}%";

                        var valSz = e.Graphics.MeasureString(valText, fontVal);
                        var pctSz = e.Graphics.MeasureString(pctText, fontPct);

                        float rightTextX = asideX + trackWidth - (valSz.Width + pctSz.Width);
                        e.Graphics.DrawString(valText, fontVal, valBrush, rightTextX, curY);
                        e.Graphics.DrawString(pctText, fontPct, pctBrush, rightTextX + valSz.Width, curY);

                        // Horizontal Meter Track (HRMS BarList style)
                        int barTrackY = curY + 22;
                        Rectangle trackRect = new Rectangle(asideX, barTrackY, trackWidth, trackHeight);

                        // Draw background track with rounded ends
                        using (var pathBg = CreateRoundedRectanglePath(trackRect, 3))
                        {
                            e.Graphics.FillPath(trackBgBrush, pathBg);
                        }

                        // Draw filled progress bar
                        int fillWidth = Math.Max(0, (int)(trackWidth * (item.Share / 100.0)));
                        if (fillWidth > 2)
                        {
                            Rectangle fillRect = new Rectangle(asideX, barTrackY, fillWidth, trackHeight);
                            using (var pathFill = CreateRoundedRectanglePath(fillRect, 3))
                            using (var fillBrush = new SolidBrush(item.Color))
                            {
                                e.Graphics.FillPath(fillBrush, pathFill);
                            }
                        }

                        curY += rowGap;
                    }
                }
            }
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (rect.Width <= 0 || rect.Height <= 0) return path;

            int d = radius * 2;
            if (d > rect.Height) d = rect.Height;
            if (d > rect.Width) d = rect.Width;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btnLeaveTabRequests_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Requests);
        private void btnLeaveTabApprovals_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Approvals);
        private void btnLeaveTabTypes_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Types);
        private void btnLeaveTabEntitlements_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Entitlements);

        private void SelectLeaveSubTab(LeaveSubTab tab)
        {
            _currentLeaveSubTab = tab;
            paginationControl?.ResetPage();
            ResetLeaveSubTabButtons();

            switch (tab)
            {
                case LeaveSubTab.Requests:
                    HighlightLeaveSubTab(btnLeaveTabRequests);
                    lblBreadcrumb.Text = "Leave Requests  /  My Requests";
                    SetupLeaveRequestsToolbar();
                    LoadLeaveRequestsSubGrid();
                    break;
                case LeaveSubTab.Approvals:
                    HighlightLeaveSubTab(btnLeaveTabApprovals);
                    lblBreadcrumb.Text = "Leave Requests  /  Approvals Desk";
                    SetupLeaveApprovalsToolbar();
                    LoadLeaveApprovalsSubGrid();
                    break;
                case LeaveSubTab.Types:
                    HighlightLeaveSubTab(btnLeaveTabTypes);
                    lblBreadcrumb.Text = "Leave Requests  /  Leave Types & Policies";
                    SetupLeaveTypesToolbar();
                    LoadLeaveTypesSubGrid();
                    break;
                case LeaveSubTab.Entitlements:
                    HighlightLeaveSubTab(btnLeaveTabEntitlements);
                    lblBreadcrumb.Text = "Leave Requests  /  Quota Entitlements";
                    SetupLeaveEntitlementsToolbar();
                    LoadLeaveEntitlementsSubGrid();
                    break;
            }
        }

        private void HighlightLeaveSubTab(Button btn)
        {
            btn.BackColor = Color.FromArgb(255, 247, 237);
            btn.ForeColor = Color.FromArgb(234, 88, 12);
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void ResetLeaveSubTabButtons()
        {
            foreach (var b in new[] { btnLeaveTabRequests, btnLeaveTabApprovals, btnLeaveTabTypes, btnLeaveTabEntitlements })
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(100, 116, 139);
                b.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }
        }

        private void pnlLeaveSubNav_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlLeaveSubNav.Height - 1, pnlLeaveSubNav.Width, pnlLeaveSubNav.Height - 1);
            }
        }

        private void SetupLeaveRequestsToolbar()
        {
            txtSearch.PlaceholderText = "Search by Emp, Req #, Type...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "All Statuses", "SUBMITTED", "UNDER_REVIEW", "CLEARANCE_IN_PROGRESS", "APPROVED", "REJECTED", "CANCELLED" });
            cboFilter1.SelectedIndex = 0;

            bool isAdminOrMgr = AuthService.Instance.HasAnyRole(SystemRole.Admin, SystemRole.HR_Manager, SystemRole.Department_Head);
            cboFilter2.Visible = isAdminOrMgr;
            cboFilter2.Items.Clear();
            if (isAdminOrMgr)
            {
                cboFilter2.Items.AddRange(new object[] { "All Employee Requests", "My Requests Only" });
                cboFilter2.SelectedIndex = 0;
            }

            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "+ New Request";
        }

        private void LoadLeaveRequestsSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("ReqNumber", "Request #");
            dgvData.Columns.Add("EmpName", "Employee");
            dgvData.Columns.Add("EmpCode", "Emp Code");
            dgvData.Columns.Add("Type", "Leave Type");
            dgvData.Columns.Add("StartDate", "Start Date");
            dgvData.Columns.Add("EndDate", "End Date");
            dgvData.Columns.Add("Days", "Days");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "All Statuses";
            string scopeFilter = cboFilter2.Visible ? (cboFilter2.SelectedItem?.ToString() ?? "All Employee Requests") : "My Requests Only";

            var currentUser = AuthService.Instance.CurrentUser;
            int currentEmpId = currentUser?.EmployeeId ?? -1;
            bool isRegularEmployee = !AuthService.Instance.HasAnyRole(SystemRole.Admin, SystemRole.HR_Manager, SystemRole.Department_Head, SystemRole.Clearance_Officer);

            foreach (var r in DataStore.Instance.LeaveRequests.OrderByDescending(x => x.CreatedAt))
            {
                if (isRegularEmployee || scopeFilter == "My Requests Only")
                {
                    if (r.EmployeeId != currentEmpId) continue;
                }

                if (statusFilter != "All Statuses" && r.Status.ToString() != statusFilter) continue;

                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == r.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == r.LeaveTypeId);

                string empCode = emp?.EmployeeCode ?? "N/A";
                string empName = emp?.FullName ?? "N/A";
                string typeName = lt?.Name ?? "N/A";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = r.RequestNumber.ToLowerInvariant().Contains(search) ||
                                 empCode.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 typeName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    r.RequestNumber, empName, empCode, typeName,
                    r.StartDate.ToString("yyyy-MM-dd"), r.EndDate.ToString("yyyy-MM-dd"),
                    r.DurationDays, r.Status.ToString()
                );
                dgvData.Rows[idx].Tag = r;
            }
        }

        private void SetupLeaveApprovalsToolbar()
        {
            txtSearch.PlaceholderText = "Search approvals by employee, type...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "Pending Approval", "Approved", "Rejected", "All Approvals" });
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = true;
            cboFilter2.Items.Clear();
            cboFilter2.Items.Add("All Departments");
            foreach (var d in DataStore.Instance.Departments) cboFilter2.Items.Add(d.Name);
            cboFilter2.SelectedIndex = 0;

            btnToolbarAction.Visible = false;
        }

        private void LoadLeaveApprovalsSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("ReqNumber", "Request #");
            dgvData.Columns.Add("EmpName", "Employee");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("Type", "Leave Type");
            dgvData.Columns.Add("Dates", "Date Range");
            dgvData.Columns.Add("Days", "Days");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string filter = cboFilter1.SelectedItem?.ToString() ?? "Pending Approval";
            string deptFilter = cboFilter2.SelectedItem?.ToString() ?? "All Departments";

            foreach (var r in DataStore.Instance.LeaveRequests.OrderByDescending(x => x.CreatedAt))
            {
                if (filter == "Pending Approval")
                {
                    if (r.Status != RequestStatus.SUBMITTED &&
                        r.Status != RequestStatus.UNDER_REVIEW &&
                        r.Status != RequestStatus.CLEARANCE_IN_PROGRESS)
                        continue;
                }
                else if (filter == "Approved")
                {
                    if (r.Status != RequestStatus.APPROVED) continue;
                }
                else if (filter == "Rejected")
                {
                    if (r.Status != RequestStatus.REJECTED) continue;
                }

                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == r.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == r.LeaveTypeId);

                string deptName = emp?.DepartmentName ?? "N/A";
                if (deptFilter != "All Departments" && deptName != deptFilter) continue;

                string empName = emp?.FullName ?? "N/A";
                string typeName = lt?.Name ?? "N/A";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = r.RequestNumber.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 typeName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    r.RequestNumber, empName, deptName, typeName,
                    $"{r.StartDate:yyyy-MM-dd} to {r.EndDate:yyyy-MM-dd}", r.DurationDays, r.Status.ToString()
                );
                dgvData.Rows[idx].Tag = r;
            }
        }

        private void SetupLeaveTypesToolbar()
        {
            txtSearch.PlaceholderText = "Search leave type code or name...";
            cboFilter1.Visible = false;
            cboFilter2.Visible = false;

            bool isAdmin = AuthService.Instance.HasRole(SystemRole.Admin);
            btnToolbarAction.Visible = isAdmin;
            btnToolbarAction.Text = "+ New Type";
        }

        private void LoadLeaveTypesSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("Code", "Type Code");
            dgvData.Columns.Add("Name", "Leave Type Name");
            dgvData.Columns.Add("Days", "Annual Quota");
            dgvData.Columns.Add("Months", "Min Service");
            dgvData.Columns.Add("Clearance", "Clearance Required");

            bool isAdmin = AuthService.Instance.HasRole(SystemRole.Admin);
            if (isAdmin)
            {
                var actionCol = new DataGridViewButtonColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    Text = "⋮",
                    UseColumnTextForButtonValue = true,
                    Width = 65,
                    FlatStyle = FlatStyle.Flat
                };
                dgvData.Columns.Add(actionCol);
            }

            string search = txtSearch.Text.Trim().ToLowerInvariant();

            foreach (var lt in DataStore.Instance.LeaveTypes.OrderBy(l => l.Code))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    bool match = lt.Code.ToLowerInvariant().Contains(search) ||
                                 lt.Name.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    lt.Code, lt.Name, $"{lt.EntitlementDays} days/yr",
                    $"{lt.MinimumServiceMonths} mos", lt.RequiresClearance ? "YES" : "NO"
                );
                dgvData.Rows[idx].Tag = lt;
            }
        }

        private void SetupLeaveEntitlementsToolbar()
        {
            txtSearch.PlaceholderText = "Search employee or leave type...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.Add("All Leave Types");
            foreach (var lt in DataStore.Instance.LeaveTypes) cboFilter1.Items.Add(lt.Name);
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;

            bool isAdmin = AuthService.Instance.HasRole(SystemRole.Admin);
            btnToolbarAction.Visible = isAdmin;
            btnToolbarAction.Text = "⚡ Generate Entitlements";
        }

        private void LoadLeaveEntitlementsSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("EmpCode", "Emp Code");
            dgvData.Columns.Add("EmpName", "Employee Name");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("Type", "Leave Type");
            dgvData.Columns.Add("Base", "Base");
            dgvData.Columns.Add("Carry", "Carry");
            dgvData.Columns.Add("Bonus", "Bonus");
            dgvData.Columns.Add("Allocated", "Total");
            dgvData.Columns.Add("Used", "Used");
            dgvData.Columns.Add("Balance", "Balance");
            dgvData.Columns.Add("Utilization", "Utilization");

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string typeFilter = cboFilter1.SelectedItem?.ToString() ?? "All Leave Types";

            var currentUser = AuthService.Instance.CurrentUser;
            int currentEmpId = currentUser?.EmployeeId ?? -1;
            bool isRegularEmployee = !AuthService.Instance.HasAnyRole(SystemRole.Admin, SystemRole.HR_Manager, SystemRole.Department_Head, SystemRole.Clearance_Officer);

            foreach (var ent in DataStore.Instance.Entitlements)
            {
                if (isRegularEmployee && ent.EmployeeId != currentEmpId) continue;

                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == ent.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == ent.LeaveTypeId);

                string typeName = lt?.Name ?? "Unknown";
                if (typeFilter != "All Leave Types" && typeName != typeFilter) continue;

                string empCode = emp?.EmployeeCode ?? "N/A";
                string empName = emp?.FullName ?? "N/A";
                string dept = emp?.DepartmentName ?? "N/A";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = empCode.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 typeName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    empCode, empName, dept, typeName,
                    ent.BaseDays, ent.CarriedOverDays, $"+{ent.TenureBonusDays}",
                    ent.TotalAllocatedDays, ent.UsedDays, ent.BalanceDays, $"{ent.UtilizationRate}%"
                );
                dgvData.Rows[idx].Tag = ent;
            }
        }

        private void GenerateEntitlements()
        {
            int year = DateTime.Now.Year;
            var confirm = MessageBox.Show(
                $"Generate and update leave quota allocations for all active employees for fiscal year {year}?\n\nThis will compute base quota allocations and +1 day/year service tenure bonuses.",
                "Confirm Entitlement Generation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                int entId = DataStore.Instance.Entitlements.Any() ? DataStore.Instance.Entitlements.Max(e => e.Id) + 1 : 1;

                foreach (var emp in DataStore.Instance.Employees.Where(e => e.IsActive))
                {
                    foreach (var lt in DataStore.Instance.LeaveTypes.Where(l => l.IsActive))
                    {
                        var existing = DataStore.Instance.Entitlements.FirstOrDefault(e => e.EmployeeId == emp.Id && e.LeaveTypeId == lt.Id && e.FiscalYear == year);
                        if (existing == null)
                        {
                            DataStore.Instance.Entitlements.Add(new LeaveEntitlement
                            {
                                Id = entId++,
                                EmployeeId = emp.Id,
                                LeaveTypeId = lt.Id,
                                FiscalYear = year,
                                BaseDays = lt.EntitlementDays,
                                CarriedOverDays = emp.CompletedYearsOfService > 2 && lt.IsCarryForwardAllowed ? 3 : 0,
                                TenureBonusDays = lt.Code == "ANNUAL" ? emp.CompletedYearsOfService : 0,
                                UsedDays = 0
                            });
                        }
                        else
                        {
                            if (lt.Code == "ANNUAL")
                            {
                                existing.TenureBonusDays = emp.CompletedYearsOfService;
                            }
                        }
                    }
                }

                DataStore.Instance.NotifyChanged();
                LoadLeaveEntitlementsSubGrid();
                MessageBox.Show($"Leave quota entitlements successfully generated and updated for fiscal year {year}.", "Entitlements Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetupLeavesToolbar() => SetupLeaveRequestsToolbar();
        private void LoadLeavesGrid() => LoadLeaveRequestsSubGrid();

                private void SetupRolesToolbar()
        {
            txtSearch.PlaceholderText = "Search role name or key...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "All Statuses", "ACTIVE", "INACTIVE" });
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;
            btnToolbarAction.Visible = AuthService.Instance.HasRole(SystemRole.Admin);
            btnToolbarAction.Text = "+ Create Role";
        }

        private void LoadRolesGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Role Name", Width = 180 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Key", HeaderText = "Role Key", Width = 180 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Users", HeaderText = "Assigned Users", Width = 140 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Permissions", HeaderText = "Permissions", Width = 150 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", Width = 110 });

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "All Statuses";

            foreach (var r in DataStore.Instance.Roles)
            {
                if (statusFilter == "ACTIVE" && !r.IsActive) continue;
                if (statusFilter == "INACTIVE" && r.IsActive) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = r.Name.ToLowerInvariant().Contains(search) ||
                                 r.RoleKey.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                string permSummary = $"{r.PermissionCount} permissions";
                int idx = dgvData.Rows.Add(
                    r.Name, r.RoleKey, $"{r.UserCount} users", permSummary,
                    r.IsActive ? "ACTIVE" : "INACTIVE"
                );
                dgvData.Rows[idx].Tag = r;
            }
        }

        private void SetupEmployeesToolbar()
        {
            txtSearch.PlaceholderText = "Search name, code, email...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.Add("All Departments");
            foreach (var d in DataStore.Instance.Departments) cboFilter1.Items.Add(d.Name);
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = true;
            cboFilter2.Items.Clear();
            cboFilter2.Items.AddRange(new object[] { "All Statuses", "ACTIVE", "INACTIVE" });
            cboFilter2.SelectedIndex = 0;

            btnToolbarAction.Visible = AuthService.Instance.HasRole(SystemRole.Admin);
            btnToolbarAction.Text = "+ New Employee";
        }

        private void SetupDepartmentsToolbar()
        {
            txtSearch.PlaceholderText = "Search department name, code, head...";
            cboFilter1.Visible = false;
            cboFilter2.Visible = false;
            btnToolbarAction.Visible = AuthService.Instance.HasRole(SystemRole.Admin);
            btnToolbarAction.Text = "+ New Department";
        }

        private void LoadDepartmentsGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Code", HeaderText = "Dept Code", Width = 110 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Department Name", Width = 230 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Head", HeaderText = "Department Head", Width = 200 });
            dgvData.Columns.Add(new DataGridViewTextBoxColumn { Name = "Staff", HeaderText = "Active Personnel", Width = 140 });

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();

            foreach (var d in DataStore.Instance.Departments.OrderBy(dept => dept.Code))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    bool match = d.Code.ToLowerInvariant().Contains(search) ||
                                 d.Name.ToLowerInvariant().Contains(search) ||
                                 (d.DepartmentHeadName ?? "").ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int staffCount = DataStore.Instance.Employees.Count(e => e.DepartmentName == d.Name && e.IsActive);
                string head = string.IsNullOrWhiteSpace(d.DepartmentHeadName) ? "Unassigned" : d.DepartmentHeadName;

                int idx = dgvData.Rows.Add(d.Code, d.Name, head, $"{staffCount} active staff");
                dgvData.Rows[idx].Tag = d;
            }
        }

        private void SetupClearancesToolbar()
        {
            txtSearch.PlaceholderText = "Search employee, req #, or study leave...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "Pending Clearance", "Completed Clearance", "All Clearances" });
            cboFilter1.SelectedIndex = 0;

            bool canManage = AuthService.Instance.HasAnyRole(
                SystemRole.Admin,
                SystemRole.HR_Manager,
                SystemRole.Department_Head,
                SystemRole.Clearance_Officer
            );

            cboFilter2.Visible = canManage;
            cboFilter2.Items.Clear();
            if (canManage)
            {
                cboFilter2.Items.AddRange(new object[] { "All Employees", "My Department Clearances", "My Clearances Only" });
                cboFilter2.SelectedIndex = 0;
            }

            btnToolbarAction.Visible = false;
        }

        private void LoadClearancesGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("ReqNumber", "Request #");
            dgvData.Columns.Add("EmpName", "Employee");
            dgvData.Columns.Add("EmpCode", "Emp Code");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("Type", "Leave Type");
            dgvData.Columns.Add("Dates", "Study Period");
            dgvData.Columns.Add("Days", "Days");
            dgvData.Columns.Add("Checklist", "Clearance Handover");
            dgvData.Columns.Add("Status", "Clearance Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "Pending Clearance";
            string scopeFilter = cboFilter2.Visible ? (cboFilter2.SelectedItem?.ToString() ?? "All Employees") : "My Clearances Only";

            var currentUser = AuthService.Instance.CurrentUser;
            var currentEmp = AuthService.Instance.CurrentEmployee;
            int currentEmpId = currentUser?.EmployeeId ?? -1;
            int currentEmpDeptId = currentEmp?.DepartmentId ?? -1;

            bool canManage = AuthService.Instance.HasAnyRole(
                SystemRole.Admin,
                SystemRole.HR_Manager,
                SystemRole.Department_Head,
                SystemRole.Clearance_Officer
            );

            // Respecting rule: Only show Study / Clearance requests in CLEARANCE_IN_PROGRESS or APPROVED (Completed).
            // DRAFT, SUBMITTED, UNDER_REVIEW, REJECTED, CANCELLED are strictly NOT shown.
            var clearanceRequests = DataStore.Instance.LeaveRequests
                .Where(r => r.RequiresClearance || r.LeaveTypeId == 3)
                .Where(r => r.Status == RequestStatus.CLEARANCE_IN_PROGRESS || r.Status == RequestStatus.APPROVED)
                .OrderByDescending(r => r.CreatedAt);

            foreach (var r in clearanceRequests)
            {
                // Status filter
                if (statusFilter == "Pending Clearance" && r.Status != RequestStatus.CLEARANCE_IN_PROGRESS) continue;
                if (statusFilter == "Completed Clearance" && r.Status != RequestStatus.APPROVED) continue;

                // Scope filter: If regular employee or user chose "My Clearances Only", show only their own requests
                if (!canManage || scopeFilter == "My Clearances Only")
                {
                    if (r.EmployeeId != currentEmpId) continue;
                }
                else if (scopeFilter == "My Department Clearances")
                {
                    var requestEmp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == r.EmployeeId);
                    if (requestEmp?.DepartmentId != currentEmpDeptId) continue;
                }

                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == r.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == r.LeaveTypeId);

                string empCode = emp?.EmployeeCode ?? "N/A";
                string empName = emp?.FullName ?? "N/A";
                string dept = emp?.DepartmentName ?? "N/A";
                string typeName = lt?.Name ?? "Study & Sabbatical Leave";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = r.RequestNumber.ToLowerInvariant().Contains(search) ||
                                 empCode.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 dept.ToLowerInvariant().Contains(search) ||
                                 typeName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int totalItems = r.ClearanceChecklist.Count;
                int clearedItems = r.ClearanceChecklist.Count(c => c.Status == ClearanceStatus.CLEARED);
                string progressText = totalItems == 0 ? "No Handover Req" :
                    (clearedItems == totalItems ? $"Completed ({clearedItems}/{totalItems})" : $"{clearedItems}/{totalItems} Cleared");

                string statusText = r.Status == RequestStatus.APPROVED ? "COMPLETED" : "PENDING CLEARANCE";

                int idx = dgvData.Rows.Add(
                    r.RequestNumber,
                    empName,
                    empCode,
                    dept,
                    typeName,
                    $"{r.StartDate:yyyy-MM-dd} to {r.EndDate:yyyy-MM-dd}",
                    r.DurationDays,
                    progressText,
                    statusText
                );
                dgvData.Rows[idx].Tag = r;
            }
        }

        private void ShowClearanceActionMenu(LeaveRequest req, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemView = new ToolStripMenuItem("View Clearance Checklist & Progress", null, (s, ev) =>
            {
                using (var dlg = new LeaveClearanceDialog(req))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshActiveData();
                    }
                }
            });
            menu.Items.Add(itemView);

            bool canAction = AuthService.Instance.HasAnyRole(
                SystemRole.Clearance_Officer,
                SystemRole.Admin,
                SystemRole.Department_Head,
                SystemRole.HR_Manager
            );

            var pendingItem = req.ClearanceChecklist.FirstOrDefault(c => c.Status != ClearanceStatus.CLEARED);
            if (canAction && pendingItem != null && req.Status == RequestStatus.CLEARANCE_IN_PROGRESS)
            {
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.Add(new ToolStripMenuItem($"✓ Quick Clear: {pendingItem.ItemName}", null, (s, ev) =>
                {
                    var res = LeaveService.Instance.ClearChecklistItem(req.Id, pendingItem.Id);
                    MessageBox.Show(res.Message, res.Success ? "Clearance Sign-Off" : "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshActiveData();
                }));
            }

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void btnConfigTabClearance_Click(object sender, EventArgs e) => SelectConfigSubTab(ConfigSubTab.Clearance);
        private void btnConfigTabLeave_Click(object sender, EventArgs e) => SelectConfigSubTab(ConfigSubTab.Leave);
        private void btnConfigTabApproval_Click(object sender, EventArgs e) => SelectConfigSubTab(ConfigSubTab.Approval);

        private void SelectConfigSubTab(ConfigSubTab tab)
        {
            _currentConfigSubTab = tab;
            ResetConfigSubTabButtons();

            switch (tab)
            {
                case ConfigSubTab.Clearance:
                    HighlightConfigSubTab(btnConfigTabClearance);
                    lblBreadcrumb.Text = "Configurations  /  Clearance Policies & Handover Units";
                    SetupClearanceConfigToolbar();
                    LoadClearanceConfigSubGrid();
                    break;
                case ConfigSubTab.Leave:
                    HighlightConfigSubTab(btnConfigTabLeave);
                    lblBreadcrumb.Text = "Configurations  /  Leave Types & Allocation Rules";
                    SetupLeaveConfigToolbar();
                    LoadLeaveConfigSubGrid();
                    break;
                case ConfigSubTab.Approval:
                    HighlightConfigSubTab(btnConfigTabApproval);
                    lblBreadcrumb.Text = "Configurations  /  Sequential Approval Workflows";
                    SetupApprovalConfigToolbar();
                    LoadApprovalConfigSubGrid();
                    break;
            }
        }

        private void HighlightConfigSubTab(Button btn)
        {
            btn.BackColor = Color.FromArgb(255, 247, 237);
            btn.ForeColor = Color.FromArgb(234, 88, 12);
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void ResetConfigSubTabButtons()
        {
            foreach (var b in new[] { btnConfigTabClearance, btnConfigTabLeave, btnConfigTabApproval })
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(100, 116, 139);
                b.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }
        }

        private void pnlConfigSubNav_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlConfigSubNav.Height - 1, pnlConfigSubNav.Width, pnlConfigSubNav.Height - 1);
            }
        }

        private void SetupClearanceConfigToolbar()
        {
            txtSearch.PlaceholderText = "Search policy code, name, or unit...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "All Policies", "Active Only", "Inactive Only" });
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;

            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "+ New Clearance Policy";
        }

        private void LoadClearanceConfigSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("Code", "Policy Code");
            dgvData.Columns.Add("Name", "Clearance Policy Name");
            dgvData.Columns.Add("Type", "Target Request Desk");
            dgvData.Columns.Add("Workflow", "Handover Mode");
            dgvData.Columns.Add("Letter", "Clearance Letter");
            dgvData.Columns.Add("Units", "Handover Units");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "All Policies";

            foreach (var cp in DataStore.Instance.ClearancePolicies.OrderBy(p => p.Code))
            {
                if (statusFilter == "Active Only" && !cp.IsActive) continue;
                if (statusFilter == "Inactive Only" && cp.IsActive) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = cp.Code.ToLowerInvariant().Contains(search) ||
                                 cp.Name.ToLowerInvariant().Contains(search) ||
                                 cp.RequestType.ToLowerInvariant().Contains(search) ||
                                 string.Join(" ", cp.RequiredUnits).ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    cp.Code,
                    cp.Name,
                    cp.RequestType,
                    cp.IsSequential ? "Sequential" : "Parallel",
                    cp.GenerateClearanceLetter ? "YES" : "NO",
                    string.Join(", ", cp.RequiredUnits),
                    cp.IsActive ? "ACTIVE" : "INACTIVE"
                );
                dgvData.Rows[idx].Tag = cp;
            }
        }

        private void SetupLeaveConfigToolbar()
        {
            txtSearch.PlaceholderText = "Search leave policy name or code...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "All Policies", "Active Only", "Inactive Only" });
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;

            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "+ New Leave Policy";
        }

        private void LoadLeaveConfigSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("Code", "Type Code");
            dgvData.Columns.Add("Name", "Leave Policy Name");
            dgvData.Columns.Add("Quota", "Annual Allocation");
            dgvData.Columns.Add("Tenure", "Min Service");
            dgvData.Columns.Add("Clearance", "Clearance Required");
            dgvData.Columns.Add("Certificate", "Medical Cert Required");
            dgvData.Columns.Add("Carry", "Carry-Forward");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "All Policies";

            foreach (var lt in DataStore.Instance.LeaveTypes.OrderBy(l => l.Code))
            {
                if (statusFilter == "Active Only" && !lt.IsActive) continue;
                if (statusFilter == "Inactive Only" && lt.IsActive) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = lt.Code.ToLowerInvariant().Contains(search) ||
                                 lt.Name.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                int idx = dgvData.Rows.Add(
                    lt.Code,
                    lt.Name,
                    $"{lt.EntitlementDays} days/yr",
                    lt.MinimumServiceMonths > 0 ? $"{lt.MinimumServiceMonths} mos" : "None",
                    lt.RequiresClearance ? "YES" : "NO",
                    lt.RequiresCertificate ? "YES" : "NO",
                    lt.IsCarryForwardAllowed ? "YES" : "NO",
                    lt.IsActive ? "ACTIVE" : "INACTIVE"
                );
                dgvData.Rows[idx].Tag = lt;
            }
        }

        private void SetupApprovalConfigToolbar()
        {
            txtSearch.PlaceholderText = "Search workflow name or request desk...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.AddRange(new object[] { "All Workflows", "Active Only", "Inactive Only" });
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;

            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "+ New Approval Workflow";
        }

        private void LoadApprovalConfigSubGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("Name", "Workflow Definition Name");
            dgvData.Columns.Add("RequestType", "Target Request Desk");
            dgvData.Columns.Add("Chain", "Sequential Approvers Chain");
            dgvData.Columns.Add("Steps", "Steps");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string statusFilter = cboFilter1.SelectedItem?.ToString() ?? "All Workflows";

            foreach (var wf in DataStore.Instance.ApprovalWorkflows.OrderBy(w => w.Id))
            {
                if (statusFilter == "Active Only" && !wf.IsActive) continue;
                if (statusFilter == "Inactive Only" && wf.IsActive) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = wf.Name.ToLowerInvariant().Contains(search) ||
                                 wf.RequestType.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                string chain = string.Join("  ➔  ", wf.Steps.OrderBy(s => s.StepOrder).Select(s => $"Step {s.StepOrder}: {s.ApproverRole}"));

                int idx = dgvData.Rows.Add(
                    wf.Name,
                    wf.RequestType,
                    chain,
                    $"{wf.Steps.Count} Steps",
                    wf.IsActive ? "ACTIVE" : "INACTIVE"
                );
                dgvData.Rows[idx].Tag = wf;
            }
        }

        private void ShowClearancePolicyActionMenu(ClearancePolicy cp, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemEdit = new ToolStripMenuItem("Edit Clearance Policy", null, (s, ev) =>
            {
                using (var dlg = new ClearancePolicyDialog(cp))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadClearanceConfigSubGrid();
                    }
                }
            });

            var itemToggle = new ToolStripMenuItem(cp.IsActive ? "Deactivate Policy" : "Activate Policy", null, (s, ev) =>
            {
                cp.IsActive = !cp.IsActive;
                DataStore.Instance.NotifyChanged();
                LoadClearanceConfigSubGrid();
            });

            var itemDelete = new ToolStripMenuItem("Delete Policy", null, (s, ev) =>
            {
                if (MessageBox.Show($"Are you sure you want to delete clearance policy '{cp.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataStore.Instance.ClearancePolicies.Remove(cp);
                    DataStore.Instance.NotifyChanged();
                    LoadClearanceConfigSubGrid();
                }
            });

            menu.Items.Add(itemEdit);
            menu.Items.Add(itemToggle);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void ShowApprovalWorkflowActionMenu(ApprovalWorkflowDefinition wf, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemEdit = new ToolStripMenuItem("Edit Workflow Definition", null, (s, ev) =>
            {
                using (var dlg = new ApprovalWorkflowDialog(wf))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadApprovalConfigSubGrid();
                    }
                }
            });

            var itemToggle = new ToolStripMenuItem(wf.IsActive ? "Deactivate Workflow" : "Activate Workflow", null, (s, ev) =>
            {
                wf.IsActive = !wf.IsActive;
                DataStore.Instance.NotifyChanged();
                LoadApprovalConfigSubGrid();
            });

            var itemDelete = new ToolStripMenuItem("Delete Workflow", null, (s, ev) =>
            {
                if (MessageBox.Show($"Are you sure you want to delete approval workflow '{wf.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataStore.Instance.ApprovalWorkflows.Remove(wf);
                    DataStore.Instance.NotifyChanged();
                    LoadApprovalConfigSubGrid();
                }
            });

            menu.Items.Add(itemEdit);
            menu.Items.Add(itemToggle);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private int _reportTotalStaff = 0;
        private int _reportTotalAllocated = 0;
        private int _reportTotalUsed = 0;
        private int _reportTotalBalance = 0;
        private double _reportAvgUtil = 0.0;

        private void SetupLedgerToolbar()
        {
            txtSearch.PlaceholderText = "Search employee, code, dept...";
            txtSearch.Visible = true;

            // Filter 1: Department
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.Add("All Departments");
            foreach (var d in DataStore.Instance.Departments.OrderBy(dep => dep.Name))
            {
                cboFilter1.Items.Add(d.Name);
            }
            cboFilter1.SelectedIndex = 0;

            // Filter 2: Gender
            cboFilter2.Visible = true;
            cboFilter2.Items.Clear();
            cboFilter2.Items.Add("All Genders");
            cboFilter2.Items.Add("Male");
            cboFilter2.Items.Add("Female");
            cboFilter2.SelectedIndex = 0;

            // Filter 3: Leave Type
            cboFilter3.Visible = true;
            cboFilter3.Items.Clear();
            cboFilter3.Items.Add("All Leave Types");
            foreach (var lt in DataStore.Instance.LeaveTypes.OrderBy(l => l.Name))
            {
                cboFilter3.Items.Add(lt.Name);
            }
            cboFilter3.SelectedIndex = 0;

            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "📊 Export Excel";

            btnSecondaryAction.Visible = true;
            btnSecondaryAction.Text = "📄 Export PDF";
        }

        private void FilterOrSearch_Changed(object sender, EventArgs e)
        {
            paginationControl?.ResetPage();
            RefreshActiveData();
        }

        private void RefreshActiveData()
        {
            if (_currentView == ActiveView.Dashboard)
            {
                if (pnlTabEmployeesView.Visible) LoadEmployeeMetrics();
                else LoadLeaveMetrics();
            }
            else if (_currentView == ActiveView.Leaves)
            {
                switch (_currentLeaveSubTab)
                {
                    case LeaveSubTab.Requests: LoadLeaveRequestsSubGrid(); break;
                    case LeaveSubTab.Approvals: LoadLeaveApprovalsSubGrid(); break;
                    case LeaveSubTab.Types: LoadLeaveTypesSubGrid(); break;
                    case LeaveSubTab.Entitlements: LoadLeaveEntitlementsSubGrid(); break;
                }
            }
            else if (_currentView == ActiveView.Approvals)
            {
                LoadLeaveApprovalsSubGrid();
            }
            else if (_currentView == ActiveView.Employees)
            {
                LoadEmployeesGrid();
            }
            else if (_currentView == ActiveView.Departments)
            {
                LoadDepartmentsGrid();
            }
            else if (_currentView == ActiveView.Roles)
            {
                LoadRolesGrid();
            }
            else if (_currentView == ActiveView.Clearances)
            {
                LoadClearancesGrid();
            }
            else if (_currentView == ActiveView.Configurations)
            {
                switch (_currentConfigSubTab)
                {
                    case ConfigSubTab.Clearance: LoadClearanceConfigSubGrid(); break;
                    case ConfigSubTab.Leave: LoadLeaveConfigSubGrid(); break;
                    case ConfigSubTab.Approval: LoadApprovalConfigSubGrid(); break;
                }
            }
            else if (_currentView == ActiveView.Ledger)
            {
                LoadLedgerGrid();
            }

            if (pnlGridView.Visible)
            {
                paginationControl?.ApplyPagination(dgvData);
            }
        }



        private void LoadEmployeesGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            dgvData.Columns.Add("Code", "Emp Code");
            dgvData.Columns.Add("Name", "Full Name");
            dgvData.Columns.Add("Gender", "Gender");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("Title", "Job Title");
            dgvData.Columns.Add("HireDate", "Hire Date");
            dgvData.Columns.Add("Tenure", "Tenure");
            dgvData.Columns.Add("Email", "Email");
            dgvData.Columns.Add("Status", "Status");

            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            dgvData.Columns.Add(actionCol);

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string deptFilter = cboFilter1.SelectedItem?.ToString() ?? "All Departments";
            string statusFilter = cboFilter2.SelectedItem?.ToString() ?? "All Statuses";

            foreach (var emp in DataStore.Instance.Employees.OrderBy(e => e.EmployeeCode))
            {
                if (deptFilter != "All Departments" && emp.DepartmentName != deptFilter) continue;
                if (statusFilter == "ACTIVE" && !emp.IsActive) continue;
                if (statusFilter == "INACTIVE" && emp.IsActive) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = emp.EmployeeCode.ToLowerInvariant().Contains(search) ||
                                 emp.FullName.ToLowerInvariant().Contains(search) ||
                                 emp.Email.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                string tenure = $"{emp.CompletedYearsOfService} yrs ({emp.MonthsOfService} mos)";
                int idx = dgvData.Rows.Add(
                    emp.EmployeeCode, emp.FullName, emp.Gender, emp.DepartmentName, emp.JobTitle,
                    emp.HireDate.ToString("yyyy-MM-dd"), tenure, emp.Email, emp.IsActive ? "ACTIVE" : "INACTIVE"
                );
                dgvData.Rows[idx].Tag = emp;
            }
        }

        private void LoadLedgerGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();

            var colSelect = new DataGridViewCheckBoxColumn
            {
                Name = "colSelect",
                HeaderText = "☑",
                Width = 42,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvData.Columns.Add(colSelect);

            dgvData.Columns.Add("EmpCode", "Emp Code");
            dgvData.Columns.Add("EmpName", "Employee Name");
            dgvData.Columns.Add("Gender", "Gender");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("LeaveType", "Leave Type");
            dgvData.Columns.Add("Base", "Base Quota");
            dgvData.Columns.Add("Carried", "Carry Over");
            dgvData.Columns.Add("Bonus", "Tenure Bonus");
            dgvData.Columns.Add("Total", "Total Allocated");
            dgvData.Columns.Add("Used", "Used");
            dgvData.Columns.Add("Balance", "Balance");
            dgvData.Columns.Add("Utilization", "Utilization %");

            dgvData.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                col.ReadOnly = (col.Name != "colSelect");
            }

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string deptFilter = cboFilter1.SelectedItem?.ToString() ?? "All Departments";
            string genderFilter = cboFilter2.SelectedItem?.ToString() ?? "All Genders";
            string typeFilter = cboFilter3.SelectedItem?.ToString() ?? "All Leave Types";

            var distinctStaffIds = new HashSet<int>();
            int sumAllocated = 0;
            int sumUsed = 0;
            int sumBalance = 0;

            foreach (var ent in DataStore.Instance.Entitlements)
            {
                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == ent.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == ent.LeaveTypeId);

                if (deptFilter != "All Departments" && emp?.DepartmentName != deptFilter) continue;
                if (genderFilter != "All Genders" && emp?.Gender.ToString() != genderFilter) continue;
                if (typeFilter != "All Leave Types" && lt?.Name != typeFilter) continue;

                string empCode = emp?.EmployeeCode ?? "N/A";
                string empName = emp?.FullName ?? "N/A";
                string gender = emp?.Gender.ToString() ?? "N/A";
                string deptName = emp?.DepartmentName ?? "N/A";
                string typeName = lt?.Name ?? "N/A";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = empCode.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 gender.ToLowerInvariant().Contains(search) ||
                                 deptName.ToLowerInvariant().Contains(search) ||
                                 typeName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                if (emp != null) distinctStaffIds.Add(emp.Id);
                sumAllocated += ent.TotalAllocatedDays;
                sumUsed += ent.UsedDays;
                sumBalance += ent.BalanceDays;

                dgvData.Rows.Add(
                    false,
                    empCode,
                    empName,
                    gender,
                    deptName,
                    typeName,
                    ent.BaseDays,
                    ent.CarriedOverDays,
                    $"+{ent.TenureBonusDays}",
                    ent.TotalAllocatedDays,
                    ent.UsedDays,
                    ent.BalanceDays,
                    $"{ent.UtilizationRate:0.0}%"
                );
            }

            _reportTotalStaff = distinctStaffIds.Count;
            _reportTotalAllocated = sumAllocated;
            _reportTotalUsed = sumUsed;
            _reportTotalBalance = sumBalance;
            _reportAvgUtil = sumAllocated > 0 ? ((double)sumUsed / sumAllocated * 100.0) : 0.0;

            lblReportKpiStaff.Text = $"👥 Staff: {_reportTotalStaff}";
            lblReportKpiAllocated.Text = $"📊 Quota: {_reportTotalAllocated}d";
            lblReportKpiUsed.Text = $"🌴 Taken: {_reportTotalUsed}d";
            lblReportKpiBalance.Text = $"⚖️ Balance: {_reportTotalBalance}d";
            lblReportKpiUtil.Text = $"📈 Util: {_reportAvgUtil:0.0}%";

            UpdateLedgerSelectionCount();
        }

        private void UpdateLedgerSelectionCount()
        {
            int totalRows = dgvData.Rows.Count;
            int checkedCount = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["colSelect"]?.Value is true)
                {
                    checkedCount++;
                }
            }

            if (checkedCount > 0)
            {
                lblReportSelectedCount.Text = $"{checkedCount} of {totalRows} selected (generating for checked only)";
                lblReportSelectedCount.ForeColor = Color.FromArgb(234, 88, 12);
            }
            else
            {
                lblReportSelectedCount.Text = $"0 of {totalRows} selected (generating for all filtered)";
                lblReportSelectedCount.ForeColor = Color.FromArgb(100, 116, 139);
            }

            btnToggleSelectAll.Text = (checkedCount == totalRows && totalRows > 0) ? "☐ Deselect All" : "☑ Select All";
        }

        private void btnToggleSelectAll_Click(object? sender, EventArgs e)
        {
            if (_currentView != ActiveView.Ledger) return;

            bool selectAll = (btnToggleSelectAll.Text == "☑ Select All");
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["colSelect"] != null)
                {
                    row.Cells["colSelect"].Value = selectAll;
                }
            }
            dgvData.EndEdit();
            UpdateLedgerSelectionCount();
        }

        private void pnlReportMetrics_Paint(object? sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlReportMetrics.Height - 1, pnlReportMetrics.Width, pnlReportMetrics.Height - 1);
            }
        }

        private void dgvData_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvData.IsCurrentCellDirty && dgvData.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvData_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_currentView == ActiveView.Ledger && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvData.Columns[e.ColumnIndex].Name == "colSelect")
                {
                    UpdateLedgerSelectionCount();
                }
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_currentView == ActiveView.Leaves && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (_currentLeaveSubTab == LeaveSubTab.Requests && dgvData.Rows[e.RowIndex].Tag is LeaveRequest req)
                {
                    ShowLeaveRequestActionMenu(req, e.RowIndex, e.ColumnIndex);
                }
                else if (_currentLeaveSubTab == LeaveSubTab.Approvals && dgvData.Rows[e.RowIndex].Tag is LeaveRequest appReq)
                {
                    ShowLeaveApprovalActionMenu(appReq, e.RowIndex, e.ColumnIndex);
                }
                else if (_currentLeaveSubTab == LeaveSubTab.Types && dgvData.Rows[e.RowIndex].Tag is LeaveType lt)
                {
                    ShowLeaveTypeActionMenu(lt, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Approvals && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (dgvData.Rows[e.RowIndex].Tag is LeaveRequest appReq)
                {
                    ShowLeaveApprovalActionMenu(appReq, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Employees && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (dgvData.Rows[e.RowIndex].Tag is Employee emp)
                {
                    ShowEmployeeActionMenu(emp, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Departments && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (dgvData.Rows[e.RowIndex].Tag is Department dept)
                {
                    ShowDepartmentActionMenu(dept, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Roles && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (dgvData.Rows[e.RowIndex].Tag is Role r)
                {
                    ShowRoleActionMenu(r, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Clearances && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (dgvData.Rows[e.RowIndex].Tag is LeaveRequest clrReq)
                {
                    ShowClearanceActionMenu(clrReq, e.RowIndex, e.ColumnIndex);
                }
            }
            else if (_currentView == ActiveView.Configurations && dgvData.Columns[e.ColumnIndex].Name == "Actions")
            {
                if (_currentConfigSubTab == ConfigSubTab.Clearance && dgvData.Rows[e.RowIndex].Tag is ClearancePolicy cp)
                {
                    ShowClearancePolicyActionMenu(cp, e.RowIndex, e.ColumnIndex);
                }
                else if (_currentConfigSubTab == ConfigSubTab.Leave && dgvData.Rows[e.RowIndex].Tag is LeaveType lt)
                {
                    ShowLeaveTypeActionMenu(lt, e.RowIndex, e.ColumnIndex);
                }
                else if (_currentConfigSubTab == ConfigSubTab.Approval && dgvData.Rows[e.RowIndex].Tag is ApprovalWorkflowDefinition wf)
                {
                    ShowApprovalWorkflowActionMenu(wf, e.RowIndex, e.ColumnIndex);
                }
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = dgvData.Columns[e.ColumnIndex].Name;
            if (colName == "Status")
            {
                string val = e.Value.ToString() ?? "";
                if (val == "APPROVED" || val == "COMPLETED") { e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); e.CellStyle.Font = new Font(dgvData.Font, FontStyle.Bold); }
                else if (val == "REJECTED" || val == "CANCELLED") { e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); }
                else if (val == "CLEARANCE_IN_PROGRESS" || val == "PENDING CLEARANCE") { e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12); e.CellStyle.Font = new Font(dgvData.Font, FontStyle.Bold); }
                else { e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12); }
            }
            else if (colName == "Balance")
            {
                if (int.TryParse(e.Value.ToString(), out int bal) && bal <= 3)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = new Font(dgvData.Font, FontStyle.Bold);
                }
            }
        }

        private void btnToolbarAction_Click(object sender, EventArgs e)
        {
            if (_currentView == ActiveView.Leaves)
            {
                if (_currentLeaveSubTab == LeaveSubTab.Requests)
                {
                    using (var dlg = new LeaveRequestDialog())
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            RefreshActiveData();
                        }
                    }
                }
                else if (_currentLeaveSubTab == LeaveSubTab.Types)
                {
                    using (var dlg = new LeaveTypeDialog())
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadLeaveTypesSubGrid();
                        }
                    }
                }
                else if (_currentLeaveSubTab == LeaveSubTab.Entitlements)
                {
                    GenerateEntitlements();
                }
            }
            else if (_currentView == ActiveView.Employees)
            {
                using (var dlg = new EmployeeCreateDialog())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadEmployeesGrid();
                    }
                }
            }
            else if (_currentView == ActiveView.Departments)
            {
                using (var dlg = new DepartmentDialog())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDepartmentsGrid();
                    }
                }
            }
            else if (_currentView == ActiveView.Roles)
            {
                using (var dlg = new RoleDialog())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadRolesGrid();
                    }
                }
            }
            else if (_currentView == ActiveView.Configurations)
            {
                if (_currentConfigSubTab == ConfigSubTab.Clearance)
                {
                    using (var dlg = new ClearancePolicyDialog())
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadClearanceConfigSubGrid();
                        }
                    }
                }
                else if (_currentConfigSubTab == ConfigSubTab.Leave)
                {
                    using (var dlg = new LeaveTypeDialog())
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadLeaveConfigSubGrid();
                        }
                    }
                }
                else if (_currentConfigSubTab == ConfigSubTab.Approval)
                {
                    using (var dlg = new ApprovalWorkflowDialog())
                    {
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadApprovalConfigSubGrid();
                        }
                    }
                }
            }
            else if (_currentView == ActiveView.Ledger)
            {
                bool hasChecked = false;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells["colSelect"]?.Value is true)
                    {
                        hasChecked = true;
                        break;
                    }
                }

                ReportExporter.ExportToExcel(dgvData, "Leave_Summary_Report_2026.csv", checkedOnly: hasChecked);
            }
        }

        private void btnSecondaryAction_Click(object? sender, EventArgs e)
        {
            if (_currentView == ActiveView.Ledger)
            {
                bool hasChecked = false;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells["colSelect"]?.Value is true)
                    {
                        hasChecked = true;
                        break;
                    }
                }

                string filterDept = cboFilter1.SelectedItem?.ToString() ?? "All Departments";
                string filterGender = cboFilter2.SelectedItem?.ToString() ?? "All Genders";
                string filterType = cboFilter3.SelectedItem?.ToString() ?? "All Leave Types";
                string filterSummary = $"Dept: {filterDept} | Gender: {filterGender} | Leave Type: {filterType}";

                ReportExporter.ExportToPdfHtml(
                    dgvData,
                    "Leave Summary & Quota Analytics Report",
                    "Leave_Summary_Report_2026.html",
                    checkedOnly: hasChecked,
                    filterSummary: filterSummary,
                    totalStaff: _reportTotalStaff,
                    totalAllocated: _reportTotalAllocated,
                    totalUsed: _reportTotalUsed,
                    totalBalance: _reportTotalBalance,
                    avgUtilization: _reportAvgUtil
                );
            }
        }


private void ShowLeaveRequestActionMenu(LeaveRequest req, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemView = new ToolStripMenuItem("View Request Details & Audit", null, (s, ev) =>
            {
                using (var dlg = new StatusTrackingDialog(req))
                {
                    dlg.ShowDialog(this);
                    RefreshActiveData();
                }
            });

            var itemCancel = new ToolStripMenuItem("Cancel Leave Request", null, (s, ev) =>
            {
                if (req.Status == RequestStatus.APPROVED || req.Status == RequestStatus.REJECTED || req.Status == RequestStatus.CANCELLED)
                {
                    MessageBox.Show("Finalized requests cannot be cancelled.", "Cancel Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to cancel request #{req.RequestNumber}?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LeaveService.Instance.CancelLeaveRequest(req.Id);
                    RefreshActiveData();
                }
            });

            menu.Items.Add(itemView);
            if (req.Status != RequestStatus.APPROVED && req.Status != RequestStatus.REJECTED && req.Status != RequestStatus.CANCELLED)
            {
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.Add(itemCancel);
            }

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void ShowLeaveApprovalActionMenu(LeaveRequest req, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemReview = new ToolStripMenuItem("Review & Sign Off", null, (s, ev) =>
            {
                using (var dlg = new StatusTrackingDialog(req))
                {
                    dlg.ShowDialog(this);
                    RefreshActiveData();
                }
            });
            menu.Items.Add(itemReview);

            var pendingStep = req.ApprovalSteps.OrderBy(s => s.StepOrder).FirstOrDefault(s => s.Status == StepStatus.PENDING);
            if (pendingStep != null && (AuthService.Instance.HasRole(pendingStep.RequiredRole) || AuthService.Instance.HasRole(SystemRole.Admin)))
            {
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.Add(new ToolStripMenuItem("Quick Approve Step", null, (s, ev) =>
                {
                    var res = LeaveService.Instance.ProcessApprovalStep(req.Id, pendingStep.Id, true, "Quick approved via Approvals Desk");
                    MessageBox.Show(res.Message, res.Success ? "Approved" : "Failed", MessageBoxButtons.OK, res.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    RefreshActiveData();
                }));
                menu.Items.Add(new ToolStripMenuItem("Quick Reject Step", null, (s, ev) =>
                {
                    var res = LeaveService.Instance.ProcessApprovalStep(req.Id, pendingStep.Id, false, "Quick rejected via Approvals Desk");
                    MessageBox.Show(res.Message, res.Success ? "Rejected" : "Failed", MessageBoxButtons.OK, res.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    RefreshActiveData();
                }));
            }

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void ShowLeaveTypeActionMenu(LeaveType lt, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemEdit = new ToolStripMenuItem("Edit Policy", null, (s, ev) =>
            {
                using (var dlg = new LeaveTypeDialog(lt))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadLeaveTypesSubGrid();
                    }
                }
            });

            var itemDelete = new ToolStripMenuItem("Delete Policy", null, (s, ev) =>
            {
                DeleteLeaveType(lt);
            });

            menu.Items.Add(itemEdit);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void DeleteLeaveType(LeaveType lt)
        {
            bool inUse = DataStore.Instance.LeaveRequests.Any(r => r.LeaveTypeId == lt.Id);
            if (inUse)
            {
                MessageBox.Show($"Leave policy '{lt.Name}' has active leave records associated with it and cannot be deleted.", "Policy In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete policy '{lt.Name}' ({lt.Code})?", "Confirm Delete Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataStore.Instance.LeaveTypes.Remove(lt);
                DataStore.Instance.NotifyChanged();
                LoadLeaveTypesSubGrid();
            }
        }

private void ShowEmployeeActionMenu(Employee emp, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemDetails = new ToolStripMenuItem("👤  View Details", null, (s, ev) =>
            {
                using (var dlg = new EmployeeDialog(emp))
                {
                    dlg.ShowDialog(this);
                    RefreshActiveData();
                }
            });

            var itemPass = new ToolStripMenuItem("🔑  Change Password", null, (s, ev) =>
            {
                var user = DataStore.Instance.Users.FirstOrDefault(u => u.EmployeeId == emp.Id);
                if (user == null)
                {
                    MessageBox.Show($"No login account exists for employee '{emp.FullName}'.", "User Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dlg = new ChangePasswordDialog(emp, user))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshActiveData();
                    }
                }
            });

            var itemAssign = new ToolStripMenuItem("🛡️  Assign User Roles", null, (s, ev) =>
            {
                var user = DataStore.Instance.Users.FirstOrDefault(u => u.EmployeeId == emp.Id);
                if (user == null)
                {
                    MessageBox.Show($"No login account exists for employee '{emp.FullName}'.", "User Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dlg = new AssignUserRolesDialog(emp, user))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshActiveData();
                    }
                }
            });

            var itemDelete = new ToolStripMenuItem("🗑️  Delete Employee", null, (s, ev) =>
            {
                DeleteEmployee(emp);
            });

            if (AuthService.Instance.CurrentUser?.EmployeeId == emp.Id)
            {
                itemDelete.Enabled = false;
                itemDelete.ToolTipText = "You cannot delete your own active account.";
            }

            menu.Items.Add(itemDetails);
            menu.Items.Add(itemPass);
            menu.Items.Add(itemAssign);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void DeleteEmployee(Employee emp)
        {
            var confirm = MessageBox.Show(
                $"Are you sure you want to permanently delete employee '{emp.FullName}' ({emp.EmployeeCode})?\n\nThis will remove their profile and login credentials.",
                "Confirm Delete Employee",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                var result = EmployeeService.Instance.DeleteEmployee(emp.Id);
                if (result.Success)
                {
                    RefreshActiveData();
                    MessageBox.Show(result.Message, "Employee Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Message, "Cannot Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

private void ShowDepartmentActionMenu(Department dept, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemEdit = new ToolStripMenuItem("✏️  Edit Department", null, (s, ev) =>
            {
                using (var dlg = new DepartmentDialog(dept))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDepartmentsGrid();
                    }
                }
            });

            var itemViewStaff = new ToolStripMenuItem("👥  View Department Staff", null, (s, ev) =>
            {
                SwitchView(ActiveView.Employees);
                for (int i = 0; i < cboFilter1.Items.Count; i++)
                {
                    if (cboFilter1.Items[i]?.ToString() == dept.Name)
                    {
                        cboFilter1.SelectedIndex = i;
                        break;
                    }
                }
            });

            var itemDelete = new ToolStripMenuItem("🗑️  Delete Department", null, (s, ev) =>
            {
                DeleteDepartment(dept);
            });

            menu.Items.Add(itemEdit);
            menu.Items.Add(itemViewStaff);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void DeleteDepartment(Department dept)
        {
            int activeStaff = DataStore.Instance.Employees.Count(e => e.DepartmentName == dept.Name);
            if (activeStaff > 0)
            {
                MessageBox.Show(
                    $"Department '{dept.Name}' currently has {activeStaff} assigned employee(s).\n\nPlease reassign or delete these employees before removing the department.",
                    "Cannot Delete Department",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to permanently delete department '{dept.Name}' ({dept.Code})?",
                "Confirm Delete Department",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                DataStore.Instance.Departments.Remove(dept);
                DataStore.Instance.NotifyChanged();
                LoadDepartmentsGrid();
                MessageBox.Show($"Department '{dept.Name}' was deleted.", "Department Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowRoleActionMenu(Role r, int rowIndex, int colIndex)
        {
            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Font = new Font("Segoe UI", 9.5F);

            var itemManage = new ToolStripMenuItem("🛡️  Manage Permissions", null, (s, ev) =>
            {
                using (var dlg = new ManageRolePermissionsDialog(r))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadRolesGrid();
                    }
                }
            });

            var itemEdit = new ToolStripMenuItem("✏️  Edit Role Details", null, (s, ev) =>
            {
                using (var dlg = new RoleDialog(r))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadRolesGrid();
                    }
                }
            });

            var itemDelete = new ToolStripMenuItem("🗑️  Delete Role", null, (s, ev) =>
            {
                DeleteRole(r);
            });

            if (r.IsSystemRole)
            {
                itemDelete.Enabled = false;
                itemDelete.ToolTipText = "System roles are protected and cannot be deleted.";
            }

            menu.Items.Add(itemManage);
            menu.Items.Add(itemEdit);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            Rectangle cellRect = dgvData.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point pt = dgvData.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            menu.Show(pt);
        }

        private void DeleteRole(Role r)
        {
            if (r.IsSystemRole)
            {
                MessageBox.Show("System roles (e.g. ROLE_ADMIN, ROLE_HR_MANAGER) are essential and cannot be deleted.", "Protected Role", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to permanently delete role '{r.Name}' ({r.RoleKey})?\n\nThis action cannot be undone.",
                "Confirm Delete Role",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                DataStore.Instance.Roles.Remove(r);
                DataStore.Instance.NotifyChanged();
                LoadRolesGrid();
                MessageBox.Show($"Role '{r.Name}' was successfully deleted.", "Role Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pnlEmpKpiRow_Resize(object sender, EventArgs e) => ResizeKpiRow(pnlEmpKpiRow, cardEmpKpi1, cardEmpKpi2, cardEmpKpi3, cardEmpKpi4);
        private void pnlLeaveKpiRow_Resize(object sender, EventArgs e) => ResizeKpiRow(pnlLeaveKpiRow, cardLeaveKpi1, cardLeaveKpi2, cardLeaveKpi3, cardLeaveKpi4);

        private void ResizeKpiRow(Panel parent, Panel c1, Panel c2, Panel c3, Panel c4)
        {
            int totalW = parent.ClientSize.Width;
            int gap = 12;
            int cardW = Math.Max(180, (totalW - (gap * 3)) / 4);

            Panel[] cards = { c1, c2, c3, c4 };
            for (int i = 0; i < cards.Length; i++)
            {
                var card = cards[i];
                int w = (i == cards.Length - 1) ? Math.Max(cardW, totalW - (cardW + gap) * 3) : cardW;
                card.Location = new Point((cardW + gap) * i, 0);
                card.Size = new Size(w, 96);

                foreach (Control ctrl in card.Controls)
                {
                    if (ctrl is Label lbl)
                    {
                        lbl.AutoSize = false;
                        lbl.Width = w - 16;
                        lbl.Left = 8;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void pnlEmpContent_Resize(object sender, EventArgs e)
        {
            cardEmpDeptChart.Location = new Point(0, 0);
            cardEmpDeptChart.Size = pnlEmpContent.ClientSize;
        }

        private void lblUserAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, lblUserAvatar.Width - 1, lblUserAvatar.Height - 1);
                lblUserAvatar.Region = new Region(path);
            }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    var rect = panel.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            }
        }

        private void pnlBrand_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlBrand.Height - 1, pnlBrand.Width, pnlBrand.Height - 1);
            }
        }

        private void pnlSidebarBottom_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlSidebarBottom.Width, 0);
            }
        }

        private void pnlToolbar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            }
        }
    }
}
