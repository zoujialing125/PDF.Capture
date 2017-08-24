using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PDF_Capture
{
    #region Solution and its parameters proeperties definition
    [Serializable]
    public class Solution
    {
        public Solution()
        {
            this.Parameters = new List<Parameter>();
        }
        
        public Solution Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as Solution;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [Browsable(false)]
        public int Solution_id { get; set; }
        [Browsable(false)]
        public virtual List<Parameter> Parameters { get; set; }
    }

    [Serializable]
    public class Parameter
    {
        public Parameter Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as Parameter;
        }

        public int ID { get; set; }
        public string RegExp { get; set; }
        public string Display { get; set; }
        [Browsable(false)]
        public int Solution_id { get; set; }
        public string SortOfMatches { get; set; }
        public int IndexOfMatches { get; set; }
        public string SortOfGroups { get; set; }
        public int IndexOfGroups { get; set; }
        [Browsable(false)]
        public virtual List<MatchElement> Matches { get; set; }
    }
    #endregion

    #region Method about Solutions in fm_main
    public partial class fm_main
    {
        public string rootPath = AppDomain.CurrentDomain.BaseDirectory; //System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        public string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();
        public Solution TempSolution;
        public List<Parameter> pList = new List<Parameter>();
        public List<Solution> sList = new List<Solution>();
        public DataSet ds;
        public Solution CurrentSolution;
        public string xmlPath;

        //Load solutions
        public void LoadSolutions()
        {
            xmlPath = Path.Combine(rootPath, "Solutions.xml");
            if (File.Exists(xmlPath))
            {
                FileStream xmlStream = new FileStream(xmlPath, FileMode.Open);
                //StreamReader xmlStream = new StreamReader(xmlPath, System.Text.Encoding.UTF8);
                ds = new DataSet();
                ds.Clear();
                ds.ReadXml(xmlStream);
                xmlStream.Close();
                sList.Clear();
                pList.Clear();

                sList = ds.Tables[0].AsEnumerable().Select(r =>
                    new Solution
                    {
                        ID = int.Parse(r.Field<string>("id")),
                        Name = r.Field<string>("name"),
                        Description = r.Field<string>("desc"),
                        CreatedOn = r.Field<string>("createdOn"),
                        CreatedBy = r.Field<string>("createdBy"),
                        Solution_id = r.Field<int>("Solution_id")
                    }).ToList();

                pList = ds.Tables[1].AsEnumerable().Select(r =>
                    new Parameter
                    {
                        ID = int.Parse(r.Field<string>("id")),
                        RegExp = r.Field<string>("RegExp"),
                        Display = r.Field<string>("Display"),
                        Solution_id = r.Field<int>("Solution_id"),
                        IndexOfMatches = int.Parse(r.Field<string>("IndexOfMatches")),
                        IndexOfGroups = int.Parse(r.Field<string>("IndexOfGroups")),
                        SortOfMatches = r.Field<string>("SortOfMatches"),
                        SortOfGroups = r.Field<string>("SortOfGroups")
                    }).ToList();

                foreach (var itemS in sList)
                {
                    itemS.Parameters = (from rows in pList
                                        where rows.Solution_id == itemS.Solution_id
                                        select rows
                                        ).ToList();
                    
                    //dataGridView1.Rows.Add(new string[] { itemS.ID.ToString(),
                    //                                        itemS.Name,
                    //                                        itemS.Description,
                    //                                        itemS.CreatedOn,
                    //                                        itemS.CreatedBy });
                }

                dataGridView1.DataSource = sList;
                SolutionRow_Changed(this, null);
            }
        }

        //Edit specific solution
        public void EditSolution(string pdfSimpleText)
        {
            OpenDocument fm_Document = new OpenDocument(OpenDocument.OpenMode.Edit, CurrentSolution.Clone(), this);

            fm_Document.txt_document.Text = pdfSimpleText;
            fm_Document.Text = "Edit Solution";
            fm_Document.grid_parameters.DataSource = CurrentSolution.Parameters;
            //fm_Document.CurrentSolution = CurrentSolution.Clone();
            //fm_Document.CurrentParameterList = fm_Document.CurrentSolution.Parameters;
            fm_Document.txt_solutionName.Text = CurrentSolution.Name;
            fm_Document.txt_solutionDesc.Text = CurrentSolution.Description;
            fm_Document.ShowDialog(this);
        }

        //Delete specific solution
        public void DeleteSolution()
        {
            DataTable tbSolution = ds.Tables[0];
            DataTable tbParameter = ds.Tables[1];
            if (tbSolution.Rows.Count == 1)
            {
                MessageBox.Show("Cannot delete sample solution!", "Delete Solution");
            }
            else
            {
                if (CurrentSolution != null)
                {
                    for (int i = tbSolution.Rows.Count - 1; i >= 0; i--)
                    {
                        if (tbSolution.Rows[i]["id"].ToString() == CurrentSolution.ID.ToString())
                        {
                            tbSolution.Rows[i].Delete();
                        }
                    }
                    tbSolution.AcceptChanges();

                    for (int i = tbParameter.Rows.Count - 1; i >= 0; i--)
                    {
                        if (tbParameter.Rows[i]["Solution_id"].ToString() == CurrentSolution.Solution_id.ToString())
                        {
                            tbParameter.Rows[i].Delete();
                        }
                    }
                    tbParameter.AcceptChanges();
                }

                FileStream xmlWriter = new FileStream(xmlPath, FileMode.Create, FileAccess.Write);
                ds.WriteXml(xmlWriter);
                xmlWriter.Close();
                dataGridView1.DataSource = null;
                dataGridView1.Update();
                dataGridView1.Refresh();
                LoadSolutions();
            }
            
        }

        //Open dialog to edit new solution
        public void InsertSolution(string pdfSimpleText)
        {
            OpenDocument fm_Document = new OpenDocument(OpenDocument.OpenMode.Insert, null, this);
            fm_Document.txt_document.Text = pdfSimpleText;
            fm_Document.Text = "New Solution";
            fm_Document.grid_parameters.DataSource = null;
            fm_Document.ShowDialog(this);
        }
    }
    #endregion
}
