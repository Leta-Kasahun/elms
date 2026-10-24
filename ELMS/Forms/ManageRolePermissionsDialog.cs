using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class ManageRolePermissionsDialog : Form
    {
        private readonly Role _role;
        private readonly HashSet<string> _selectedKeys;
        private readonly List<PermissionItemControl> _itemControls = new List<PermissionItemControl>();

        public ManageRolePermissionsDialog(Role role)
        {
            _role = role ?? throw new ArgumentNullException(nameof(role));
            _selectedKeys = new HashSet<string>(_role.Permissions ?? new List<string>());

            InitializeComponent();

            lblRoleName.Text = _role.Name;
            lblRoleKeyBadge.Text = _role.RoleKey;
            lblRoleDescription.Text = string.IsNullOrWhiteSpace(_role.Description) ? "No description provided." : _role.Description;

            // Adjust badge position next to role name
            using (var g = lblRoleName.CreateGraphics())
            {
                var size = g.MeasureString(lblRoleName.Text, lblRoleName.Font);
                lblRoleKeyBadge.Location = new Point((int)size.Width + 24, lblRoleKeyBadge.Location.Y);
            }

            BuildPermissionList();
            UpdateCountLabel();
        }

        private void BuildPermissionList()
        {
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();
            _itemControls.Clear();

            int y = 8;
            string lastModule = "";

            foreach (var perm in PermissionCatalog.All)
            {
                if (perm.Module != lastModule)
                {
                    lastModule = perm.Module;
                    var lblHeader = new Label
                    {
                        Text = perm.Module.ToUpperInvariant(),
                        Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(148, 163, 184),
                        Location = new Point(24, y),
                        Size = new Size(590, 22),
                        TextAlign = ContentAlignment.BottomLeft
                    };
                    pnlContent.Controls.Add(lblHeader);
                    y += 24;
                }

                var itemCtrl = new PermissionItemControl(perm, _selectedKeys.Contains(perm.Key));
                itemCtrl.Location = new Point(24, y);
                itemCtrl.Width = 590;
                itemCtrl.CheckedChanged += (s, isChecked) =>
                {
                    if (isChecked) _selectedKeys.Add(perm.Key);
                    else _selectedKeys.Remove(perm.Key);
                    UpdateCountLabel();
                };

                pnlContent.Controls.Add(itemCtrl);
                _itemControls.Add(itemCtrl);
                y += itemCtrl.Height + 4;
            }

            pnlContent.ResumeLayout();
        }

        private void FilterList()
        {
            string search = txtSearch.Text.Trim().ToLowerInvariant();
            pnlContent.SuspendLayout();

            int y = 8;
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is PermissionItemControl item)
                {
                    bool match = string.IsNullOrEmpty(search) ||
                                 item.Def.Name.ToLowerInvariant().Contains(search) ||
                                 item.Def.Key.ToLowerInvariant().Contains(search) ||
                                 item.Def.Module.ToLowerInvariant().Contains(search) ||
                                 item.Def.Description.ToLowerInvariant().Contains(search);

                    item.Visible = match;
                    if (match)
                    {
                        item.Location = new Point(24, y);
                        y += item.Height + 4;
                    }
                }
                else if (ctrl is Label lblModuleHeader)
                {
                    // keep headers visible when unfiltered, or adapt
                    lblModuleHeader.Visible = string.IsNullOrEmpty(search);
                    if (lblModuleHeader.Visible)
                    {
                        lblModuleHeader.Location = new Point(24, y);
                        y += 24;
                    }
                }
            }

            pnlContent.ResumeLayout();
        }

        private void UpdateCountLabel()
        {
            lblCount.Text = $"Selected: {_selectedKeys.Count} of {PermissionCatalog.All.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _itemControls)
            {
                if (item.Visible)
                {
                    item.IsChecked = true;
                }
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _itemControls)
            {
                if (item.Visible)
                {
                    item.IsChecked = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _role.Permissions = _selectedKeys.ToList();
            DataStore.Instance.NotifyChanged();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);
            }
        }

        private void pnlRoleCard_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                var r = pnlRoleCard.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                e.Graphics.DrawRectangle(pen, r);
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlContent.Width, 0);
            }
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
            }
        }

        // Child custom control for each row
        private class PermissionItemControl : Panel
        {
            public PermissionDefinition Def { get; }
            public event EventHandler<bool>? CheckedChanged;

            private readonly CheckBox _chk;
            private bool _isHovered = false;

            [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
            public bool IsChecked
            {
                get => _chk.Checked;
                set => _chk.Checked = value;
            }

            public PermissionItemControl(PermissionDefinition def, bool isChecked)
            {
                Def = def;
                Height = 56;
                BackColor = Color.White;
                Cursor = Cursors.Hand;

                _chk = new CheckBox
                {
                    Checked = isChecked,
                    AutoSize = false,
                    Size = new Size(24, 24),
                    Location = new Point(556, 16),
                    Cursor = Cursors.Hand
                };
                _chk.CheckedChanged += (s, e) =>
                {
                    CheckedChanged?.Invoke(this, _chk.Checked);
                    Invalidate();
                };
                Controls.Add(_chk);

                this.Click += (s, e) => { _chk.Checked = !_chk.Checked; };
                this.MouseEnter += (s, e) => { _isHovered = true; Invalidate(); };
                this.MouseLeave += (s, e) => { _isHovered = false; Invalidate(); };
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (_isHovered)
                {
                    using (var b = new SolidBrush(Color.FromArgb(248, 250, 252)))
                    {
                        g.FillRectangle(b, ClientRectangle);
                    }
                }

                // Title
                using (var titleFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                {
                    g.DrawString(Def.Name, titleFont, brush, 12, 8);
                }

                // Key pill
                using (var keyFont = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (var keyBrush = new SolidBrush(Color.FromArgb(234, 88, 12)))
                {
                    int nameWidth = (int)g.MeasureString(Def.Name, new Font("Segoe UI", 9.5F, FontStyle.Bold)).Width;
                    g.DrawString($"({Def.Key})", keyFont, keyBrush, 16 + nameWidth, 9);
                }

                // Description
                using (var descFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (var descBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    g.DrawString(Def.Description, descFont, descBrush, 12, 30);
                }

                // Bottom separator
                using (var pen = new Pen(Color.FromArgb(241, 245, 249), 1))
                {
                    g.DrawLine(pen, 12, Height - 1, Width - 12, Height - 1);
                }
            }
        }
    }
}