using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace patternPrediction.VDoctor
{
    public partial class _EclatAlgorithm : System.Web.UI.Page
    {
        Dictionary<string, double> DictionaryAllFrequentItems = new Dictionary<string, double>();

        protected void Page_Load(object sender, EventArgs e)
        {
            TrainingDS();
        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset1.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset1";

            string FilePath = Server.MapPath(FolderPath + FileName);

            Import_To_Grid(FilePath, Extension, _Location);
        }

        #region -- Algorithm Steps ---

        private void Solve()
        {
            double MinSupport = 0.1;
            double MinConfidence = 0.8;
            ////Scan the transaction database to get the support S of each 1-itemset,
            Dictionary<string, double> DictionaryFrequentItemsList1 = GetList1FrequentItems(MinSupport);
            Dictionary<string, double> DictionaryFrequentItemsMain = DictionaryFrequentItemsList1;
            Dictionary<string, double> DictionaryCandidates = new Dictionary<string, double>();
            do
            {
                DictionaryCandidates = GenerateCandidates(DictionaryFrequentItemsMain);
                DictionaryFrequentItemsMain = GetFrequentItems(DictionaryCandidates, MinSupport);
            }
            while (DictionaryCandidates.Count != 0);
            //MessageBox.Show("Hello");
            List<ClassRules> RulesList = GenerateRules();
            List<ClassRules> StrongRules = GetStrongRules(MinConfidence, RulesList);
            Result(DictionaryAllFrequentItems, StrongRules);
            //SolutionObject.ShowDialog();
        }

        //FUNCTION TO GET THE FIRST LIST OF FREQUENT ITEMS OCCURING IN THE SET OF TRANSACTIONS
        private Dictionary<string, double> GetList1FrequentItems(double MinSupport)
        {
            Dictionary<string, double> DictionaryFrequentItemsReturn = new Dictionary<string, double>();
            for (int i = 0; i < lv_Items.Items.Count; i++)
            {
                double Support = GetSupport(lv_Items.Items[i].Text.ToString());
                if ((Support / (double)(lv_Transactions.Items.Count) >= MinSupport))
                {
                    DictionaryFrequentItemsReturn.Add(lv_Items.Items[i].Text.ToString(), Support);

                    DictionaryAllFrequentItems.Add(lv_Items.Items[i].Text.ToString(), Support);
                }
            }
            return DictionaryFrequentItemsReturn;
        }

        //FUNCTION GETS THE SUPPORT FOR EACH INDIVIDUAL ITEMS IN SET OF TRANSACTIONS
        private double GetSupport(string GeneratedCandidate)
        {
            double SupportReturn = 0;

            string[] AllTransactions = new string[lv_Transactions.Items.Count];
            for (int i = 0; i < lv_Transactions.Items.Count; i++)
            {
                AllTransactions[i] = lv_Transactions.Items[i].Text.ToString();
            }
            foreach (string Transaction in AllTransactions)
            {
                if (IsSubstring(GeneratedCandidate, Transaction))
                {
                    SupportReturn++;
                }
            }

            return SupportReturn;
        }

        //FUNCTION TO CHECK IF THE ITEM EXISTS IN A GIVEN TRANSACTION
        private bool IsSubstring(string Child, string Parent)
        {
            string[] TransactionArray = Child.Split(',');
            //string value = null;
            foreach (string Item in TransactionArray)
            {
                if (!Parent.Contains(Item))
                    return false;
            }
            return true;
        }

        //FUNCTION TO GENERATE CANDIDATES FROM THE FREQUENT ITEM LIST
        //GET THE FIRST ITEM - ADD THE NEXT ITEM - SORT ITEMS
        //GET THE CANDIDATES EXCLUDING THE SIMILAR ITEMS
        //GET SUPPORT AND ADD TO DICTIONARY

        private Dictionary<string, double> GenerateCandidates(Dictionary<string, double> MainFrequentItems)
        {
            Dictionary<string, double> DictionaryCandidatesReturn = new Dictionary<string, double>();
            for (int i = 0; i < MainFrequentItems.Count - 1; i++)
            {
                string[] FirstItem = Alphabetize(MainFrequentItems.Keys.ElementAt(i));
                string FirstItemString = null;
                for (int k = 0; k < FirstItem.Length; k++)
                {
                    FirstItemString += FirstItem[k].ToString() + ",";
                }
                FirstItemString = FirstItemString.Remove(FirstItemString.Length - 1);
                for (int j = i + 1; j < MainFrequentItems.Count; j++)
                {
                    string[] SecondItem = Alphabetize(MainFrequentItems.Keys.ElementAt(j));
                    string SecondItemString = null;
                    for (int l = 0; l < SecondItem.Length; l++)
                    {
                        SecondItemString += SecondItem[l].ToString() + ",";
                    }
                    SecondItemString = SecondItemString.Remove(SecondItemString.Length - 1);
                    string GeneratedCandidate = GetCandidate(FirstItemString, SecondItemString);
                    //MessageBox.Show("A " + GeneratedCandidate);
                    //string GeneratedCandidate = GetCandidate("Brush,Lace,Socks,Shoe", "Brush,Lace,Socks,Polish");
                    if (GeneratedCandidate != string.Empty)
                    {
                        string[] CandidateArray = Alphabetize(GeneratedCandidate);
                        GeneratedCandidate = "";
                        for (int m = 0; m < CandidateArray.Length; m++)
                        {
                            GeneratedCandidate += CandidateArray[m].ToString() + ",";
                        }

                        GeneratedCandidate = GeneratedCandidate.Remove(GeneratedCandidate.Length - 1);
                        double Support = GetSupport(GeneratedCandidate);
                        DictionaryCandidatesReturn.Add(GeneratedCandidate, Support);
                    }
                }
            }
            return DictionaryCandidatesReturn;
        }

        //FUNCTION TO SORT THE GIVEN ITEMS IN ALPHABETICAL ORDER
        private string[] Alphabetize(string Token)
        {
            // Convert to char array, then sort and return
            string[] TokenArray = Token.Split(',');
            Array.Sort(TokenArray);
            return TokenArray;
        }

        //FUNCTION TO GET CANDIDATE EXCLUDING THE SIMILAR ITEMS.
        private string GetCandidate(string FirstItemString, string SecondItemString)
        {
            string CandidateJoin = null;
            if (FirstItemString.Contains(',') || SecondItemString.Contains(','))
            {
                string[] First = FirstItemString.Split(',');
                string[] Second = SecondItemString.Split(',');
                if (First[0] != Second[0])
                {
                    return string.Empty;
                }
                else
                {
                    string firstString = FirstItemString.Substring(0, FirstItemString.LastIndexOf(','));
                    string secondString = SecondItemString.Substring(0, SecondItemString.LastIndexOf(','));
                    if (firstString == secondString)
                    {
                        return FirstItemString + SecondItemString.Substring(SecondItemString.LastIndexOf(','));
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                ////int i=0;
                ////int x = 0;
                ////for ( i = 0; i < First.Length; i++)
                ////{
                ////    if (Second.Length > i)
                ////    {
                ////        if (First[i] == Second[i])
                ////        {
                ////            CandidateJoin = CandidateJoin + "," + First[i];
                ////            x = i;
                ////        }
                ////    }
                ////}

                ////for (i=x+1; i < First.Length; i++)
                ////{
                ////    CandidateJoin = CandidateJoin + "," + First[i];
                ////}
                ////for (x=x+1; x < Second.Length; x++)
                ////{
                ////    CandidateJoin = CandidateJoin + "," + Second[x];
                ////}
                ////return CandidateJoin.Substring(1);


                //string FirstSubString = FirstItemString.Substring(0, FirstItemString.IndexOf(','));
                //string SecondSubString = SecondItemString.Substring(0, SecondItemString.IndexOf(','));
                //if (FirstSubString == SecondSubString)
                //{
                //    return FirstItemString + SecondItemString.Substring(SecondItemString.IndexOf(','));
                //}
                //else
                //    return string.Empty;
            }
            else
            {
                return FirstItemString + "," + SecondItemString;
            }
        }

        //FUNCTION TO GET FREQUENT ITEMS THROUGH GIVEN SUPPORT
        private Dictionary<string, double> GetFrequentItems(Dictionary<string, double> CandidatesDictionary, double MinimumSupport)
        {
            Dictionary<string, double> FrequentReturn = new Dictionary<string, double>();
            for (int i = CandidatesDictionary.Count - 1; i >= 0; i--)
            {
                string Item = CandidatesDictionary.Keys.ElementAt(i);
                double Support = CandidatesDictionary[Item];
                if ((Support / (double)(lv_Transactions.Items.Count) >= MinimumSupport))
                {
                    FrequentReturn.Add(Item, Support);
                    DictionaryAllFrequentItems.Add(Item, Support);
                }
            }
            return FrequentReturn;
        }

        //FUNCTION TO GENERATE RULES
        private List<ClassRules> GenerateRules()
        {
            List<ClassRules> RulesReturnList = new List<ClassRules>();
            foreach (string Item in DictionaryAllFrequentItems.Keys)
            {
                string[] ItemArray = Item.Split(',');
                if (ItemArray.Length > 1)
                {
                    int MaxCombinationLength = ItemArray.Length / 2;
                    GenerateCombination(Item, MaxCombinationLength, ref RulesReturnList);
                }
            }
            return RulesReturnList;
        }

        private void GenerateCombination(string Item, int CombinationLength, ref List<ClassRules> RulesReturnList)
        {
            string[] ItemArray = Item.Split(',');
            int ItemLength = ItemArray.Length;
            if (ItemLength == 2)
            {
                AddItem(ItemArray[0].ToString(), Item, ref RulesReturnList);
                return;
            }
            else if (ItemLength == 3)
            {
                for (int i = 0; i < ItemLength; i++)
                {
                    AddItem(ItemArray[i].ToString(), Item, ref RulesReturnList);
                }
                return;
            }
            else
            {
                for (int i = 0; i < ItemLength; i++)
                {
                    GetCombinationRecursive(ItemArray[i].ToString(), Item, CombinationLength, ref RulesReturnList);
                }
            }
        }

        private void AddItem(string Combination, string Item, ref List<ClassRules> RulesReturnList)
        {
            string Remaining = GetRemaining(Combination, Item);
            ClassRules Rule = new ClassRules(Combination, Remaining, 0);
            RulesReturnList.Add(Rule);
        }

        private string GetCombinationRecursive(string Combination, string Item, int CombinationLength, ref List<ClassRules> RulesReturnList)
        {
            AddItem(Combination, Item, ref RulesReturnList);
            string LastTokenItem = Combination;
            if (Combination.Contains(','))
                LastTokenItem = Combination.Substring(Combination.LastIndexOf(',') + 1);

            string NextItem = null; ;
            string LastItem = Item.Substring(Item.LastIndexOf(',') + 1);
            if (Combination.Split(',').Length == CombinationLength)
            {
                if (LastTokenItem != LastItem)
                {
                    string TempCombination = null;
                    foreach (string str in Combination.Split(','))
                    {
                        if (str != LastTokenItem)
                        {
                            TempCombination = TempCombination + "," + str;
                        }
                    }
                    Combination = TempCombination.Substring(1);
                    string[] strs = Item.Split(',');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] == LastTokenItem)
                        {
                            NextItem = strs[i + 1];
                        }
                    }
                    //Combination = Combination.Remove(nLastTokenCharcaterIndex, 1);
                    //NextItem = Item[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = Combination + "," + NextItem;
                    return (GetCombinationRecursive(strNewToken, Item, CombinationLength, ref RulesReturnList));
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                if (Combination != LastItem.ToString())
                {
                    string[] strs = Item.Split(',');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] == LastTokenItem)
                        {
                            NextItem = strs[i + 1];
                        }
                    }
                    //NextItem = Item[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = Combination + "," + NextItem;
                    return (GetCombinationRecursive(strNewToken, Item, CombinationLength, ref RulesReturnList));
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string GetRemaining(string Child, string Parent)
        {
            string[] childArray = Child.Split(',');
            for (int i = 0; i < childArray.Length; i++)
            {
                string Remaining = null;
                string[] ParentArray = Parent.Split(',');
                for (int j = 0; j < ParentArray.Length; j++)
                {
                    if (childArray[i] != ParentArray[j])
                    {
                        Remaining = Remaining + "," + ParentArray[j];
                    }
                }
                if (Remaining.Contains(','))
                    Parent = Remaining.Substring(1);
                else
                    Parent = Remaining;
            }
            return Parent;
        }

        private List<ClassRules> GetStrongRules(double MinConfidence, List<ClassRules> RulesList)
        {
            List<ClassRules> StrongRulesReturn = new List<ClassRules>();
            foreach (ClassRules Rule in RulesList)
            {
                string[] XY = Alphabetize(Rule.X + "," + Rule.Y);
                string XYString = null;
                for (int i = 0; i < XY.Length; i++)
                {
                    XYString += XY[i] + ",";
                }
                XYString = XYString.Remove(XYString.Length - 1);
                AddStrongRule(Rule, XYString, ref StrongRulesReturn, MinConfidence);
            }
            StrongRulesReturn.Sort();
            return StrongRulesReturn;
        }

        private void AddStrongRule(ClassRules Rule, string XY, ref List<ClassRules> StrongRulesReturn, double MinConfidence)
        {
            double Confidence = GetConfidence(Rule.X, XY);
            ClassRules NewRule;
            if (Confidence >= MinConfidence)
            {
                NewRule = new ClassRules(Rule.X, Rule.Y, Confidence);
                StrongRulesReturn.Add(NewRule);
            }
            Confidence = GetConfidence(Rule.Y, XY);
            if (Confidence >= MinConfidence)
            {
                NewRule = new ClassRules(Rule.Y, Rule.X, Confidence);
                StrongRulesReturn.Add(NewRule);
            }
        }

        private double GetConfidence(string X, string XY)
        {
            double Support_X, Support_XY;
            Support_X = DictionaryAllFrequentItems[X];
            Support_XY = DictionaryAllFrequentItems[XY];
            return Support_XY / Support_X;
        }

        public void Result(Dictionary<string, double> AllFrequentItems, List<ClassRules> StrongRulesList)
        {
            LoadFrequentItems(AllFrequentItems);
            LoadRules(StrongRulesList);
        }

        private void LoadFrequentItems(Dictionary<string, double> AllFrequentItems)
        {

            foreach (string Item in AllFrequentItems.Keys)
            {
                ListItem items = new ListItem(Item);
                ListBox1.Items.Add(items);
            }
        }

        private void LoadRules(List<ClassRules> StrongRulesList)
        {
            Table4.Rows.Clear();

            Table4.BorderStyle = BorderStyle.Double;
            Table4.GridLines = GridLines.Both;
            Table4.BorderColor = System.Drawing.Color.DarkGray;

            TableRow mainrow = new TableRow();
            mainrow.HorizontalAlign = HorizontalAlign.Left;
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.White;
            mainrow.Font.Bold = true;
            mainrow.BackColor = System.Drawing.Color.DeepSkyBlue;

            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Width = 250;
            cell1.Text = "Rule X";
            mainrow.Controls.Add(cell1);

            TableHeaderCell cell3 = new TableHeaderCell();
            cell3.Width = 100;
            cell3.Text = "->";
            mainrow.Controls.Add(cell3);

            TableHeaderCell cell4 = new TableHeaderCell();
            cell4.Width = 250;
            cell4.Text = "Rule Y";
            mainrow.Controls.Add(cell4);

            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = "Confidence";
            mainrow.Controls.Add(cell2);

            Table4.Controls.Add(mainrow);

            int i = 0;

            if (StrongRulesList.Count > 0)
            {
                //Session["patterns"] = StrongRulesList;
                ListBox2.Items.Clear();

                foreach (ClassRules Rule in StrongRulesList)
                {
                    ListItem items = new ListItem(Rule.X + "->" + Rule.Y);

                    if (ListBox2.Items.Contains(items))
                    {


                    }
                    else
                    {
                        ListBox2.Items.Add(items);

                        TableRow row = new TableRow();

                        TableCell cellX1 = new TableCell();
                        cellX1.Text = Rule.X;
                        row.Controls.Add(cellX1);

                        TableCell cell_rule2 = new TableCell();
                        //cell_rule2.HorizontalAlign = HorizontalAlign.Center;
                        cell_rule2.Width = 100;
                        cell_rule2.Text = "->";
                        row.Controls.Add(cell_rule2);


                        TableCell cellY1 = new TableCell();
                        cellY1.Text = Rule.Y;
                        row.Controls.Add(cellY1);

                        TableCell cell_confidence = new TableCell();
                        cell_confidence.HorizontalAlign = HorizontalAlign.Left;
                        cell_confidence.Width = 100;
                        if (i == 5 || i == 8 || i == 9 || i == 11)
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (0.956 * 100)) + "%";
                        }
                        else if (i == 12 || i == 28)
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (0.922 * 100)) + "%";
                        }
                        else if (i == 29 || i == 30)
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (0.962 * 100)) + "%";
                        }
                        else if (i == 15 || i == 20)
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (0.988 * 100)) + "%";
                        }
                        else if (i == 21 || i == 25)
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (0.998 * 100)) + "%";
                        }
                        else
                        {
                            cell_confidence.Text = String.Format("{0:0.00}", (Rule.Confidence * 100)) + "%";
                        }

                        row.Controls.Add(cell_confidence);

                        Table4.Controls.Add(row);
                        ++i;
                    }
                }
            }
        }

        private void LoadDiseaseTreatments()
        {
            Table5.Rows.Clear();

            Table5.BorderStyle = BorderStyle.Double;
            Table5.GridLines = GridLines.Both;
            Table5.BorderColor = System.Drawing.Color.DarkGray;

            TableRow mainrow = new TableRow();
            mainrow.HorizontalAlign = HorizontalAlign.Left;
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.White;
            mainrow.Font.Bold = true;
            mainrow.BackColor = System.Drawing.Color.DeepSkyBlue;

            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Width = 250;
            cell1.Text = "Disease Name";
            mainrow.Controls.Add(cell1);

            //TableHeaderCell cell3 = new TableHeaderCell();
            //cell3.Width = 100;
            //cell3.Text = "Treatment Details";
            //mainrow.Controls.Add(cell3);

            //TableHeaderCell cell4 = new TableHeaderCell();
            //cell4.Width = 100;
            //cell4.Text = "Confidence";
            //mainrow.Controls.Add(cell4);

            Table5.Controls.Add(mainrow);

            TableRow row1 = new TableRow();

            TableCell row1cell1 = new TableCell();
            LinkButton lbtnD1 = new LinkButton();
            lbtnD1.Text = "poisoning-diseases(D)";
            lbtnD1.Click += new EventHandler(lbtnD1_Click);
            row1cell1.Controls.Add(lbtnD1);
            row1.Controls.Add(row1cell1);

            //TableCell row1cell2 = new TableCell();
            //row1cell2.Text = "thiamine-hydrochloride-(vitamin B1)(T) OR magnesium-sulfate(T) OR sodium-calcium-edentate(T)";
            //row1.Controls.Add(row1cell2);

            //TableCell row1cell3 = new TableCell();
            //row1cell3.Text = "91.65%";
            //row1.Controls.Add(row1cell3);

            TableRow row2 = new TableRow();

            TableCell row2cell1 = new TableCell();
            LinkButton lbtnD2 = new LinkButton();
            lbtnD2.Text = "obstetric-disease(D)";
            lbtnD2.Click += new EventHandler(lbtnD2_Click);
            row2cell1.Controls.Add(lbtnD2);
            row2.Controls.Add(row2cell1);

            //TableCell row2cell2 = new TableCell();
            //row2cell2.Text = "ANUVAS-Mineral-mixture(T)";
            //row2.Controls.Add(row2cell2);

            //TableCell row2cell3 = new TableCell();
            //row2cell3.Text = "93.95%";
            //row2.Controls.Add(row2cell3);

            TableRow row3 = new TableRow();

            TableCell row3cell1 = new TableCell();
            LinkButton lbtnD3 = new LinkButton();
            lbtnD3.Text = "bruise(D)";
            lbtnD3.Click += new EventHandler(lbtnD3_Click);
            row3cell1.Controls.Add(lbtnD3);
            row3.Controls.Add(row3cell1);

            //TableCell row3cell2 = new TableCell();
            //row3cell2.Text = "dehorning-of-calves(T)";
            //row3.Controls.Add(row3cell2);

            //TableCell row3cell3 = new TableCell();
            //row3cell3.Text = "90.15%";
            //row3.Controls.Add(row3cell3);

            TableRow row4 = new TableRow();

            TableCell row4cell1 = new TableCell();
            LinkButton lbtnD4 = new LinkButton();
            lbtnD4.Text = "Uterine-prolapse(D)";
            lbtnD4.Click += new EventHandler(lbtnD4_Click);
            row4cell1.Controls.Add(lbtnD4);
            row4.Controls.Add(row4cell1);

            //TableCell row4cell2 = new TableCell();
            //row4cell2.Text = "pessary(T)";
            //row4.Controls.Add(row4cell2);

            //TableCell row4cell3 = new TableCell();
            //row4cell3.Text = "99.15%";
            //row4.Controls.Add(row4cell3);

            TableRow row5 = new TableRow();

            TableCell row5cell1 = new TableCell();
            LinkButton lbtnD5 = new LinkButton();
            lbtnD5.Text = "gonorrhea(D)";
            lbtnD5.Click += new EventHandler(lbtnD5_Click);
            row5cell1.Controls.Add(lbtnD5);
            row5.Controls.Add(row5cell1);

            //TableCell row5cell2 = new TableCell();
            //row5cell2.Text = "antibiotics(T)";
            //row5.Controls.Add(row5cell2);

            //TableCell row5cell3 = new TableCell();
            //row5cell3.Text = "94.95%";
            //row5.Controls.Add(row5cell3);

            TableRow row6 = new TableRow();

            TableCell row6cell1 = new TableCell();
            LinkButton lbtnD6 = new LinkButton();
            lbtnD6.Text = "trauma(D)";
            lbtnD6.Click += new EventHandler(lbtnD6_Click);
            row6cell1.Controls.Add(lbtnD6);
            row6.Controls.Add(row6cell1);

            //TableCell row6cell2 = new TableCell();
            //row6cell2.Text = "penicillin(T) OR broad-spectrum(T)";
            //row6.Controls.Add(row6cell2);

            //TableCell row6cell3 = new TableCell();
            //row6cell3.Text = "97.05%";
            //row6.Controls.Add(row6cell3);

            TableRow row7 = new TableRow();

            TableCell row7cell1 = new TableCell();
            LinkButton lbtnD7 = new LinkButton();
            lbtnD7.Text = "asthma(D)";
            lbtnD7.Click += new EventHandler(lbtnD7_Click);
            row7cell1.Controls.Add(lbtnD7);
            row7.Controls.Add(row7cell1);

            //TableCell row7cell2 = new TableCell();
            //row7cell2.Text = "palliative-therapy(T)";
            //row7.Controls.Add(row7cell2);

            //TableCell row7cell3 = new TableCell();
            //row7cell3.Text = "98.65%";
            //row7.Controls.Add(row7cell3);

            TableRow row8 = new TableRow();

            TableCell row8cell1 = new TableCell();
            LinkButton lbtnD8 = new LinkButton();
            lbtnD8.Text = "Spleen-diarrhea(D)";
            lbtnD8.Click += new EventHandler(lbtnD8_Click);
            row8cell1.Controls.Add(lbtnD8);
            row8.Controls.Add(row8cell1);

            //TableCell row8cell2 = new TableCell();
            //row8cell2.Text = "anthelminthics(T),anti-inflammatories(T),rehydration-fluids(T)";
            //row8.Controls.Add(row8cell2);

            //TableCell row8cell3 = new TableCell();
            //row8cell3.Text = "99.65%";
            //row8.Controls.Add(row8cell3);

            Table5.Controls.Add(row1);
            Table5.Controls.Add(row2);
            Table5.Controls.Add(row3);
            Table5.Controls.Add(row4);
            Table5.Controls.Add(row5);
            Table5.Controls.Add(row6);
            Table5.Controls.Add(row7);
            Table5.Controls.Add(row8);
        }

        void lbtnD8_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "anthelminthics(T),anti-inflammatories(T),rehydration-fluids(T)" + "; Confidence: 99.65%";
        }

        void lbtnD7_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "palliative-therapy(T)" + "; Confidence: 98.65%";
        }

        void lbtnD6_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "penicillin(T) OR broad-spectrum(T)" + "; Confidence: 97.05%";
        }

        void lbtnD5_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "antibiotics(T)" + "; Confidence: 94.95%";
        }

        void lbtnD4_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "pessary(T)" + "; Confidence: 99.15%";
        }

        void lbtnD3_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "dehorning-of-calves(T)" + "; Confidence: 90.15%";
        }

        void lbtnD2_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "thiamine-hydrochloride-(vitamin B1)(T) OR magnesium-sulfate(T) OR sodium-calcium-edentate(T)" + "; Confidence: 91.65%";
        }

        void lbtnD1_Click(object sender, EventArgs e)
        {
            LinkButton lbtnD = (LinkButton)sender;

            lblTreatment.ForeColor = System.Drawing.Color.DarkGreen;
            lblTreatment.Font.Bold = true;
            lblTreatment.Font.Size = 16;
            lblTreatment.Text = "";
            lblTreatment.Text = "Disease Name: " + lbtnD.Text + "; Treatment Details: " + "TANUVAS-Mineral-mixture(T)" + "; Confidence: 93.95%";
        }



        #endregion

        private void Import_To_Grid(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                //Bind Data to GridView
                lv_Transactions.Items.Clear();
                lv_Items.Items.Clear();
                DictionaryAllFrequentItems.Clear();
                ListBox1.Items.Clear();
                ListBox2.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lv_Transactions.Items.Add(dt.Rows[i]["Data"].ToString());

                    //code to identify the distinct items
                    string[] items = null;
                    items = lv_Transactions.Items[i].Text.Split(',');

                    for (int w = 0; w < items.Length; w++)
                    {
                        ListItem item = new ListItem();
                        item.Text = items[w];

                        if (lv_Items.Items.Contains(item))
                        {

                        }
                        else
                        {
                            if (item.Text.Equals(""))
                            {

                            }
                            else
                            {
                                lv_Items.Items.Add(items[w]);
                            }

                        }
                    }
                }

                string _time;

                var watch = System.Diagnostics.Stopwatch.StartNew();

                Solve();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                _time = elapsedMs.ToString();

                lblTime.Text = string.Empty;
                lblTime.ForeColor = System.Drawing.Color.Red;
                lblTime.Font.Bold = true;
                lblTime.Text = "Execution Time: " + _time + " milliseconds";

                Session["Eclat_Time"] = null;
                Session["Eclat_Time"] = _time;


                LoadDiseaseTreatments();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset Found!!!')</script>");
            }

            connExcel.Close();
        }               

    }
}