using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Common;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public class ConfigurationsView : UserControl
    {
        // ---------------------------------------------------------------------
        // Controls: Sub Sidebar
        // ---------------------------------------------------------------------
        private Panel pnlSidebar = null!;
        private Panel pnlSidebarHeader = null!;
        private Label lblSidebarTitle = null!;
        private Label lblSidebarCountBadge = null!;
                private TextBox txtNavFilter = null!;
        private Panel pnlNavList = null!;

        private Panel btnNavClearance = null!;
        private Panel btnNavApprovals = null!;
        private Panel btnNavLeave = null!;

        // ---------------------------------------------------------------------
        // Controls: Main Content Pane & Sections
        // ---------------------------------------------------------------------
        private Panel pnlContentPane = null!;
        private Panel pnlSecClearance = null!;
        private Panel pnlSecApprovals = null!;
        private Panel pnlSecLeave = null!;

        // Clearance Section Controls
        private TextBox txtSearchClearance = null!;
        private ComboBox cboFilterClearanceType = null!;
        private Button btnNewClearancePolicy = null!;
        private DataGridView dgvClearance = null!;
        private ContextMenuStrip menuClearance = null!;

        // Approval Section Controls
        private TextBox txtSearchApproval = null!;
        private ComboBox cboFilterApprovalType = null!;
        private Button btnNewApprovalWorkflow = null!;
        private DataGridView dgvApprovals = null!;
        private ContextMenuStrip menuApproval = null!;

        // Leave Settings Section Controls (Toggle Cards!)
        private ComboBox cboLeaveCategorySelect = null!;
        private Button btnNewLeaveCategory = null!;
        private Button btnSaveLeavePolicy = null!;

        private Button btnToggleAttachment = null!;
        private Button btnToggleClearance = null!;
        private Button btnToggleCarryOver = null!;
        private Button btnToggleActivePolicy = null!;

        private NumericUpDown numDefaultQuota = null!;
        private NumericUpDown numMinServiceMonths = null!;
        private DataGridView dgvLeaveCategoriesSummary = null!;

        // State
        private string _activeSection = "clearance"; // "clearance", "approvals", "leave"
        private LeaveType? _selectedLeaveType;

        public ConfigurationsView()
        {
            InitializeComponent();
            ApplyStyling();
            SelectSection("clearance");
            RefreshData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Dock = DockStyle.Fill;
            this.Font = new Font("Segoe UI", 9.5f);

            // =================================================================
            // 1. Sub Sidebar (Left: Width 260)
            // =================================================================
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = Color.White
            };
            pnlSidebar.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            };

            // Sidebar Header
            pnlSidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 72,
                Padding = new Padding(14, 10, 14, 8)
            };

            lblSidebarTitle = new Label
            {
                Text = "⚙️  CONFIGURATIONS",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(14, 10),
                AutoSize = true
            };

            lblSidebarCountBadge = new Label
            {
                Text = "3",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                BackColor = Color.FromArgb(241, 245, 249),
                Location = new Point(218, 10),
                Size = new Size(24, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            txtNavFilter = new TextBox
            {
                PlaceholderText = "Filter settings...",
                Location = new Point(14, 36),
                Size = new Size(230, 26),
                Font = new Font("Segoe UI", 9f)
            };
            txtNavFilter.TextChanged += (s, e) => FilterNavItems();

            pnlSidebarHeader.Controls.AddRange(new Control[] {
                lblSidebarTitle, lblSidebarCountBadge, txtNavFilter
            });

            // Nav List Panel
            pnlNavList = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(8, 6, 8, 8)
            };

            btnNavClearance = CreateNavItem(
                "clearance",
                "🛡️",
                "Clearance Settings",
                "Exit clearances & checkpoints",
                0
            );

            btnNavApprovals = CreateNavItem(
                "approvals",
                "🔀",
                "Approval Workflows",
                "Multi-step hierarchy rules",
                1
            );

            btnNavLeave = CreateNavItem(
                "leave",
                "📅",
                "Leave Settings",
                "Category rules & policy toggles",
                2
            );

            pnlNavList.Controls.AddRange(new Control[] { btnNavClearance, btnNavApprovals, btnNavLeave });
            pnlSidebar.Controls.Add(pnlNavList);
            pnlSidebar.Controls.Add(pnlSidebarHeader);

            // =================================================================
            // 2. Main Content Pane
            // =================================================================
            pnlContentPane = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(24)
            };

            // Build Section 1: Clearance
            BuildClearanceSection();

            // Build Section 2: Approvals
            BuildApprovalsSection();

            // Build Section 3: Leave Settings (Toggle Cards)
            BuildLeaveSection();

            pnlContentPane.Controls.AddRange(new Control[] { pnlSecLeave, pnlSecApprovals, pnlSecClearance });

            this.Controls.Add(pnlContentPane);
            this.Controls.Add(pnlSidebar);
            this.ResumeLayout(false);
        }

        // =====================================================================
        // Sub-Sidebar Item Creation & Switching
        // =====================================================================
        private Panel CreateNavItem(string sectionId, string icon, string title, string sub, int orderIndex)
        {
            var pnl = new Panel
            {
                Height = 54,
                Dock = DockStyle.Top,
                Cursor = Cursors.Hand,
                Tag = sectionId,
                Margin = new Padding(0, 0, 0, 4)
            };

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 12f),
                Location = new Point(12, 14),
                Size = new Size(24, 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(40, 9),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            var lblSub = new Label
            {
                Text = sub,
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(40, 28),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            Action clickAction = () => SelectSection(sectionId);
            pnl.Click += (s, e) => clickAction();
            lblIcon.Click += (s, e) => clickAction();
            lblTitle.Click += (s, e) => clickAction();
            lblSub.Click += (s, e) => clickAction();

            pnl.Controls.AddRange(new Control[] { lblIcon, lblTitle, lblSub });
            return pnl;
        }

        private void FilterNavItems()
        {
            string q = txtNavFilter.Text.Trim().ToLowerInvariant();
            btnNavClearance.Visible = string.IsNullOrEmpty(q) || "clearance settings exit checkpoints".Contains(q);
            btnNavApprovals.Visible = string.IsNullOrEmpty(q) || "approval workflows hierarchy multi-step rules".Contains(q);
            btnNavLeave.Visible = string.IsNullOrEmpty(q) || "leave settings category rules attachments policies".Contains(q);
        }

        private void SelectSection(string sectionId)
        {
            _activeSection = sectionId;

            // Highlight sub-nav items
            UpdateNavStyle(btnNavClearance, sectionId == "clearance");
            UpdateNavStyle(btnNavApprovals, sectionId == "approvals");
            UpdateNavStyle(btnNavLeave, sectionId == "leave");

            // Show appropriate content pane
            pnlSecClearance.Visible = (sectionId == "clearance");
            pnlSecApprovals.Visible = (sectionId == "approvals");
            pnlSecLeave.Visible = (sectionId == "leave");

            if (sectionId == "clearance") LoadClearanceGrid();
            else if (sectionId == "approvals") LoadApprovalGrid();
            else if (sectionId == "leave") LoadLeaveCategoryForm();
        }

        private void UpdateNavStyle(Panel pnl, bool isActive)
        {
            var lblTitle = pnl.Controls.OfType<Label>().FirstOrDefault(l => l.Location.Y == 9);
            var lblSub = pnl.Controls.OfType<Label>().FirstOrDefault(l => l.Location.Y == 28);

            if (isActive)
            {
                pnl.BackColor = Color.FromArgb(255, 247, 237); // Light orange #FFF7ED
                if (lblTitle != null)
                {
                    lblTitle.ForeColor = Color.FromArgb(234, 88, 12);
                    lblTitle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                if (lblSub != null) lblSub.ForeColor = Color.FromArgb(194, 65, 12);
            }
            else
            {
                pnl.BackColor = Color.Transparent;
                if (lblTitle != null)
                {
                    lblTitle.ForeColor = Color.FromArgb(51, 65, 85);
                    lblTitle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
                if (lblSub != null) lblSub.ForeColor = Color.FromArgb(100, 116, 139);
            }

            pnl.Invalidate();
        }

        // =====================================================================
        // SECTION 1: Clearance Settings
        // =====================================================================
        private void BuildClearanceSection()
        {
            pnlSecClearance = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Visible = false
            };

            // Header
            var pnlHead = new Panel { Dock = DockStyle.Top, Height = 42 };
            var lblTitle = new Label
            {
                Text = "Clearance Settings",
                Font = new Font("Segoe UI", 13.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(0, 4),
                AutoSize = true
            };
            btnNewClearancePolicy = new Button
            {
                Text = "+ New Policy",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(pnlSecClearance.Width - 140, 4),
                Size = new Size(130, 32),
                BackColor = Color.FromArgb(234, 88, 12),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnNewClearancePolicy.FlatAppearance.BorderSize = 0;
            btnNewClearancePolicy.Click += (s, e) =>
            {
                using var dlg = new ClearancePolicyDialog();
                if (dlg.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadClearanceGrid();
                }
            };
            pnlHead.Controls.AddRange(new Control[] { lblTitle, btnNewClearancePolicy });

            // Toolbar
            var pnlTool = new Panel { Dock = DockStyle.Top, Height = 44 };
            txtSearchClearance = new TextBox
            {
                PlaceholderText = "Search clearance policies...",
                Location = new Point(0, 8),
                Size = new Size(220, 27),
                Font = new Font("Segoe UI", 9.5f)
            };
            txtSearchClearance.TextChanged += (s, e) => LoadClearanceGrid();

            cboFilterClearanceType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(230, 8),
                Size = new Size(220, 27),
                Font = new Font("Segoe UI", 9.5f)
            };
            cboFilterClearanceType.Items.AddRange(new object[] {
                "All Request Types",
                "Study & Sabbatical Leave",
                "Employment Termination",
                "Inter-Department Transfer"
            });
            cboFilterClearanceType.SelectedIndex = 0;
            cboFilterClearanceType.SelectedIndexChanged += (s, e) => LoadClearanceGrid();

            pnlTool.Controls.AddRange(new Control[] { txtSearchClearance, cboFilterClearanceType });

            // Grid
            dgvClearance = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            ElmsTheme.ApplyGridStyle(dgvClearance);

            // Columns matching clearance-policy-columns.tsx
            dgvClearance.Columns.Add("PolicyName", "Policy Name");
            dgvClearance.Columns.Add("RequestType", "Request Type");
            dgvClearance.Columns.Add("WorkflowMode", "Workflow Mode");
            dgvClearance.Columns.Add("LetterCertificate", "Letter / Certificate");
            dgvClearance.Columns.Add("Checkpoints", "Checkpoints");
            dgvClearance.Columns.Add("Status", "Status");
            dgvClearance.Columns.Add("CreatedAt", "Created At");

            var colAction = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "\u22EE",
                UseColumnTextForButtonValue = true,
                Width = 65
            };
            dgvClearance.Columns.Add(colAction);
            dgvClearance.CellContentClick += dgvClearance_CellContentClick;

            // Context Menu
            menuClearance = new ContextMenuStrip();
            var itemEditClr = new ToolStripMenuItem("⚙️  Configure Workflow");
            itemEditClr.Click += (s, e) =>
            {
                if (dgvClearance.SelectedRows.Count > 0 && dgvClearance.SelectedRows[0].Tag is ClearancePolicy pol)
                {
                    using var dlg = new ClearancePolicyDialog(pol);
                    if (dlg.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadClearanceGrid();
                    }
                }
            };
            var itemDelClr = new ToolStripMenuItem("🗑️  Delete Policy");
            itemDelClr.Click += (s, e) =>
            {
                if (dgvClearance.SelectedRows.Count > 0 && dgvClearance.SelectedRows[0].Tag is ClearancePolicy pol)
                {
                    if (MessageBox.Show($"Are you sure you want to delete policy '{pol.Name}'?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DataStore.Instance.ClearancePolicies.Remove(pol);
                        LoadClearanceGrid();
                    }
                }
            };
            menuClearance.Items.AddRange(new ToolStripItem[] { itemEditClr, itemDelClr });

            pnlSecClearance.Controls.Add(dgvClearance);
            pnlSecClearance.Controls.Add(pnlTool);
            pnlSecClearance.Controls.Add(pnlHead);
        }

        private void LoadClearanceGrid()
        {
            dgvClearance.Rows.Clear();
            string search = txtSearchClearance.Text.Trim().ToLowerInvariant();
            string filterType = cboFilterClearanceType.SelectedItem?.ToString() ?? "All Request Types";

            foreach (var pol in DataStore.Instance.ClearancePolicies)
            {
                if (filterType != "All Request Types" && pol.RequestType != filterType) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = pol.Name.ToLowerInvariant().Contains(search) ||
                                 pol.RequestType.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                string mode = pol.IsSequential ? "Sequential Order" : "Parallel Clearance";
                string letter = pol.GenerateClearanceLetter ? "Auto-Signed PDF" : "Disabled";
                string checkpoints = $"{pol.RequiredUnits.Count} Departments";
                string status = pol.IsActive ? "Active" : "Inactive";
                string created = pol.CreatedAt;

                int rowIdx = dgvClearance.Rows.Add(
                    pol.Name,
                    pol.RequestType,
                    mode,
                    letter,
                    checkpoints,
                    status,
                    created
                );

                dgvClearance.Rows[rowIdx].Tag = pol;
            }
        }

        private void dgvClearance_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClearance.Columns[e.ColumnIndex].Name == "Actions")
            {
                var rect = dgvClearance.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                menuClearance.Show(dgvClearance, rect.Left, rect.Bottom);
            }
        }

        // =====================================================================
        // SECTION 2: Approval Workflows
        // =====================================================================
        private void BuildApprovalsSection()
        {
            pnlSecApprovals = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Visible = false
            };

            // Header
            var pnlHead = new Panel { Dock = DockStyle.Top, Height = 42 };
            var lblTitle = new Label
            {
                Text = "Approval Workflows",
                Font = new Font("Segoe UI", 13.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(0, 4),
                AutoSize = true
            };
            btnNewApprovalWorkflow = new Button
            {
                Text = "+ New Workflow",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(pnlSecApprovals.Width - 150, 4),
                Size = new Size(140, 32),
                BackColor = Color.FromArgb(234, 88, 12),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnNewApprovalWorkflow.FlatAppearance.BorderSize = 0;
            btnNewApprovalWorkflow.Click += (s, e) =>
            {
                using var dlg = new ApprovalWorkflowDialog();
                if (dlg.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadApprovalGrid();
                }
            };
            pnlHead.Controls.AddRange(new Control[] { lblTitle, btnNewApprovalWorkflow });

            // Toolbar
            var pnlTool = new Panel { Dock = DockStyle.Top, Height = 44 };
            txtSearchApproval = new TextBox
            {
                PlaceholderText = "Search approval workflows...",
                Location = new Point(0, 8),
                Size = new Size(220, 27),
                Font = new Font("Segoe UI", 9.5f)
            };
            txtSearchApproval.TextChanged += (s, e) => LoadApprovalGrid();

            cboFilterApprovalType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(230, 8),
                Size = new Size(220, 27),
                Font = new Font("Segoe UI", 9.5f)
            };
            cboFilterApprovalType.Items.AddRange(new object[] {
                "All Request Types",
                "Leave Request",
                "Study & Sabbatical Leave",
                "Overtime Request"
            });
            cboFilterApprovalType.SelectedIndex = 0;
            cboFilterApprovalType.SelectedIndexChanged += (s, e) => LoadApprovalGrid();

            pnlTool.Controls.AddRange(new Control[] { txtSearchApproval, cboFilterApprovalType });

            // Grid
            dgvApprovals = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            ElmsTheme.ApplyGridStyle(dgvApprovals);

            // Columns matching approval-workflow-columns.tsx
            dgvApprovals.Columns.Add("WorkflowName", "Workflow Name");
            dgvApprovals.Columns.Add("RequestType", "Request Type");
            dgvApprovals.Columns.Add("Steps", "Steps");
            dgvApprovals.Columns.Add("Status", "Status");
            dgvApprovals.Columns.Add("CreatedAt", "Created At");

            var colAction = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "\u22EE",
                UseColumnTextForButtonValue = true,
                Width = 65
            };
            dgvApprovals.Columns.Add(colAction);
            dgvApprovals.CellContentClick += dgvApprovals_CellContentClick;

            // Context Menu
            menuApproval = new ContextMenuStrip();
            var itemEditAppr = new ToolStripMenuItem("⚙️  Manage Workflow");
            itemEditAppr.Click += (s, e) =>
            {
                if (dgvApprovals.SelectedRows.Count > 0 && dgvApprovals.SelectedRows[0].Tag is ApprovalWorkflowDefinition wf)
                {
                    using var dlg = new ApprovalWorkflowDialog(wf);
                    if (dlg.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        LoadApprovalGrid();
                    }
                }
            };
            var itemDelAppr = new ToolStripMenuItem("🗑️  Delete Workflow");
            itemDelAppr.Click += (s, e) =>
            {
                if (dgvApprovals.SelectedRows.Count > 0 && dgvApprovals.SelectedRows[0].Tag is ApprovalWorkflowDefinition wf)
                {
                    if (MessageBox.Show($"Are you sure you want to delete workflow '{wf.Name}'?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DataStore.Instance.ApprovalWorkflows.Remove(wf);
                        LoadApprovalGrid();
                    }
                }
            };
            menuApproval.Items.AddRange(new ToolStripItem[] { itemEditAppr, itemDelAppr });

            pnlSecApprovals.Controls.Add(dgvApprovals);
            pnlSecApprovals.Controls.Add(pnlTool);
            pnlSecApprovals.Controls.Add(pnlHead);
        }

        private void LoadApprovalGrid()
        {
            dgvApprovals.Rows.Clear();
            string search = txtSearchApproval.Text.Trim().ToLowerInvariant();
            string filterType = cboFilterApprovalType.SelectedItem?.ToString() ?? "All Request Types";

            foreach (var wf in DataStore.Instance.ApprovalWorkflows)
            {
                if (filterType != "All Request Types" && wf.RequestType != filterType) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    bool match = wf.Name.ToLowerInvariant().Contains(search) ||
                                 wf.RequestType.ToLowerInvariant().Contains(search);
                    if (!match) continue;
                }

                string steps = $"{wf.Steps.Count} Steps";
                string status = wf.IsActive ? "Active" : "Inactive";
                string created = wf.CreatedAt;

                int rowIdx = dgvApprovals.Rows.Add(
                    wf.Name,
                    wf.RequestType,
                    steps,
                    status,
                    created
                );

                dgvApprovals.Rows[rowIdx].Tag = wf;
            }
        }

        private void dgvApprovals_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvApprovals.Columns[e.ColumnIndex].Name == "Actions")
            {
                var rect = dgvApprovals.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                menuApproval.Show(dgvApprovals, rect.Left, rect.Bottom);
            }
        }

        // =====================================================================
        // SECTION 3: Leave Settings (Toggle Cards!)
        // =====================================================================
        private void BuildLeaveSection()
        {
            pnlSecLeave = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Visible = false,
                AutoScroll = true
            };

            // Section Header
            var pnlHead = new Panel { Dock = DockStyle.Top, Height = 36 };
            var lblTitle = new Label
            {
                Text = "Leave Settings",
                Font = new Font("Segoe UI", 13.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(0, 4),
                AutoSize = true
            };
            pnlHead.Controls.Add(lblTitle);

            // Category Selection Bar Card
            var cardCatBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 54,
                BackColor = Color.White,
                Padding = new Padding(12)
            };
            cardCatBar.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, cardCatBar.Width - 1, cardCatBar.Height - 1);
            };

            var lblCatSelect = new Label
            {
                Text = "Leave Category:",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 16),
                AutoSize = true
            };

            cboLeaveCategorySelect = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(135, 12),
                Size = new Size(230, 29),
                Font = new Font("Segoe UI", 9.5f)
            };
            cboLeaveCategorySelect.SelectedIndexChanged += (s, e) => OnLeaveCategoryChanged();

            btnNewLeaveCategory = new Button
            {
                Text = "+ New Category",
                Location = new Point(378, 11),
                Size = new Size(130, 31),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(30, 41, 59),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnNewLeaveCategory.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnNewLeaveCategory.Click += (s, e) =>
            {
                using var dlg = new LeaveTypeDialog();
                if (dlg.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    PopulateLeaveCategoriesCombo();
                }
            };

            btnSaveLeavePolicy = new Button
            {
                Text = "💾  Save Changes",
                Location = new Point(518, 11),
                Size = new Size(140, 31),
                BackColor = Color.FromArgb(234, 88, 12),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSaveLeavePolicy.FlatAppearance.BorderSize = 0;
            btnSaveLeavePolicy.Click += (s, e) => SaveCurrentLeaveSettings();

            cardCatBar.Controls.AddRange(new Control[] {
                lblCatSelect, cboLeaveCategorySelect, btnNewLeaveCategory, btnSaveLeavePolicy
            });

            // Spacer
            var sp1 = new Panel { Dock = DockStyle.Top, Height = 14 };

            // Toggle Switches Cards Container
            var pnlTogglesHost = new Panel
            {
                Dock = DockStyle.Top,
                Height = 224,
                BackColor = Color.Transparent
            };

            // Toggle Card 1: Attachment
            var cardToggle1 = CreateToggleCard(
                "Required Attachment / Certificate",
                "Require official medical certificate or supporting document upload upon request submission.",
                out btnToggleAttachment
            );
            cardToggle1.Dock = DockStyle.Top;
            cardToggle1.Height = 52;

            // Toggle Card 2: Clearance
            var cardToggle2 = CreateToggleCard(
                "Enforce Clearance Workflow",
                "Require formal multi-department clearance completion before request can be approved (e.g. Study Leave).",
                out btnToggleClearance
            );
            cardToggle2.Dock = DockStyle.Top;
            cardToggle2.Height = 52;

            // Toggle Card 3: Carry Over
            var cardToggle3 = CreateToggleCard(
                "Permit Quota Carry-Over",
                "Allow remaining unused leave quota days to rollover to the subsequent fiscal year.",
                out btnToggleCarryOver
            );
            cardToggle3.Dock = DockStyle.Top;
            cardToggle3.Height = 52;

            // Toggle Card 4: Active Policy
            var cardToggle4 = CreateToggleCard(
                "Active Leave Policy",
                "Enable this category for employee self-service submission in Leave Requests desk.",
                out btnToggleActivePolicy
            );
            cardToggle4.Dock = DockStyle.Top;
            cardToggle4.Height = 52;

            pnlTogglesHost.Controls.AddRange(new Control[] { cardToggle4, cardToggle3, cardToggle2, cardToggle1 });

            // Numeric Inputs Card
            var cardNumeric = new Panel
            {
                Dock = DockStyle.Top,
                Height = 58,
                BackColor = Color.White,
                Padding = new Padding(14)
            };
            cardNumeric.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, cardNumeric.Width - 1, cardNumeric.Height - 1);
            };

            var lblQuota = new Label
            {
                Text = "Base Entitlement (Days):",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(14, 18),
                AutoSize = true
            };
            numDefaultQuota = new NumericUpDown
            {
                Location = new Point(175, 15),
                Size = new Size(80, 26),
                Minimum = 0,
                Maximum = 365,
                Value = 20
            };

            var lblService = new Label
            {
                Text = "Minimum Service (Months):",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location = new Point(285, 18),
                AutoSize = true
            };
            numMinServiceMonths = new NumericUpDown
            {
                Location = new Point(465, 15),
                Size = new Size(80, 26),
                Minimum = 0,
                Maximum = 120,
                Value = 6
            };

            cardNumeric.Controls.AddRange(new Control[] { lblQuota, numDefaultQuota, lblService, numMinServiceMonths });

            // Spacer
            var sp2 = new Panel { Dock = DockStyle.Top, Height = 14 };

            // Summary Grid of Categories
            var pnlGridWrap = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            pnlGridWrap.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlGridWrap.Width - 1, pnlGridWrap.Height - 1);
            };

            dgvLeaveCategoriesSummary = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            ElmsTheme.ApplyGridStyle(dgvLeaveCategoriesSummary);

            dgvLeaveCategoriesSummary.Columns.Add("Code", "Category Code");
            dgvLeaveCategoriesSummary.Columns.Add("Name", "Category Name");
            dgvLeaveCategoriesSummary.Columns.Add("Quota", "Base Quota (Days)");
            dgvLeaveCategoriesSummary.Columns.Add("Attachment", "Attachment / Cert");
            dgvLeaveCategoriesSummary.Columns.Add("Clearance", "Clearance Required");
            dgvLeaveCategoriesSummary.Columns.Add("CarryOver", "Carry-Over");
            dgvLeaveCategoriesSummary.Columns.Add("Status", "Status");

            var colEdit = new DataGridViewButtonColumn
            {
                Name = "EditAction",
                HeaderText = "Action",
                Text = "\u22EE",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvLeaveCategoriesSummary.Columns.Add(colEdit);
            dgvLeaveCategoriesSummary.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvLeaveCategoriesSummary.Columns[e.ColumnIndex].Name == "EditAction")
                {
                    if (dgvLeaveCategoriesSummary.Rows[e.RowIndex].Tag is LeaveType lt)
                    {
                        for (int i = 0; i < cboLeaveCategorySelect.Items.Count; i++)
                        {
                            if (cboLeaveCategorySelect.Items[i]?.ToString() == lt.Name)
                            {
                                cboLeaveCategorySelect.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            };

            pnlGridWrap.Controls.Add(dgvLeaveCategoriesSummary);

            // Assemble into pnlSecLeave
            pnlSecLeave.Controls.Add(pnlGridWrap);
            pnlSecLeave.Controls.Add(sp2);
            pnlSecLeave.Controls.Add(cardNumeric);
            pnlSecLeave.Controls.Add(pnlTogglesHost);
            pnlSecLeave.Controls.Add(sp1);
            pnlSecLeave.Controls.Add(cardCatBar);
            pnlSecLeave.Controls.Add(pnlHead);
        }

        private Panel CreateToggleCard(string title, string description, out Button toggleBtn)
        {
            var pnl = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 4)
            };
            pnl.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            };

            var lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 8),
                AutoSize = true
            };

            var lblD = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(14, 28),
                AutoSize = true
            };

            var btn = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(pnl.Width - 95, 11),
                Size = new Size(82, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = false
            };
            btn.FlatAppearance.BorderSize = 0;
            ApplyToggleState(btn, false);

            btn.Click += (s, e) =>
            {
                bool cur = (btn.Tag is bool b) && b;
                ApplyToggleState(btn, !cur);
            };

            toggleBtn = btn;
            pnl.Controls.AddRange(new Control[] { lblT, lblD, btn });
            return pnl;
        }

        private void ApplyToggleState(Button btn, bool isOn)
        {
            btn.Tag = isOn;
            if (isOn)
            {
                btn.Text = "ON  ●";
                btn.BackColor = Color.FromArgb(22, 163, 74); // Green #16A34A
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.Text = "○  OFF";
                btn.BackColor = Color.FromArgb(241, 245, 249); // Muted gray
                btn.ForeColor = Color.FromArgb(100, 116, 139);
            }
        }

        private void PopulateLeaveCategoriesCombo()
        {
            cboLeaveCategorySelect.Items.Clear();
            foreach (var lt in DataStore.Instance.LeaveTypes)
            {
                cboLeaveCategorySelect.Items.Add(lt.Name);
            }
            if (cboLeaveCategorySelect.Items.Count > 0)
            {
                cboLeaveCategorySelect.SelectedIndex = 0;
            }
        }

        private void OnLeaveCategoryChanged()
        {
            string catName = cboLeaveCategorySelect.SelectedItem?.ToString() ?? "";
            _selectedLeaveType = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Name == catName);

            if (_selectedLeaveType != null)
            {
                ApplyToggleState(btnToggleAttachment, _selectedLeaveType.RequiresCertificate);
                ApplyToggleState(btnToggleClearance, _selectedLeaveType.RequiresClearance);
                ApplyToggleState(btnToggleCarryOver, _selectedLeaveType.IsCarryForwardAllowed);
                ApplyToggleState(btnToggleActivePolicy, _selectedLeaveType.IsActive);

                numDefaultQuota.Value = Math.Max(numDefaultQuota.Minimum, Math.Min(numDefaultQuota.Maximum, _selectedLeaveType.EntitlementDays));
                numMinServiceMonths.Value = Math.Max(numMinServiceMonths.Minimum, Math.Min(numMinServiceMonths.Maximum, _selectedLeaveType.MinimumServiceMonths));
            }
        }

        private void SaveCurrentLeaveSettings()
        {
            if (_selectedLeaveType == null) return;

            _selectedLeaveType.RequiresCertificate = (btnToggleAttachment.Tag is bool b1) && b1;
            _selectedLeaveType.RequiresClearance = (btnToggleClearance.Tag is bool b2) && b2;
            _selectedLeaveType.IsCarryForwardAllowed = (btnToggleCarryOver.Tag is bool b3) && b3;
            _selectedLeaveType.IsActive = (btnToggleActivePolicy.Tag is bool b4) && b4;

            _selectedLeaveType.EntitlementDays = (int)numDefaultQuota.Value;
            _selectedLeaveType.MinimumServiceMonths = (int)numMinServiceMonths.Value;

            DataStore.Instance.NotifyChanged();
            LoadLeaveCategoriesSummary();

            MessageBox.Show(
                $"Policy settings for '{_selectedLeaveType.Name}' have been successfully updated!",
                "Settings Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void LoadLeaveCategoryForm()
        {
            PopulateLeaveCategoriesCombo();
            LoadLeaveCategoriesSummary();
        }

        private void LoadLeaveCategoriesSummary()
        {
            dgvLeaveCategoriesSummary.Rows.Clear();
            foreach (var lt in DataStore.Instance.LeaveTypes)
            {
                int rowIdx = dgvLeaveCategoriesSummary.Rows.Add(
                    lt.Code,
                    lt.Name,
                    $"{lt.EntitlementDays} Days",
                    lt.RequiresCertificate ? "Required" : "Optional",
                    lt.RequiresClearance ? "Enforced" : "None",
                    lt.IsCarryForwardAllowed ? "Allowed" : "Disabled",
                    lt.IsActive ? "Active" : "Inactive"
                );
                dgvLeaveCategoriesSummary.Rows[rowIdx].Tag = lt;
            }
        }

        // =====================================================================
        // Public API
        // =====================================================================
        public void RefreshData()
        {
            if (_activeSection == "clearance") LoadClearanceGrid();
            else if (_activeSection == "approvals") LoadApprovalGrid();
            else if (_activeSection == "leave") LoadLeaveCategoryForm();
        }

        private void ApplyStyling()
        {
            // Responsive anchor updates when resized
            this.Resize += (s, e) =>
            {
                if (btnNewClearancePolicy != null && pnlSecClearance != null)
                {
                    btnNewClearancePolicy.Location = new Point(pnlSecClearance.Width - 145, 8);
                }
                if (btnNewApprovalWorkflow != null && pnlSecApprovals != null)
                {
                    btnNewApprovalWorkflow.Location = new Point(pnlSecApprovals.Width - 155, 8);
                }
            };
        }
    }
}