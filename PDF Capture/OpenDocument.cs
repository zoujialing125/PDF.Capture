using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDF_Capture
{
    public partial class OpenDocument : Form
    {
        private List<Parameter> CurrentParameterList;
        private Solution CurrentSolution;
        private Parameter CurrentParameter;
        private Parameter TempParameter;
        private Boolean EnableTextChange;
        private Boolean ParameterChanged;
        private fm_main MainForm = null;
        public enum OpenMode { Insert, Edit }
        private OpenMode Mode;

        private OpenDocument() { }

        public OpenDocument(OpenMode Mode, Solution TempSolution, fm_main ParentForm)
        {
            InitializeComponent();
            MainForm = ParentForm;
            this.Mode = Mode;
            TempParameter = new Parameter();
            if (TempSolution == null)
            {
                this.CurrentSolution = new Solution();
            }
            else
            {
                this.CurrentSolution = TempSolution;
            }
            this.CurrentParameterList = this.CurrentSolution.Parameters;
        }

        private void OpenDocument_Load(object sender, EventArgs e)
        {
            EnableTextChange = true;
            ParameterChanged = false;
            txt_sortMatch.SelectedIndex = 0;
            txt_sortGroup.SelectedIndex = 0;
            GridRow_Change(this, null);
            txt_document.SelectAll();
            txt_document.Font = new Font("Consolas", 10);
            txt_document.SelectionLength = 0;
        }

        private void Parameters_Change(object sender, EventArgs e)
        {
            TempParameter.RegExp = txt_exp.Text;
            TempParameter.Display = txt_display.Text;
            TempParameter.IndexOfMatches = Convert.ToInt32(txt_match.Value);
            TempParameter.IndexOfGroups = Convert.ToInt32(txt_group.Value);
            TempParameter.SortOfGroups = txt_sortGroup.Text;
            TempParameter.SortOfMatches = txt_sortMatch.Text;

            if (TempParameter.RegExp == string.Empty || TempParameter.Display == string.Empty)
            {
                btn_addPara.Enabled = false;
                btn_savePara.Enabled = false;
            }
            else
            {
                if ((TempParameter.IndexOfMatches > -2 && TempParameter.SortOfMatches == string.Empty) 
                    || (TempParameter.IndexOfGroups > -2 && TempParameter.SortOfGroups == string.Empty))
                {
                    btn_addPara.Enabled = false;
                    btn_savePara.Enabled = false;
                }
                else
                {
                    if (txt_group.Value == -2)
                    {
                        //txt_sortGroup.Text = string.Empty;
                        txt_sortGroup.Enabled = false;
                    }
                    else
                    {
                        txt_sortGroup.Enabled = true;
                    }
                    btn_addPara.Enabled = true;
                    btn_savePara.Enabled = true;
                }
            }

            if (txt_solutionName.Text == string.Empty)
            {
                btn_saveSolution.Enabled = false;
            }
            else
            {
                btn_saveSolution.Enabled = true;
            }

            if (EnableTextChange)
            {
                if (TempParameter.RegExp != string.Empty)
                {
                    ShowRegexResult();
                }
            }
        }

        private void GridRow_Change(object sender, DataGridViewCellEventArgs e)
        {
            EnableTextChange = false;
            if (grid_parameters.Rows.Count > 0)
            {
                int SelectedParaID = Convert.ToInt32(grid_parameters.SelectedRows[0].Cells[0].Value);
                if ((CurrentParameter == null) || (SelectedParaID != CurrentParameter.ID))
                {
                    CurrentParameter = CurrentParameterList.Where(r => r.ID == SelectedParaID).ToList()[0];
                }
                txt_exp.Text = CurrentParameter.RegExp.ToString();
                txt_display.Text = CurrentParameter.Display.ToString();
                txt_match.Value = CurrentParameter.IndexOfMatches;
                txt_group.Value = CurrentParameter.IndexOfGroups;
                txt_sortMatch.Text = CurrentParameter.SortOfMatches;
                txt_sortGroup.Text = CurrentParameter.SortOfGroups;

                //Get regmatches
                ShowRegexResult();
            }
            else
            {
                txt_exp.Text = string.Empty;
                txt_display.Text = string.Empty;
                txt_match.Value = -1;
                txt_group.Value = -1;
                txt_sortMatch.Text = string.Empty;
                txt_sortGroup.Text = string.Empty;
                btn_addPara.Enabled = false;
                btn_savePara.Enabled = false;
            }

            EnableTextChange = true;
        }

        private void FormSize_Changed(object sender, EventArgs e)
        {
            //int w = panel1.Width - 25;
            //foreach(Control control in panel1.Controls)
            //{
            //    if(control is TextBox || control is NumericUpDown)
            //    {
            //        control.Width = w;
            //    }
            //}

            //btn_saveSolution.Location = new Point(panel1.Width / 2 - btn_saveSolution.Width / 2, btn_saveSolution.Location.Y);
            //panel2.Location = new Point(panel1.Width / 2 - panel2.Width / 2, panel2.Location.Y);
        }

        private void btn_saveSolution_Click(object sender, EventArgs e)
        {
            if (txt_solutionName.Text == string.Empty)
            {
                MessageBox.Show("Solution Name must be input!", "Save Solution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (ParameterChanged)
                {
                    this.SaveSolution();
                    ParameterChanged = false;
                    this.Close();
                    MessageBox.Show("Saved successfully, form will be closed!", "Save Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nothing changed to save!", "Save Solution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_addPara_Click(object sender, EventArgs e)
        {
            if (TempParameter != null)
            {
                if (CurrentParameterList.Count() > 0)
                {
                    TempParameter.ID = CurrentParameterList.Max(r => r.ID) + 1;
                    TempParameter.Solution_id = CurrentParameterList.Max(r => r.Solution_id);
                }
                else
                {
                    TempParameter.ID = 1;
                    if (MainForm.sList.Count() > 0)
                    {
                        TempParameter.Solution_id = Convert.ToInt32(MainForm.sList.Max(r => r.Solution_id)) + 1;
                    }
                    else
                    {
                        TempParameter.Solution_id = 0;
                    }
                }
                
                CurrentParameterList.Add(new Parameter
                {
                    ID = TempParameter.ID,
                    Solution_id = TempParameter.Solution_id,
                    RegExp = TempParameter.RegExp,
                    Display = TempParameter.Display,
                    SortOfGroups = TempParameter.SortOfGroups,
                    SortOfMatches = TempParameter.SortOfMatches,
                    IndexOfGroups = TempParameter.IndexOfGroups,
                    IndexOfMatches = TempParameter.IndexOfMatches
                });
                ParameterChanged = true;
                grid_parameters.DataSource = null;
                grid_parameters.Update();
                grid_parameters.Refresh();
                grid_parameters.DataSource = CurrentParameterList;
                GridRow_Change(this, null);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (CurrentParameter == null)
            {
                MessageBox.Show("No selected parameter!", "Delete Parameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //CurrentParameterList.RemoveAll(r => r.ID == CurrentParameter.ID);
                if (CurrentParameterList.Remove(CurrentParameter))
                {
                    int id = CurrentParameter.ID;
                    ParameterChanged = true;
                    grid_parameters.DataSource = null;
                    grid_parameters.Update();
                    grid_parameters.Refresh();
                    grid_parameters.DataSource = CurrentParameterList;
                    GridRow_Change(this, null);
                    MessageBox.Show(string.Format("Parameter ID-[{0}] was deleted from the list!", id), "Delete Parameter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_savePara_Click(object sender, EventArgs e)
        {
            if (CurrentParameter != null)
            {
                CurrentParameter.Display = TempParameter.Display;
                CurrentParameter.IndexOfGroups = TempParameter.IndexOfGroups;
                CurrentParameter.IndexOfMatches = TempParameter.IndexOfMatches;
                CurrentParameter.RegExp = TempParameter.RegExp;
                CurrentParameter.SortOfGroups = TempParameter.SortOfGroups;
                CurrentParameter.SortOfMatches = TempParameter.SortOfMatches;

                ParameterChanged = true;
                grid_parameters.DataSource = null;
                grid_parameters.Update();
                grid_parameters.Refresh();
                grid_parameters.DataSource = CurrentParameterList;
                MessageBox.Show(string.Format("Parameter ID-[{0}] was updated!", CurrentParameter.ID), "Delete Parameter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenDocument_BeforeClose(object sender, FormClosingEventArgs e)
        {
            if (ParameterChanged)
            {
                DialogResult selection = MessageBox.Show("Somethings have been changed, please selecte if to save before closing:",
                                                            "Close On Save",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                if (selection == DialogResult.Yes)
                {
                    SaveSolution();
                }
            }
        }

        private void SaveSolution()
        {
            DataTable tbSolution = MainForm.ds.Tables[0];
            DataTable tbParameter = MainForm.ds.Tables[1];
            if (CurrentSolution != null && CurrentParameterList != null)
            {
                if(Mode == OpenMode.Edit)
                {
                    for (int i = tbSolution.Rows.Count - 1; i >= 0; i--)
                    {
                        if (tbSolution.Rows[i]["id"].ToString() == CurrentSolution.ID.ToString())
                        {
                            tbSolution.Rows[i].Delete();
                        }
                    }

                    for (int i = tbParameter.Rows.Count - 1; i >= 0; i--)
                    {
                        if (tbParameter.Rows[i]["Solution_id"].ToString() == CurrentSolution.Solution_id.ToString())
                        {
                            tbParameter.Rows[i].Delete();
                        }
                    }
                }

                DataRow row = tbSolution.NewRow();
                row["Solution_id"] = CurrentParameter.Solution_id;
                row["name"] = txt_solutionName.Text;
                row["desc"] = txt_solutionDesc.Text;
                row["createdOn"] = DateTime.Now.ToString();
                if (Mode == OpenMode.Insert)
                {
                    row["createdBy"] = MainForm.userName;
                    row["id"] = Convert.ToInt32(MainForm.sList.Max(r => r.ID)) + 1;
                }
                else
                {
                    row["createdBy"] = CurrentSolution.CreatedBy;
                    row["id"] = CurrentSolution.ID;
                }

                tbSolution.Rows.Add(row);
                tbSolution.AcceptChanges();

                foreach (Parameter pr in CurrentParameterList)
                {
                    DataRow drPara = tbParameter.NewRow();

                    drPara["id"] = pr.ID;
                    drPara["Solution_id"] = pr.Solution_id;
                    drPara["RegExp"] = pr.RegExp;
                    drPara["Display"] = pr.Display;
                    drPara["IndexOfMatches"] = pr.IndexOfMatches.ToString();
                    drPara["IndexOfGroups"] = pr.IndexOfGroups.ToString();
                    drPara["SortOfMatches"] = pr.SortOfMatches;
                    drPara["SortOfGroups"] = pr.SortOfGroups;

                    tbParameter.Rows.Add(drPara);
                }
                tbParameter.AcceptChanges();
            }

            FileStream xmlWriter = new FileStream(MainForm.xmlPath, FileMode.Create, FileAccess.Write);
            MainForm.ds.WriteXml(xmlWriter);
            xmlWriter.Close();
            MainForm.dataGridView1.DataSource = null;
            MainForm.dataGridView1.Update();
            MainForm.dataGridView1.Refresh();
            MainForm.ds.Dispose();
            MainForm.LoadSolutions();
        }

        private void txt_solutionName_TextChanged(object sender, EventArgs e)
        {
            if (txt_solutionName.Text == string.Empty)
            {
                btn_saveSolution.Enabled = false;
            }
            else
            {
                btn_saveSolution.Enabled = true;
            }
        }

        private void ShowRegexResult()
        {
            //Get regmatches
            List<MatchElement> result = RegMatch.MatchesList(
                                                txt_document.Text.ToString(),
                                                txt_exp.Text.ToString(),
                                                txt_sortMatch.Text,
                                                Convert.ToInt32(txt_match.Value),
                                                txt_sortGroup.Text,
                                                Convert.ToInt32(txt_group.Value));

            txt_result.Text = RegMatch.ShowMatchCases(result, txt_document);

        }

        private void btn_runSolution_Click(object sender, EventArgs e)
        {
            if (CurrentSolution != null)
            {
                CapturedList formCaptureList = new CapturedList(MainForm, MainForm.ReadPdfFile(true));
                formCaptureList.ShowDialog(MainForm);
            }
        }

        private bool txt_result_busy = false;
        private void txt_result_Changed(object sender, EventArgs e)
        {
            if (txt_result_busy) return;
            txt_result_busy = true;
            TextBox tb = sender as TextBox;
            Size tS = TextRenderer.MeasureText(tb.Text, tb.Font);
            bool Hsb = tb.ClientSize.Height < tS.Height + Convert.ToInt32(tb.Font.Size);
            bool Vsb = tb.ClientSize.Width < tS.Width;

            if (Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Both;
            else if (!Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.None;
            else if (Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.Vertical;
            else if (!Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Horizontal;

            sender = tb as object;
            txt_result_busy = false;
        }

        private void txt_match_KeyUp(object sender, KeyEventArgs e)
        {
            Parameters_Change(sender, null);
        }

    }
}
