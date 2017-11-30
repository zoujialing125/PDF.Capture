using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDF_Capture
{
    public partial class CapturedList : Form
    {
        private DataTable dtResult;
        private string[][] pdfTxtArray;
        private fm_main mainForm;
        private CapturedList() { }
        public CapturedList(fm_main MainForm, string[][] PDFTxtArray)
        {
            mainForm = MainForm;
            pdfTxtArray = PDFTxtArray;
            InitializeComponent();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            if(fb.ShowDialog() == DialogResult.OK)
            {
                DataTableExtension.ExportToExcel(dtResult, fb.SelectedPath + "\\" + mainForm.CurrentSolution.Name + ".xlsx");
            }
        }

        private void CapturedList_Load(object sender, EventArgs e)
        {
            dtResult = new DataTable();
            List<Parameter> paras = mainForm.CurrentSolution.Parameters;
            string[] columnNames = new string[paras.Count() + 1];

            //Create Columns
            dtResult.Columns.Add("File Names");
            columnNames[0] = "File Names";
            int c = 0;
            foreach (Parameter p in paras)
            {
                int nameSuffix = 0;
                c++;
                if (dtResult.Columns.Contains(p.Display))
                {
                    nameSuffix++;
                    dtResult.Columns.Add(p.Display + nameSuffix.ToString());
                    columnNames[c] = p.Display + nameSuffix.ToString();
                }
                else
                {
                    dtResult.Columns.Add(p.Display);
                    columnNames[c] = p.Display;
                }
                 
            }

            //Get datarows into datatable
            int indexDtRow = -1;
            foreach (string[] s in pdfTxtArray)
            {
                //Get matches into parameter
                int addRows = 0;
                foreach (Parameter p in paras)
                {
                    List<MatchElement> result = RegMatch.MatchesList(s[1], p.RegExp, p.SortOfMatches, p.IndexOfMatches, p.SortOfGroups, p.IndexOfGroups);
                    p.Matches = result;

                    if (p.Matches != null)
                    {
                        addRows = p.Matches.Count() > addRows ? p.Matches.Count() : addRows;
                        foreach (MatchElement m in p.Matches)
                        {
                            if (m.Groups != null)
                            {
                                addRows = m.Groups.Count() > addRows ? m.Groups.Count() : addRows;
                            }
                        }
                    }
                    else
                    {
                        List<MatchElement> blankMatch = new List<MatchElement>();
                        blankMatch.Add(new MatchElement { Index = -1, Value = "Null", Groups = null });
                        p.Matches = blankMatch;
                    }
                }

                if (addRows > 0)
                {
                    //Fill blank datarows into datatable
                    for (int i = 1; i <= addRows; i++)
                    {
                        DataRow dr = dtResult.NewRow();
                        dr[0] = s[0];
                        dtResult.Rows.Add(dr);
                    }

                    //Fill actual data into datatable per index
                    c = 0;
                    foreach (Parameter p in paras)
                    {
                        c++;
                        List<string> values = new List<string>();
                        foreach (MatchElement m in p.Matches)
                        {
                            if (m.Groups != null)
                            {
                                foreach(GroupElement g in m.Groups)
                                {
                                    values.Add(g.Value);
                                }
                            }
                            else
                            {
                                values.Add(m.Value);
                            }
                        }

                        for (int i = 1; i <= addRows; i++)
                        {
                            if (i <= values.Count())
                            {
                                dtResult.Rows[i + indexDtRow][columnNames[c]] = values[i - 1];
                            }
                        }
                    }

                    indexDtRow = indexDtRow + addRows;
                }
                
            }

            this.Text = "Captured - " + mainForm.CurrentSolution.Name;
            GridCapturedList.DataSource = dtResult;
            label_status.Text = string.Format("Total read {0} files, {1} columns and {2} rows were loaded...", pdfTxtArray.Count(), paras.Count(), GridCapturedList.Rows.Count - 1);
        }

        private void GridCapturedList_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
    }
}
