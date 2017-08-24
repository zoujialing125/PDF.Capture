using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDF_Capture
{
    public partial class fm_main : Form
    {
        public fm_main()
        {
            InitializeComponent();
        }

        public string[][] ReadPdfFile(Boolean MultiSelect = false)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Files(*.pdf)|*.pdf";
            fileDialog.Multiselect = MultiSelect;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //string fileName = fileDialog.FileName;
                string[][] textArray = new string[fileDialog.FileNames.Count()][];
                int i = -1;
                foreach (string fileName in fileDialog.FileNames)
                {
                    i++;
                    StringBuilder text = new StringBuilder();
                    if (File.Exists(fileName))
                    {
                        PdfReader pdfReader = new PdfReader(fileName);
                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                            currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                            text.Append(currentText);
                        }
                        pdfReader.Close();
                    }
                    textArray[i] = new string[] { System.IO.Path.GetFileNameWithoutExtension(fileName),
                                                      text.ToString()};
                }
                return textArray;
            }
            else
            {
                return new string[][] { new string[] { "", "" } };
            }
        }

        private void SolutionRow_Changed(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int SelectedSolutionID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if ((CurrentSolution == null) || (SelectedSolutionID != CurrentSolution.ID))
                {
                    CurrentSolution = sList.Where(r => r.ID == SelectedSolutionID).ToList()[0];
                }
                btn_modify.Enabled = true;
                btn_delete.Enabled = true;
                btn_run.Enabled = true;
            }
            else
            {
                btn_modify.Enabled = false;
                btn_delete.Enabled = false;
                btn_run.Enabled = false;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertSolution(ReadPdfFile()[0][1]);
        }

        private void main_load(object sender, EventArgs e)
        {
            LoadSolutions();
        }

        private void main_Close(object sender, EventArgs e)
        {

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if(CurrentSolution != null)
            {
                CapturedList formCaptureList = new CapturedList(this, ReadPdfFile(true));
                formCaptureList.ShowDialog(this);
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            EditSolution(ReadPdfFile()[0][1]);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            InsertSolution(ReadPdfFile()[0][1]);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteSolution();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutApp about = new AboutApp();
            about.ShowDialog(this);
        }

        private void importSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML Files(*.xml)|*.xml";
            fileDialog.Multiselect = false;
            fileDialog.RestoreDirectory = true;
            string usedFileName = System.IO.Path.Combine(rootPath, "Solutions.xml");
            string backupFileName = System.IO.Path.Combine(rootPath, "Solutions.xml.bak");
            string newFile;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                newFile = fileDialog.FileName;
                try
                {
                    if (!File.Exists(backupFileName))
                    {
                        File.Move(usedFileName, backupFileName);
                    }
                    if (File.Exists(usedFileName))
                    {
                        File.Delete(usedFileName);
                    }
                    File.Copy(newFile, usedFileName);
                    dataGridView1.DataSource = null;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    LoadSolutions();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        private void exportSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string usedFileName = System.IO.Path.Combine(rootPath, "Solutions.xml");
            SaveFileDialog saveFileAs = new SaveFileDialog();
            saveFileAs.AddExtension = true;
            saveFileAs.RestoreDirectory = true;
            saveFileAs.FileName = "Solutions.xml";
            saveFileAs.Filter = "XML Files(*.xml)|*.xml";
            if (saveFileAs.ShowDialog() == DialogResult.OK)
            {
                File.Copy(usedFileName, saveFileAs.FileName);
            }
        }
    }   
}
