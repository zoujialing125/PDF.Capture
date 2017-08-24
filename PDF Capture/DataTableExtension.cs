using System;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;

namespace PDF_Capture
{
    static class DataTableExtension
    {
        /// <summary>
        /// Export DataTable to Excel file
        /// </summary>
        /// <param name="DataTable">Source DataTable</param>
        /// <param name="ExcelFilePath">Path to result file name</param>
        public static void ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                excel.Application Excel = new excel.Application();
                excel.Workbook wb = Excel.Workbooks.Add();

                // single worksheet
                excel._Worksheet Worksheet = wb.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                {
                    Worksheet.Columns[i + 1].NumberFormat = "@";
                    Header[i] = DataTable.Columns[i].ColumnName;
                }

                excel.Range HeaderRange = Worksheet.get_Range((excel.Range)(Worksheet.Cells[1, 1]), (excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((excel.Range)(Worksheet.Cells[2, 1]),
                                    (excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value
                                    = Cells;
                Worksheet.Columns.AutoFit();

                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        if (System.IO.File.Exists(ExcelFilePath))
                        {
                            DialogResult dr = MessageBox.Show("Excel file already exists...\nIf need replace the file?",
                                    "Download File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                System.IO.File.Delete(ExcelFilePath);
                            }
                        }

                        wb.SaveAs(ExcelFilePath);

                        DialogResult m = MessageBox.Show("Excel file saved successfully...\nIf need open the file?",
                                    "Download File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (m == DialogResult.Yes)
                        {
                            Excel.Workbooks.Open(ExcelFilePath, false);
                            Excel.Visible = true;
                        }
                        else
                        {
                            //Release COM objects
                            wb.Close();
                            Excel.Quit();
                            ReleaseObject(HeaderRange);
                            ReleaseObject(Worksheet);
                            ReleaseObject(wb);
                            ReleaseObject(Excel);
                        }

                    }
                    catch (Exception ex)
                    {
                        //throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        //    + ex.Message);
                        MessageBox.Show("ExportToExcel: Excel file could not be saved! Check filepath.\n" +
                            ex.Message, "Export Error");
                    }
                }
                else    // no filepath is given
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("ExportToExcel: \n" + ex.Message);
                MessageBox.Show(ex.Message, "Export Error");
            }
        }

        private static void ReleaseObject(object o)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o) > 0)
                {

                }
            }
            catch
            {

            }
            finally
            {
                o = null;
            }
        }
    }
}
