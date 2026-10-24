using System;
using System.Drawing;
using System.Windows.Forms;

namespace ELMS.Common
{
    public static class ElmsTheme
    {
        public static readonly Color Canvas = Color.FromArgb(248, 250, 252);     // #F8FAFC
        public static readonly Color Card = Color.FromArgb(255, 255, 255);       // #FFFFFF
        public static readonly Color Border = Color.FromArgb(226, 232, 240);      // #E2E8F0
        public static readonly Color InputBorder = Color.FromArgb(203, 213, 225); // #CBD5E1

        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);     // #0F172A
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139); // #64748B
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);     // #94A3B8

        public static readonly Color OrangePrimary = Color.FromArgb(234, 88, 12);  // #EA580C
        public static readonly Color OrangeHover = Color.FromArgb(194, 65, 12);    // #C2410C
        public static readonly Color OrangeActive = Color.FromArgb(154, 52, 18);   // #9A3412

        public static readonly Color Success = Color.FromArgb(22, 163, 74);       // #16A34A
        public static readonly Color Warning = Color.FromArgb(217, 119, 6);       // #D97706
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);        // #DC2626
        public static readonly Color Info = Color.FromArgb(37, 99, 235);          // #2563EB

        public static void ApplyPrimaryButton(Button btn)
        {
            btn.BackColor = OrangePrimary;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        }

        public static void ApplySecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(241, 245, 249);
            btn.ForeColor = TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Border;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9.5f);
        }

        public static void ApplyGridStyle(DataGridView grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.BackgroundColor = Canvas;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 42;
            grid.RowTemplate.Height = 40;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = TextSecondary,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Card,
                ForeColor = TextPrimary,
                Font = new Font("Segoe UI", 9f),
                SelectionBackColor = Color.FromArgb(254, 243, 199),
                SelectionForeColor = TextPrimary,
                Padding = new Padding(10, 0, 0, 0)
            };
        }
    }
}
