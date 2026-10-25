using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ELMS.Common
{
    public static class ReportExporter
    {
        public static bool ExportToExcel(DataGridView grid, string defaultFileName, bool checkedOnly)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Spreadsheet (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = defaultFileName;
                if (sfd.ShowDialog() != DialogResult.OK) return false;

                var sb = new StringBuilder();

                // UTF-8 BOM so Excel opens it with proper character encoding
                sb.Append("\uFEFF");

                // Headers
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewCheckBoxColumn) && !(grid.Columns[i] is DataGridViewButtonColumn))
                    {
                        sb.Append("\"" + (grid.Columns[i].HeaderText ?? "").Replace("\"", "\"\"") + "\",");
                    }
                }
                if (sb.Length > 1 && sb[sb.Length - 1] == ',') sb.Length--;
                sb.AppendLine();

                // Rows
                int exportedCount = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (checkedOnly)
                    {
                        bool isChecked = row.Cells["colSelect"]?.Value is true;
                        if (!isChecked) continue;
                    }

                    var rowSb = new StringBuilder();
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewCheckBoxColumn) && !(grid.Columns[i] is DataGridViewButtonColumn))
                        {
                            string val = row.Cells[i].Value?.ToString() ?? "";
                            rowSb.Append("\"" + val.Replace("\"", "\"\"") + "\",");
                        }
                    }
                    if (rowSb.Length > 0 && rowSb[rowSb.Length - 1] == ',') rowSb.Length--;
                    sb.AppendLine(rowSb.ToString());
                    exportedCount++;
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show(
                    $"Report successfully exported to Excel!\n\nLocation: {sfd.FileName}\nRows Exported: {exportedCount}",
                    "Export Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                try
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
                catch { }

                return true;
            }
        }

        public static bool ExportToPdfHtml(
            DataGridView grid,
            string reportTitle,
            string defaultFileName,
            bool checkedOnly,
            string filterSummary,
            int totalStaff,
            int totalAllocated,
            int totalUsed,
            int totalBalance,
            double avgUtilization)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Document / Printable Report (*.html)|*.html|All Files (*.*)|*.*";
                sfd.FileName = defaultFileName;
                if (sfd.ShowDialog() != DialogResult.OK) return false;

                var sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html lang=\"en\">");
                sb.AppendLine("<head>");
                sb.AppendLine("  <meta charset=\"UTF-8\" />");
                sb.AppendLine("  <title>" + reportTitle + "</title>");
                sb.AppendLine("  <style>");
                sb.AppendLine("    @media print {");
                sb.AppendLine("      body { margin: 0; padding: 10mm; font-size: 11px; }");
                sb.AppendLine("      .no-print { display: none !important; }");
                sb.AppendLine("      .page-break { page-break-after: always; }");
                sb.AppendLine("    }");
                sb.AppendLine("    body {");
                sb.AppendLine("      font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;");
                sb.AppendLine("      background-color: #f8fafc;");
                sb.AppendLine("      color: #0f172a;");
                sb.AppendLine("      margin: 0;");
                sb.AppendLine("      padding: 30px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .container {");
                sb.AppendLine("      max-width: 1200px;");
                sb.AppendLine("      margin: 0 auto;");
                sb.AppendLine("      background: #ffffff;");
                sb.AppendLine("      padding: 32px;");
                sb.AppendLine("      border-radius: 12px;");
                sb.AppendLine("      box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.05), 0 2px 4px -2px rgba(0, 0, 0, 0.05);");
                sb.AppendLine("      border: 1px solid #e2e8f0;");
                sb.AppendLine("    }");
                sb.AppendLine("    .header {");
                sb.AppendLine("      display: flex;");
                sb.AppendLine("      justify-content: space-between;");
                sb.AppendLine("      align-items: flex-start;");
                sb.AppendLine("      border-bottom: 2px solid #ea580c;");
                sb.AppendLine("      padding-bottom: 20px;");
                sb.AppendLine("      margin-bottom: 24px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .brand-title {");
                sb.AppendLine("      font-size: 24px;");
                sb.AppendLine("      font-weight: 700;");
                sb.AppendLine("      color: #ea580c;");
                sb.AppendLine("      margin: 0 0 6px 0;");
                sb.AppendLine("    }");
                sb.AppendLine("    .sub-title {");
                sb.AppendLine("      font-size: 14px;");
                sb.AppendLine("      color: #64748b;");
                sb.AppendLine("      margin: 0;");
                sb.AppendLine("    }");
                sb.AppendLine("    .meta-box {");
                sb.AppendLine("      text-align: right;");
                sb.AppendLine("      font-size: 12px;");
                sb.AppendLine("      color: #475569;");
                sb.AppendLine("      line-height: 1.6;");
                sb.AppendLine("    }");
                sb.AppendLine("    .kpi-row {");
                sb.AppendLine("      display: grid;");
                sb.AppendLine("      grid-template-columns: repeat(5, 1fr);");
                sb.AppendLine("      gap: 16px;");
                sb.AppendLine("      margin-bottom: 24px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .kpi-card {");
                sb.AppendLine("      background: #f8fafc;");
                sb.AppendLine("      border: 1px solid #e2e8f0;");
                sb.AppendLine("      border-radius: 8px;");
                sb.AppendLine("      padding: 14px 16px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .kpi-card .label {");
                sb.AppendLine("      font-size: 11px;");
                sb.AppendLine("      font-weight: 600;");
                sb.AppendLine("      text-transform: uppercase;");
                sb.AppendLine("      letter-spacing: 0.05em;");
                sb.AppendLine("      color: #64748b;");
                sb.AppendLine("      margin-bottom: 4px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .kpi-card .value {");
                sb.AppendLine("      font-size: 20px;");
                sb.AppendLine("      font-weight: 700;");
                sb.AppendLine("      color: #0f172a;");
                sb.AppendLine("    }");
                sb.AppendLine("    .filter-summary {");
                sb.AppendLine("      background: #fff7ed;");
                sb.AppendLine("      border: 1px solid #fed7aa;");
                sb.AppendLine("      border-radius: 6px;");
                sb.AppendLine("      padding: 10px 14px;");
                sb.AppendLine("      font-size: 12px;");
                sb.AppendLine("      color: #9a3412;");
                sb.AppendLine("      margin-bottom: 20px;");
                sb.AppendLine("      display: flex;");
                sb.AppendLine("      justify-content: space-between;");
                sb.AppendLine("      align-items: center;");
                sb.AppendLine("    }");
                sb.AppendLine("    table {");
                sb.AppendLine("      width: 100%;");
                sb.AppendLine("      border-collapse: collapse;");
                sb.AppendLine("      font-size: 12px;");
                sb.AppendLine("      margin-top: 10px;");
                sb.AppendLine("    }");
                sb.AppendLine("    th {");
                sb.AppendLine("      background-color: #f1f5f9;");
                sb.AppendLine("      color: #334155;");
                sb.AppendLine("      font-weight: 600;");
                sb.AppendLine("      text-align: left;");
                sb.AppendLine("      padding: 10px 12px;");
                sb.AppendLine("      border-bottom: 2px solid #cbd5e1;");
                sb.AppendLine("    }");
                sb.AppendLine("    td {");
                sb.AppendLine("      padding: 9px 12px;");
                sb.AppendLine("      border-bottom: 1px solid #e2e8f0;");
                sb.AppendLine("      color: #1e293b;");
                sb.AppendLine("    }");
                sb.AppendLine("    tr:nth-child(even) { background-color: #fafbfc; }");
                sb.AppendLine("    tr:hover { background-color: #f8fafc; }");
                sb.AppendLine("    .text-right { text-align: right; }");
                sb.AppendLine("    .badge {");
                sb.AppendLine("      display: inline-block;");
                sb.AppendLine("      padding: 2px 8px;");
                sb.AppendLine("      border-radius: 9999px;");
                sb.AppendLine("      font-size: 11px;");
                sb.AppendLine("      font-weight: 600;");
                sb.AppendLine("    }");
                sb.AppendLine("    .badge-util { background: #ede9fe; color: #6d28d9; }");
                sb.AppendLine("    .badge-bal { background: #dcfce7; color: #15803d; }");
                sb.AppendLine("    .footer {");
                sb.AppendLine("      margin-top: 32px;");
                sb.AppendLine("      border-top: 1px solid #e2e8f0;");
                sb.AppendLine("      padding-top: 16px;");
                sb.AppendLine("      display: flex;");
                sb.AppendLine("      justify-content: space-between;");
                sb.AppendLine("      font-size: 11px;");
                sb.AppendLine("      color: #94a3b8;");
                sb.AppendLine("    }");
                sb.AppendLine("    .actions-bar {");
                sb.AppendLine("      margin-bottom: 20px;");
                sb.AppendLine("      display: flex;");
                sb.AppendLine("      gap: 12px;");
                sb.AppendLine("    }");
                sb.AppendLine("    .btn {");
                sb.AppendLine("      background: #ea580c;");
                sb.AppendLine("      color: white;");
                sb.AppendLine("      border: none;");
                sb.AppendLine("      padding: 8px 16px;");
                sb.AppendLine("      border-radius: 6px;");
                sb.AppendLine("      font-weight: 600;");
                sb.AppendLine("      cursor: pointer;");
                sb.AppendLine("    }");
                sb.AppendLine("    .btn:hover { background: #c2410c; }");
                sb.AppendLine("  </style>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");
                sb.AppendLine("  <div class=\"actions-bar no-print\">");
                sb.AppendLine("    <button class=\"btn\" onclick=\"window.print()\">🖨️ Print to PDF / Paper</button>");
                sb.AppendLine("  </div>");
                sb.AppendLine("  <div class=\"container\">");
                sb.AppendLine("    <div class=\"header\">");
                sb.AppendLine("      <div>");
                sb.AppendLine("        <h1 class=\"brand-title\">ELMS Enterprise HRMS</h1>");
                sb.AppendLine("        <div class=\"sub-title\">" + reportTitle + "</div>");
                sb.AppendLine("      </div>");
                sb.AppendLine("      <div class=\"meta-box\">");
                sb.AppendLine("        <div><strong>Generated:</strong> " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</div>");
                sb.AppendLine("        <div><strong>Export Scope:</strong> " + (checkedOnly ? "Checked Employees Only" : "All Filtered Records") + "</div>");
                sb.AppendLine("        <div><strong>Fiscal Year:</strong> 2026 Regular Cycle</div>");
                sb.AppendLine("      </div>");
                sb.AppendLine("    </div>");

                // Filter banner
                sb.AppendLine("    <div class=\"filter-summary\">");
                sb.AppendLine("      <div><strong>Active Filters:</strong> " + filterSummary + "</div>");
                sb.AppendLine("      <div><strong>Scope:</strong> " + (checkedOnly ? "Selected Employees Target" : "Full Organization") + "</div>");
                sb.AppendLine("    </div>");

                // KPI Cards
                sb.AppendLine("    <div class=\"kpi-row\">");
                sb.AppendLine("      <div class=\"kpi-card\"><div class=\"label\">Staff Reported</div><div class=\"value\">" + totalStaff + "</div></div>");
                sb.AppendLine("      <div class=\"kpi-card\"><div class=\"label\">Total Quota</div><div class=\"value\">" + totalAllocated + "d</div></div>");
                sb.AppendLine("      <div class=\"kpi-card\"><div class=\"label\">Days Taken</div><div class=\"value\">" + totalUsed + "d</div></div>");
                sb.AppendLine("      <div class=\"kpi-card\"><div class=\"label\">Balance Available</div><div class=\"value\">" + totalBalance + "d</div></div>");
                sb.AppendLine("      <div class=\"kpi-card\"><div class=\"label\">Avg Utilization</div><div class=\"value\">" + avgUtilization.ToString("0.0") + "%</div></div>");
                sb.AppendLine("    </div>");

                // Table
                sb.AppendLine("    <table>");
                sb.AppendLine("      <thead>");
                sb.AppendLine("        <tr>");
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewCheckBoxColumn) && !(grid.Columns[i] is DataGridViewButtonColumn))
                    {
                        string header = grid.Columns[i].HeaderText ?? "";
                        bool isNumeric = header.Contains("Quota") || header.Contains("Days") || header.Contains("Taken") || header.Contains("Used") || header.Contains("Balance") || header.Contains("%") || header.Contains("Base") || header.Contains("Carry") || header.Contains("Bonus") || header.Contains("Total");
                        sb.AppendLine("          <th" + (isNumeric ? " class=\"text-right\"" : "") + ">" + header + "</th>");
                    }
                }
                sb.AppendLine("        </tr>");
                sb.AppendLine("      </thead>");
                sb.AppendLine("      <tbody>");

                int rowCount = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (checkedOnly)
                    {
                        bool isChecked = row.Cells["colSelect"]?.Value is true;
                        if (!isChecked) continue;
                    }

                    sb.AppendLine("        <tr>");
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewCheckBoxColumn) && !(grid.Columns[i] is DataGridViewButtonColumn))
                        {
                            string val = row.Cells[i].Value?.ToString() ?? "";
                            string header = grid.Columns[i].HeaderText ?? "";
                            bool isNumeric = header.Contains("Quota") || header.Contains("Days") || header.Contains("Taken") || header.Contains("Used") || header.Contains("Balance") || header.Contains("%") || header.Contains("Base") || header.Contains("Carry") || header.Contains("Bonus") || header.Contains("Total");

                            if (header.Contains("%"))
                            {
                                sb.AppendLine("          <td class=\"text-right\"><span class=\"badge badge-util\">" + val + "</span></td>");
                            }
                            else if (header.Contains("Balance"))
                            {
                                sb.AppendLine("          <td class=\"text-right\"><span class=\"badge badge-bal\">" + val + "</span></td>");
                            }
                            else if (isNumeric)
                            {
                                sb.AppendLine("          <td class=\"text-right\">" + val + "</td>");
                            }
                            else
                            {
                                sb.AppendLine("          <td>" + val + "</td>");
                            }
                        }
                    }
                    sb.AppendLine("        </tr>");
                    rowCount++;
                }

                sb.AppendLine("      </tbody>");
                sb.AppendLine("    </table>");

                // Footer
                sb.AppendLine("    <div class=\"footer\">");
                sb.AppendLine("      <div>ELMS Human Resource Management System • Confidential & Proprietary</div>");
                sb.AppendLine("      <div>Total Records: " + rowCount + " • Generated by " + Environment.UserName + "</div>");
                sb.AppendLine("    </div>");
                sb.AppendLine("  </div>");
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show(
                    $"Printable PDF/HTML Report successfully generated!\n\nLocation: {sfd.FileName}\nRows Exported: {rowCount}\n\nThe report has been opened in your default browser where you can save it as PDF (Ctrl+P -> Save as PDF).",
                    "Report Generated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                try
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
                catch { }

                return true;
            }
        }
    }
}