using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ELMS.Common
{
    public static class CsvExporter
    {
        public static bool ExportGridToCsv(DataGridView grid, string defaultFileName)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (Comma Delimited)|*.csv";
                sfd.FileName = defaultFileName;
                if (sfd.ShowDialog() != DialogResult.OK) return false;

                var sb = new StringBuilder();

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewButtonColumn))
                    {
                        sb.Append("\"" + grid.Columns[i].HeaderText.Replace("\"", "\"\"") + "\",");
                    }
                }
                if (sb.Length > 0 && sb[sb.Length - 1] == ',') sb.Length--;
                sb.AppendLine();

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;
                    var rowSb = new StringBuilder();
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible && !(grid.Columns[i] is DataGridViewButtonColumn))
                        {
                            string val = row.Cells[i].Value?.ToString() ?? "";
                            rowSb.Append("\"" + val.Replace("\"", "\"\"") + "\",");
                        }
                    }
                    if (rowSb.Length > 0 && rowSb[rowSb.Length - 1] == ',') rowSb.Length--;
                    sb.AppendLine(rowSb.ToString());
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show($"File exported successfully to:\n{sfd.FileName}", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
    }
}
