using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ELMS.Common
{
    /// <summary>
    /// Shared Enterprise Data Table Pagination control matching HRMS design specifications.
    /// Provides record windowing, rows-per-page selection, page count indicators, and navigational buttons.
    /// </summary>
    public class DataTablePagination : UserControl
    {
        public event EventHandler? PageChanged;
        public event EventHandler? PageSizeChanged;

        private Label lblInfo = null!;
        private Label lblRowsPerPage = null!;
        private ComboBox cboPageSize = null!;
        private Label lblPageOf = null!;
        private Button btnFirst = null!;
        private Button btnPrev = null!;
        private Button btnNext = null!;
        private Button btnLast = null!;

        public int CurrentPage { get; private set; } = 1;
        public int PageSize { get; private set; } = 10;
        public int TotalItems { get; private set; } = 0;
        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)TotalItems / PageSize));

        private DataGridView? _boundGrid;

        public DataTablePagination()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Height = 46;
            Dock = DockStyle.Bottom;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9f);

            lblInfo = new Label
            {
                AutoSize = true,
                Location = new Point(16, 14),
                ForeColor = Color.FromArgb(100, 116, 139),
                Text = "Showing 0 to 0 of 0 entries"
            };

            lblRowsPerPage = new Label
            {
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 116, 139),
                Text = "Rows per page"
            };

            cboPageSize = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 55,
                FlatStyle = FlatStyle.Flat
            };
            cboPageSize.Items.AddRange(new object[] { "5", "10", "20", "50" });
            cboPageSize.SelectedItem = "10";
            cboPageSize.SelectedIndexChanged += (s, e) =>
            {
                if (int.TryParse(cboPageSize.SelectedItem?.ToString(), out int sz))
                {
                    PageSize = sz;
                    CurrentPage = 1;
                    if (_boundGrid != null) ApplyPagination(_boundGrid);
                    PageSizeChanged?.Invoke(this, EventArgs.Empty);
                }
            };

            lblPageOf = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Text = "Page 1 of 1"
            };

            btnFirst = CreatePageNavButton("⏮", () => SetPage(1));
            btnPrev = CreatePageNavButton("◀", () => SetPage(CurrentPage - 1));
            btnNext = CreatePageNavButton("▶", () => SetPage(CurrentPage + 1));
            btnLast = CreatePageNavButton("⏭", () => SetPage(TotalPages));

            Controls.AddRange(new Control[] { lblInfo, lblRowsPerPage, cboPageSize, lblPageOf, btnFirst, btnPrev, btnNext, btnLast });
            Resize += (s, e) => RepositionControls();
            RepositionControls();
        }

        private Button CreatePageNavButton(string text, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(30, 28),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85)
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
            btn.Click += (s, e) => onClick();
            return btn;
        }

        private void SetPage(int page)
        {
            if (page < 1) page = 1;
            if (page > TotalPages) page = TotalPages;
            if (page != CurrentPage)
            {
                CurrentPage = page;
                if (_boundGrid != null) ApplyPagination(_boundGrid);
                PageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ResetPage()
        {
            CurrentPage = 1;
        }

        public void ApplyPagination(DataGridView dgv)
        {
            _boundGrid = dgv;
            TotalItems = dgv.Rows.Count;
            if (CurrentPage > TotalPages) CurrentPage = TotalPages;
            if (CurrentPage < 1) CurrentPage = 1;

            int from = TotalItems > 0 ? (CurrentPage - 1) * PageSize : 0;
            int to = Math.Min(CurrentPage * PageSize, TotalItems);

            dgv.SuspendLayout();
            try
            {
                dgv.CurrentCell = null;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    bool isVisible = (i >= from && i < to);
                    if (dgv.Rows[i].Visible != isVisible)
                    {
                        dgv.Rows[i].Visible = isVisible;
                    }
                }
            }
            catch
            {
                // Fallback safety
            }
            finally
            {
                dgv.ResumeLayout();
            }

            int displayFrom = TotalItems > 0 ? from + 1 : 0;
            int selectedCount = 0;
            if (dgv.Columns.Contains("Select"))
            {
                selectedCount = dgv.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells["Select"].Value) == true);
            }

            string sel = selectedCount > 0 ? $" ({selectedCount} selected)" : "";
            lblInfo.Text = TotalItems > 0 ? $"Showing {displayFrom} to {to} of {TotalItems} entries{sel}" : "No entries found";
            lblPageOf.Text = $"Page {CurrentPage} of {TotalPages}";

            btnFirst.Enabled = CurrentPage > 1;
            btnPrev.Enabled = CurrentPage > 1;
            btnNext.Enabled = CurrentPage < TotalPages;
            btnLast.Enabled = CurrentPage < TotalPages;

            RepositionControls();
        }

        private void RepositionControls()
        {
            lblInfo.Location = new Point(16, 14);

            int right = ClientSize.Width - 16;

            btnLast.Location = new Point(right - btnLast.Width, 9);
            right = btnLast.Left - 4;

            btnNext.Location = new Point(right - btnNext.Width, 9);
            right = btnNext.Left - 4;

            btnPrev.Location = new Point(right - btnPrev.Width, 9);
            right = btnPrev.Left - 4;

            btnFirst.Location = new Point(right - btnFirst.Width, 9);
            right = btnFirst.Left - 16;

            lblPageOf.Location = new Point(right - lblPageOf.PreferredWidth, 14);
            right = lblPageOf.Left - 16;

            cboPageSize.Location = new Point(right - cboPageSize.Width, 11);
            right = cboPageSize.Left - 8;

            lblRowsPerPage.Location = new Point(right - lblRowsPerPage.PreferredWidth, 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, Width, 0);
            }
        }
    }
}
