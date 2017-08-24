using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace PDF_Capture
{
    [Serializable]
    public class MatchElement
    {
        public string Value { get; set; }
        public int Index { get; set; }
        public List<GroupElement> Groups { get; set; }
    }

    [Serializable]
    public class GroupElement
    {
        public string Value { get; set; }
        public int Index { get; set; }
    }

    public static class RegMatch
    {
        public static List<MatchElement> MatchesList(string input, string pattern)
        {
            if ((pattern.Length > 0) && (input.Length > 0))
            {
                if (pattern.Substring(pattern.Length - 1) == @"\")
                {
                    pattern = pattern.Substring(0, pattern.Length - 1);
                }

                //Regex regex = new Regex(pattern, RegexOptions.None);
                try
                {
                    MatchCollection matches = Regex.Matches(input, pattern);
                    if (matches.Count > 0)
                    {
                        List<MatchElement> matchList = new List<MatchElement>();
                        foreach (Match match in matches)
                        {
                            MatchElement mt = new MatchElement()
                            {
                                Index = match.Index,
                                Value = match.Value,
                                Groups = new List<GroupElement>()
                            };

                            //The first group index 0 is equal to match
                            //mt.Groups = match.Groups.Cast<Group>().Select(group =>
                            //        new GroupElement
                            //        {
                            //            Index = group.Index,
                            //            Value = group.Value
                            //        }).ToList();

                            //Start capture group from index 1
                            if (match.Groups.Count > 1)
                            {
                                for (int i = 1; i <= match.Groups.Count - 1; i++)
                                {
                                    var g = match.Groups[i];
                                    mt.Groups.Add(new GroupElement { Index = g.Index, Value = g.Value });
                                }
                            }
                            else
                            {
                                mt.Groups = null;
                            }

                            matchList.Add(mt);
                        }
                        return matchList;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(ArgumentException e)
                {
                    //System.Windows.Forms.MessageBox.Show(
                    //    e.Message,
                    //    e.ParamName,
                    //    System.Windows.Forms.MessageBoxButtons.OK,
                    //    System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }
                
            }
            else
            {
                return null;
            }
        }

        public static List<MatchElement> MatchesList(string input, string pattern, string SortMatches, int IndexMatch, string SortGroups, int IndexGroup)
        {
            List<MatchElement> MatchesList = RegMatch.MatchesList(input, pattern);
            if(MatchesList != null)
            {
                List<MatchElement> FilteredMatches = new List<MatchElement>();
                if (SortMatches == "Descending")
                {
                    if (MatchesList != null)
                    {
                        MatchesList.Reverse();
                    }
                }

                if (IndexMatch > -1)
                {
                    if (IndexMatch + 1 > MatchesList.Count())
                    {
                        IndexMatch = MatchesList.Count() - 1;
                    }
                    FilteredMatches.Add(MatchesList[IndexMatch]);
                }
                else
                {
                    FilteredMatches = MatchesList;
                }

                if (SortGroups == "Descending")
                {
                    foreach (MatchElement e in FilteredMatches)
                    {
                        if (e.Groups != null)
                        {
                            e.Groups.Reverse();
                        }
                    }
                }

                if (IndexGroup == -2)
                {
                    foreach (MatchElement e in FilteredMatches)
                    {
                        e.Groups = null;
                    }
                }
                else if (IndexGroup == -1)
                {

                }
                else
                {

                    foreach (MatchElement e in FilteredMatches)
                    {
                        if(e.Groups != null)
                        {
                            List<GroupElement> FilteredGroup = new List<GroupElement>();

                            if (IndexGroup + 1 > e.Groups.Count())
                            {
                                IndexGroup = e.Groups.Count() - 1;
                            }

                            FilteredGroup.Add(e.Groups[IndexGroup]);
                            e.Groups = FilteredGroup;
                        }
                        else
                        {
                            e.Groups = null;
                        }
                        
                    }
                }

                return FilteredMatches;
            }

            return null;
        }

        public static string ShowMatchCases(List<MatchElement> MatchesList, RichTextBox RichTextBox)
        {
            string match = "";
            RichTextBox.SelectAll();
            Color defaultBackColor = RichTextBox.BackColor;
            Color defaultFontColor = RichTextBox.ForeColor;
            RichTextBox.SelectionBackColor = defaultBackColor;
            RichTextBox.ForeColor = defaultFontColor;
            RichTextBox.SelectionLength = 0;

            if (MatchesList != null)
            {
                int i = -1;
                foreach (MatchElement e in MatchesList)
                {
                    RichTextBox.Select(e.Index, e.Value.Length);
                    RichTextBox.SelectionBackColor = Color.FromArgb(122, 189, 255);

                    i++;
                    //match = match + "Match:\t" + i + " - " + e.Value + Environment.NewLine;

                    //RichTextBox.SelectionColor = Color.WhiteSmoke;
                    if (e.Groups != null)
                    {
                        match = match + "Match:\t" + i + Environment.NewLine;
                        int m = -1;
                        foreach (GroupElement g in e.Groups)
                        {
                            m++;
                            match = match + "Group:\t" + m + " - " + g.Value + Environment.NewLine;
                            RichTextBox.Select(g.Index, g.Value.Length);
                            RichTextBox.SelectionBackColor = Color.FromArgb(198, 233, 157);
                            //RichTextBox.SelectionColor = Color.WhiteSmoke;
                        }
                    }
                    else
                    {
                        match = match + "Match:\t" + i + " - " + e.Value + Environment.NewLine;
                    }
                }
            }
            RichTextBox.Select(0, 0);
            return match;
        }
    }
}
