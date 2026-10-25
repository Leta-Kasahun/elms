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
            Employees,
            Departments,
            Roles,
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

        private ActiveView _currentView = ActiveView.Dashboard;
        private bool _isSidebarCollapsed = false;
        private int _hoveredPieSlice = -1;

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

            SetupNavHover(btnNavDashboard);
            SetupNavHover(btnNavLeaves);
            SetupNavHover(btnNavEmployees);
            SetupNavHover(btnNavRoles);
            SetupNavHover(btnNavLedger);

            pnlUserCard.MouseEnter += (s, e) => pnlUserCard.BackColor = Color.FromArgb(241, 245, 249);
            pnlUserCard.MouseLeave += (s, e) => pnlUserCard.BackColor = Color.FromArgb(248, 250, 252);

            lblLeaveKpi1Val.BringToFront();
            lblLeaveKpi2Val.BringToFront();
            lblLeaveKpi3Val.BringToFront();
            lblLeaveKpi4Val.BringToFront();

            lblEmpKpi1Val.BringToFront();
            lblEmpKpi2Val.BringToFront();
            lblEmpKpi3Val.BringToFront();
            lblEmpKpi4Val.BringToFront();
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
                btnNavEmployees.Text = "E";
                btnNavRoles.Text = "R";
                btnNavLedger.Text = "Q";
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
                btnNavEmployees.Text = "Employees";
                btnNavRoles.Text = "Roles";
                btnNavLedger.Text = "Quota Ledger";
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
            pnlGridView.Visible = (view != ActiveView.Dashboard);
            pnlLeaveSubNav.Visible = (view == ActiveView.Leaves);

            switch (view)
            {
                case ActiveView.Dashboard:
                    HighlightNav(btnNavDashboard);
                    lblBreadcrumb.Text = "Dashboard  /  Overview";
                    if (pnlTabEmployeesView.Visible) ShowEmployeesTab();
                    else ShowLeavesTab();
                    break;
                case ActiveView.Leaves:
                    HighlightNav(btnNavLeaves);
                    bool canApprove = AuthService.Instance.HasAnyRole(SystemRole.Admin, SystemRole.HR_Manager, SystemRole.Department_Head, SystemRole.Clearance_Officer);
                    btnLeaveTabApprovals.Visible = canApprove;
                    if (!canApprove)
                    {
                        btnLeaveTabTypes.Location = new System.Drawing.Point(136, 4);
                        btnLeaveTabEntitlements.Location = new System.Drawing.Point(252, 4);
                    }
                    else
                    {
                        btnLeaveTabApprovals.Location = new System.Drawing.Point(136, 4);
                        btnLeaveTabTypes.Location = new System.Drawing.Point(252, 4);
                        btnLeaveTabEntitlements.Location = new System.Drawing.Point(368, 4);
                    }
                    SelectLeaveSubTab(LeaveSubTab.Requests);
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
                case ActiveView.Ledger:
                    HighlightNav(btnNavLedger);
                    lblBreadcrumb.Text = "Quota Ledger  /  Balances";
                    SetupLedgerToolbar();
                    LoadLedgerGrid();
                    break;
            }
        }

        private void ResetNavButtons()
        {
            foreach (var btn in new[] { btnNavDashboard, btnNavLeaves, btnNavEmployees, btnNavDepartments, btnNavRoles, btnNavLedger })
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

            lblEmpKpi1Val.Text = total.ToString();
            lblEmpKpi2Val.Text = active.ToString();
            lblEmpKpi3Val.Text = onDuty.ToString();
            lblEmpKpi4Val.Text = depts.ToString();

            pnlEmpDeptBarContainer.Invalidate();
            pnlDemographicsContainer.Invalidate();
        }

        private void pnlEmpDeptBarContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var depts = DataStore.Instance.Departments;
            int count = depts.Count;
            if (count == 0) return;

            int maxStaff = Math.Max(1, depts.Max(d => d.ActiveStaffCount));

            int totalW = pnlEmpDeptBarContainer.ClientSize.Width;
            int totalH = pnlEmpDeptBarContainer.ClientSize.Height;

            int chartLeft = 40;
            int chartRight = totalW - 20;
            int chartTop = 30;
            int chartBottom = totalH - 45;
            int chartHeight = chartBottom - chartTop;
            int chartWidth = chartRight - chartLeft;

            using (var gridPen = new Pen(Color.FromArgb(241, 245, 249), 1))
            {
                for (int i = 0; i <= 4; i++)
                {
                    int y = chartBottom - (chartHeight * i) / 4;
                    e.Graphics.DrawLine(gridPen, chartLeft, y, chartRight, y);
                }
            }

            Color[] deptColors = new[]
            {
                Color.FromArgb(37, 99, 235),  // ENG - Royal Blue
                Color.FromArgb(234, 88, 12),  // HR - Corporate Orange
                Color.FromArgb(16, 185, 129), // FIN - Emerald
                Color.FromArgb(139, 92, 246), // OPS - Violet
                Color.FromArgb(245, 158, 11)  // LEG - Amber
            };

            int barSlotW = chartWidth / count;
            int barWidth = Math.Min(48, barSlotW - 20);

            using (var textBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (var mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            using (var fontVal = new Font("Segoe UI", 10.5f, FontStyle.Bold))
            using (var fontLabel = new Font("Segoe UI", 9f))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center })
            {
                for (int i = 0; i < count; i++)
                {
                    var d = depts[i];
                    int slotCenter = chartLeft + (i * barSlotW) + (barSlotW / 2);
                    int barH = (d.ActiveStaffCount * (chartHeight - 20)) / maxStaff;
                    int barX = slotCenter - (barWidth / 2);
                    int barY = chartBottom - barH;

                    Color c = deptColors[i % deptColors.Length];
                    using (var brush = new SolidBrush(c))
                    {
                        e.Graphics.FillRectangle(brush, barX, barY, barWidth, barH);
                    }

                    e.Graphics.DrawString(d.ActiveStaffCount.ToString(), fontVal, textBrush, slotCenter, barY - 22, sf);
                    e.Graphics.DrawString(d.Code, fontLabel, mutedBrush, slotCenter, chartBottom + 8, sf);
                }
            }
        }

        private void pnlDemographicsContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var employees = DataStore.Instance.Employees;
            int total = Math.Max(1, employees.Count);

            int maleCount = employees.Count(emp => emp.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase));
            int femaleCount = total - maleCount;

            int activeCount = employees.Count(emp => emp.IsActive);
            int inactiveCount = total - activeCount;

            int onLeave = DataStore.Instance.LeaveRequests.Count(r => r.Status == RequestStatus.APPROVED &&
                DateTime.Today >= r.StartDate.Date && DateTime.Today <= r.EndDate.Date);
            int onDuty = Math.Max(0, activeCount - onLeave);

            int containerW = pnlDemographicsContainer.ClientSize.Width - 20;

            DrawSegmentMeter(e.Graphics, 10, 20, containerW, "Gender Diversity",
                new[] {
                    new { Label = "Male", Count = maleCount, Color = Color.FromArgb(59, 130, 246) },
                    new { Label = "Female", Count = femaleCount, Color = Color.FromArgb(236, 72, 153) }
                }, total);

            DrawSegmentMeter(e.Graphics, 10, 150, containerW, "Employment Status",
                new[] {
                    new { Label = "Active", Count = activeCount, Color = Color.FromArgb(16, 185, 129) },
                    new { Label = "Inactive", Count = inactiveCount, Color = Color.FromArgb(148, 163, 184) }
                }, total);

            DrawSegmentMeter(e.Graphics, 10, 280, containerW, "Workforce Availability Today",
                new[] {
                    new { Label = "On Duty", Count = onDuty, Color = Color.FromArgb(16, 185, 129) },
                    new { Label = "On Leave", Count = onLeave, Color = Color.FromArgb(245, 158, 11) }
                }, total);
        }

        private void DrawSegmentMeter(Graphics g, int x, int y, int width, string title, dynamic[] segments, int total)
        {
            using (var fontTitle = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (var fontText = new Font("Segoe UI", 8.5f))
            using (var titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (var mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                g.DrawString(title, fontTitle, titleBrush, x, y);

                int barY = y + 26;
                int barHeight = 12;

                int curX = x;
                for (int i = 0; i < segments.Length; i++)
                {
                    var seg = segments[i];
                    int segW = (int)(((double)seg.Count / total) * width);
                    if (i == segments.Length - 1) segW = width - (curX - x);

                    using (var brush = new SolidBrush(seg.Color))
                    {
                        g.FillRectangle(brush, curX, barY, Math.Max(2, segW), barHeight);
                    }
                    curX += segW;
                }

                int legendY = barY + 20;
                int legX = x;
                foreach (var seg in segments)
                {
                    double pct = ((double)seg.Count / total) * 100.0;
                    using (var brush = new SolidBrush(seg.Color))
                    {
                        g.FillEllipse(brush, legX, legendY + 3, 9, 9);
                    }
                    string text = $"{seg.Label}: {seg.Count} ({pct:F1}%)";
                    g.DrawString(text, fontText, mutedBrush, legX + 15, legendY);
                    legX += 140;
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
            lblLeaveKpi2Val.Text = pending.ToString();
            lblLeaveKpi3Val.Text = clearance.ToString();
            lblLeaveKpi4Val.Text = active.ToString();

            pnlPieContainer.Invalidate();
        }

        private (Rectangle pieRect, dynamic[] segments, float[] startAngles, float[] sweepAngles) GetPieGeometry()
        {
            var reqs = DataStore.Instance.LeaveRequests;
            int total = reqs.Count;
            int approved = reqs.Count(r => r.Status == RequestStatus.APPROVED);
            int pending = reqs.Count(r => r.Status == RequestStatus.SUBMITTED || r.Status == RequestStatus.UNDER_REVIEW);
            int clearance = reqs.Count(r => r.Status == RequestStatus.CLEARANCE_IN_PROGRESS);
            int draft = reqs.Count(r => r.Status == RequestStatus.DRAFT);
            int rejected = reqs.Count(r => r.Status == RequestStatus.REJECTED);
            int cancelled = reqs.Count(r => r.Status == RequestStatus.CANCELLED);

            int chartSize = Math.Min(220, pnlPieContainer.ClientSize.Height - 110);
            int chartX = (pnlPieContainer.ClientSize.Width - chartSize) / 2;
            int chartY = 20;
            Rectangle pieRect = new Rectangle(chartX, chartY, chartSize, chartSize);

            var segList = new List<dynamic>
            {
                new { Label = "Approved", Count = approved, Color = Color.FromArgb(22, 163, 74) },
                new { Label = "Under Review", Count = pending, Color = Color.FromArgb(234, 88, 12) },
                new { Label = "In Clearance", Count = clearance, Color = Color.FromArgb(37, 99, 235) },
                new { Label = "Draft", Count = draft, Color = Color.FromArgb(100, 116, 139) },
                new { Label = "Rejected", Count = rejected, Color = Color.FromArgb(220, 38, 38) }
            };

            if (cancelled > 0)
            {
                segList.Add(new { Label = "Cancelled", Count = cancelled, Color = Color.FromArgb(148, 163, 184) });
            }

            var segments = segList.ToArray();
            int totalSegs = segments.Sum(s => (int)s.Count);
            int safeTotal = Math.Max(1, totalSegs);

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

            return (pieRect, segments, startAngles, sweepAngles);
        }

        private void pnlPieContainer_MouseMove(object sender, MouseEventArgs e)
        {
            var geo = GetPieGeometry();
            int centerX = geo.pieRect.X + geo.pieRect.Width / 2;
            int centerY = geo.pieRect.Y + geo.pieRect.Height / 2;

            int dx = e.X - centerX;
            int dy = e.Y - centerY;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            int radius = geo.pieRect.Width / 2;

            int hoveredIndex = -1;
            if (dist <= radius + 10)
            {
                double angle = Math.Atan2(dy, dx) * 180 / Math.PI;
                double adjAngle = (angle + 90 + 360) % 360;

                for (int i = 0; i < geo.segments.Length; i++)
                {
                    if (geo.sweepAngles[i] <= 0) continue;

                    double sAngle = (geo.startAngles[i] + 90 + 360) % 360;
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

            var geo = GetPieGeometry();
            int actualTotal = DataStore.Instance.LeaveRequests.Count;
            int total = Math.Max(1, actualTotal);

            // 1. Draw circular base background and distinct border so the pie chart outline is always clearly visible against white background
            using (var baseBrush = new SolidBrush(Color.FromArgb(248, 250, 252)))
            using (var baseBorderPen = new Pen(Color.FromArgb(203, 213, 225), 2f))
            {
                e.Graphics.FillEllipse(baseBrush, geo.pieRect);
                e.Graphics.DrawEllipse(baseBorderPen, geo.pieRect);
            }

            // 2. Draw pie slices
            for (int i = 0; i < geo.segments.Length; i++)
            {
                if (geo.sweepAngles[i] <= 0) continue;

                var seg = geo.segments[i];
                Rectangle drawRect = geo.pieRect;

                if (i == _hoveredPieSlice)
                {
                    double midAngle = (geo.startAngles[i] + geo.sweepAngles[i] / 2) * Math.PI / 180.0;
                    int explodeX = (int)(Math.Cos(midAngle) * 8);
                    int explodeY = (int)(Math.Sin(midAngle) * 8);
                    drawRect.Offset(explodeX, explodeY);
                }

                using (var brush = new SolidBrush(seg.Color))
                {
                    e.Graphics.FillPie(brush, drawRect, geo.startAngles[i], geo.sweepAngles[i]);
                }

                using (var pen = new Pen(Color.White, 2f))
                {
                    e.Graphics.DrawPie(pen, drawRect, geo.startAngles[i], geo.sweepAngles[i]);
                }
            }

            // 3. Draw distinct outer circle border on top of slices for clean framing
            using (var outerBorderPen = new Pen(Color.FromArgb(203, 213, 225), 2f))
            {
                e.Graphics.DrawEllipse(outerBorderPen, geo.pieRect);
            }

            // If empty, draw "No Requests"
            if (actualTotal == 0)
            {
                using (var emptyFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (var emptyBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
                {
                    string emptyText = "No Requests";
                    var sz = e.Graphics.MeasureString(emptyText, emptyFont);
                    float ex = geo.pieRect.X + (geo.pieRect.Width - sz.Width) / 2;
                    float ey = geo.pieRect.Y + (geo.pieRect.Height - sz.Height) / 2;
                    e.Graphics.DrawString(emptyText, emptyFont, emptyBrush, ex, ey);
                }
            }

            // 4. Hover Tooltip
            if (_hoveredPieSlice >= 0 && _hoveredPieSlice < geo.segments.Length && geo.segments[_hoveredPieSlice].Count > 0)
            {
                var hSeg = geo.segments[_hoveredPieSlice];
                double hPct = ((double)hSeg.Count / total) * 100.0;
                string hoverText = $"{hSeg.Label}: {hSeg.Count} requests ({hPct:F1}%)";

                using (var fontTip = new Font("Segoe UI", 10f, FontStyle.Bold))
                using (var bgBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sz = e.Graphics.MeasureString(hoverText, fontTip);
                    int tipX = (pnlPieContainer.ClientSize.Width - (int)sz.Width) / 2;
                    int tipY = geo.pieRect.Y - 14;

                    e.Graphics.FillRectangle(bgBrush, tipX - 10, tipY - 4, sz.Width + 20, sz.Height + 8);
                    e.Graphics.DrawString(hoverText, fontTip, textBrush, tipX, tipY);
                }
            }

            // 5. Legend HORIZONTALLY BELOW the chart (Never on the right side)
            int legendY = geo.pieRect.Bottom + 35;
            int totalLegW = 0;
            string[] legTexts = new string[geo.segments.Length];
            Size[] textSizes = new Size[geo.segments.Length];

            using (var fontLeg = new Font("Segoe UI", 9.5f))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    var seg = geo.segments[i];
                    double pct = actualTotal > 0 ? (((double)seg.Count / actualTotal) * 100.0) : 0.0;
                    legTexts[i] = $"{seg.Label}: {seg.Count} ({pct:F1}%)";
                    var sz = TextRenderer.MeasureText(legTexts[i], fontLeg);
                    textSizes[i] = sz;
                    totalLegW += sz.Width + 36;
                }
            }

            int curLegX = Math.Max(20, (pnlPieContainer.ClientSize.Width - totalLegW) / 2);

            using (var fontLeg = new Font("Segoe UI", 9.5f))
            using (var fontBold = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            {
                for (int i = 0; i < geo.segments.Length; i++)
                {
                    var seg = geo.segments[i];
                    bool isHover = (i == _hoveredPieSlice);

                    // Wrap line if tight on smaller viewports
                    if (curLegX + textSizes[i].Width + 36 > pnlPieContainer.ClientSize.Width - 10 && curLegX > 20)
                    {
                        curLegX = 20;
                        legendY += 24;
                    }

                    using (var bulletBrush = new SolidBrush(seg.Color))
                    {
                        e.Graphics.FillEllipse(bulletBrush, curLegX, legendY + 4, 10, 10);
                        using (var bulletBorder = new Pen(Color.FromArgb(203, 213, 225), 1f))
                        {
                            e.Graphics.DrawEllipse(bulletBorder, curLegX, legendY + 4, 10, 10);
                        }
                    }

                    var fontToUse = isHover ? fontBold : fontLeg;
                    e.Graphics.DrawString(legTexts[i], fontToUse, textBrush, curLegX + 16, legendY);

                    curLegX += textSizes[i].Width + 36;
                }
            }
        }

        private void btnLeaveTabRequests_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Requests);
        private void btnLeaveTabApprovals_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Approvals);
        private void btnLeaveTabTypes_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Types);
        private void btnLeaveTabEntitlements_Click(object sender, EventArgs e) => SelectLeaveSubTab(LeaveSubTab.Entitlements);

        private void SelectLeaveSubTab(LeaveSubTab tab)
        {
            _currentLeaveSubTab = tab;
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

        private void SetupLedgerToolbar()
        {
            txtSearch.PlaceholderText = "Search ledger by employee...";
            cboFilter1.Visible = true;
            cboFilter1.Items.Clear();
            cboFilter1.Items.Add("All Leave Types");
            foreach (var lt in DataStore.Instance.LeaveTypes) cboFilter1.Items.Add(lt.Name);
            cboFilter1.SelectedIndex = 0;

            cboFilter2.Visible = false;
            btnToolbarAction.Visible = true;
            btnToolbarAction.Text = "Export CSV";
        }

        private void FilterOrSearch_Changed(object sender, EventArgs e)
        {
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
            else if (_currentView == ActiveView.Ledger)
            {
                LoadLedgerGrid();
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

            dgvData.Columns.Add("EmpCode", "Emp Code");
            dgvData.Columns.Add("EmpName", "Employee Name");
            dgvData.Columns.Add("Dept", "Department");
            dgvData.Columns.Add("LeaveType", "Leave Type");
            dgvData.Columns.Add("Base", "Base");
            dgvData.Columns.Add("Carried", "Carried");
            dgvData.Columns.Add("Bonus", "Tenure Bonus");
            dgvData.Columns.Add("Total", "Allocated");
            dgvData.Columns.Add("Used", "Taken");
            dgvData.Columns.Add("Balance", "Balance");
            dgvData.Columns.Add("Rate", "Utilization %");

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string typeFilter = cboFilter1.SelectedItem?.ToString() ?? "All Leave Types";

            foreach (var ent in DataStore.Instance.Entitlements)
            {
                var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == ent.EmployeeId);
                var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == ent.LeaveTypeId);

                if (typeFilter != "All Leave Types" && lt?.Name != typeFilter) continue;

                string empCode = emp?.EmployeeCode ?? "N/A";
                string empName = emp?.FullName ?? "N/A";
                string deptName = emp?.DepartmentName ?? "N/A";
                string typeName = lt?.Name ?? "N/A";

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = empCode.ToLowerInvariant().Contains(search) ||
                                 empName.ToLowerInvariant().Contains(search) ||
                                 deptName.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                dgvData.Rows.Add(
                    empCode, empName, deptName, typeName, ent.BaseDays, ent.CarriedOverDays,
                    $"+{ent.TenureBonusDays}", ent.TotalAllocatedDays, ent.UsedDays, ent.BalanceDays, $"{ent.UtilizationRate}%"
                );
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
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = dgvData.Columns[e.ColumnIndex].Name;
            if (colName == "Status")
            {
                string val = e.Value.ToString() ?? "";
                if (val == "APPROVED") { e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); e.CellStyle.Font = new Font(dgvData.Font, FontStyle.Bold); }
                else if (val == "REJECTED" || val == "CANCELLED") { e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); }
                else if (val == "CLEARANCE_IN_PROGRESS") { e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); }
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
            else if (_currentView == ActiveView.Ledger)
            {
                CsvExporter.ExportGridToCsv(dgvData, "Leave_Quota_Ledger.csv");
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

            c1.Location = new Point(0, 0);
            c1.Size = new Size(cardW, 98);

            c2.Location = new Point(cardW + gap, 0);
            c2.Size = new Size(cardW, 98);

            c3.Location = new Point((cardW + gap) * 2, 0);
            c3.Size = new Size(cardW, 98);

            c4.Location = new Point((cardW + gap) * 3, 0);
            c4.Size = new Size(Math.Max(cardW, totalW - (cardW + gap) * 3), 98);
        }

        private void pnlEmpContent_Resize(object sender, EventArgs e)
        {
            int totalW = pnlEmpContent.ClientSize.Width;
            int totalH = pnlEmpContent.ClientSize.Height;
            int gap = 14;
            int halfW = (totalW - gap) / 2;

            cardEmpDeptChart.Location = new Point(0, 0);
            cardEmpDeptChart.Size = new Size(halfW, totalH - 10);

            cardEmpDemographics.Location = new Point(halfW + gap, 0);
            cardEmpDemographics.Size = new Size(Math.Max(200, totalW - (halfW + gap)), totalH - 10);
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
