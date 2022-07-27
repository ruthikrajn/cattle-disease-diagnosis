using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace patternPrediction.Visitor
{
    public partial class _Prediction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblTreatment.Text = lblTreatment.Text = string.Empty;

                //code to remove the stop words [preprocessing of data]
                string[] stopwords = { "a", "about", "above", "above", "across", "after", "afterwards", "again", "against", "all", "almost", "alone", "along", "already", "also", "although", "always", "am", "among", "amongst", "amoungst", "amount", "an", "and", "another", "any", "anyhow", "anyone", "anything", "anyway", "anywhere", "are", "around", "as", "at", "back", "be", "became", "because", "become", "becomes", "becoming", "been", "before", "beforehand", "behind", "being", "below", "beside", "besides", "between", "beyond", "bill", "both", "bottom", "but", "by", "call", "can", "cannot", "cant", "co", "con", "could", "couldnt", "cry", "de", "describe", "detail", "do", "done", "down", "due", "during", "each", "eg", "eight", "either", "eleven", "else", "elsewhere", "empty", "enough", "etc", "even", "ever", "every", "everyone", "everything", "everywhere", "except", "few", "fifteen", "fify", "fill", "find", "fire", "first", "five", "for", "former", "formerly", "forty", "found", "four", "from", "front", "full", "further", "get", "give", "go", "had", "has", "hasnt", "have", "he", "hence", "her", "here", "hereafter", "hereby", "herein", "hereupon", "hers", "herself", "him", "himself", "his", "how", "however", "hundred", "ie", "if", "in", "inc", "indeed", "interest", "into", "is", "it", "its", "itself", "keep", "last", "latter", "latterly", "least", "less", "ltd", "made", "many", "may", "me", "meanwhile", "might", "mill", "mine", "more", "moreover", "most", "mostly", "move", "much", "must", "my", "myself", "name", "namely", "neither", "never", "nevertheless", "next", "nine", "no", "nobody", "none", "noone", "nor", "not", "nothing", "now", "nowhere", "of", "off", "often", "on", "once", "one", "only", "onto", "or", "other", "others", "otherwise", "our", "ours", "ourselves", "out", "over", "own", "part", "per", "perhaps", "please", "put", "rather", "re", "same", "see", "seem", "seemed", "seeming", "seems", "serious", "several", "she", "should", "show", "side", "since", "sincere", "six", "sixty", "so", "some", "somehow", "someone", "something", "sometime", "sometimes", "somewhere", "still", "such", "system", "take", "ten", "than", "that", "the", "their", "them", "themselves", "then", "thence", "there", "thereafter", "thereby", "therefore", "therein", "thereupon", "these", "they", "thickv", "thin", "third", "this", "those", "though", "three", "through", "throughout", "thru", "thus", "to", "together", "too", "top", "toward", "towards", "twelve", "twenty", "two", "un", "under", "until", "up", "upon", "us", "very", "via", "was", "we", "well", "were", "what", "whatever", "when", "whence", "whenever", "where", "whereafter", "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which", "while", "whither", "who", "whoever", "whole", "whom", "whose", "why", "will", "with", "within", "without", "would", "yet", "you", "your", "yours", "yourself", "yourselves", "the" };

                string[] sentance = null;
                sentance = txtSymptoms.Text.Split('.');
                List<string> specialWords = new List<string>();

                for (int z = 0; z < sentance.Length; z++)
                {
                    specialWords.Clear();

                    string[] opinion = sentance[z].Split(' ');

                    for (int y = 0; y < sentance.Length; y++)
                    {
                        sentance[y] = sentance[y].Replace(",", String.Empty);
                        sentance[y] = sentance[y].Replace("?", String.Empty);
                        sentance[y] = sentance[y].Replace(":", String.Empty);
                        sentance[y] = sentance[y].Replace("(", String.Empty);
                        sentance[y] = sentance[y].Replace(")", String.Empty);
                    }

                    for (int j = 0; j < opinion.Length; j++)
                    {
                        if (!stopwords.Contains(opinion[j], StringComparer.InvariantCultureIgnoreCase))
                        {
                            specialWords.Add(opinion[j]);
                        }
                    }
                }

                //loading the keywords into string array
                string[] Keywords = specialWords.ToArray();

                string[] Symptoms = { "mouth-flow-foam", "appetite-loss", "muscle-tremor", "manic-restlessness", "bobbing-head", "mouth-color-pale", "Breast-enlargement-injury", 
                                        "Vaginal-stench", "Abnormal-tongue", "Low-urine", "yellow-urine", "Wound-infection-pain", "Abnormal-temperature", 
                                        "abnormal-breathing", "Abnormal-mouth-color", "foreign-matter-feces", "Ruminant-anomaly", "Depressed"};

                lblTreatment.ForeColor = System.Drawing.Color.Red;
                lblTreatment.Font.Bold = true;
                lblTreatment.Font.Size = 16;

                if (Keywords.Contains("Ruminant-anomaly") && Keywords.Contains("Depressed"))
                {
                    lblTreatment.Text = "Ssis";
                }
                else if (Keywords.Contains("Abnormal-mouth-color") && Keywords.Contains("appetite-loss"))
                {
                    lblTreatment.Text = "Cold";
                }
                else if (Keywords.Contains("Abnormal-mouth-color") && Keywords.Contains("foreign-matter-feces"))
                {
                    lblTreatment.Text = "Spleen-diarrhea";
                }
                else if (Keywords.Contains("Abnormal-temperature") && Keywords.Contains("abnormal-breathing"))
                {
                    lblTreatment.Text = "asthma";
                }
                else if (Keywords.Contains("Wound-infection-pain"))
                {
                    lblTreatment.Text = "trauma";
                }
                else if (Keywords.Contains("Abnormal-tongue") && Keywords.Contains("Low-urine") && Keywords.Contains("yellow-urine"))
                {
                    lblTreatment.Text = "gonorrhea";
                }
                else if (Keywords.Contains("Vaginal-stench"))
                {
                    lblTreatment.Text = "Uterine-prolapse";
                }
                else if (Keywords.Contains("Breast-enlargement-injury"))
                {
                    lblTreatment.Text = "Lack-of-milk";
                }
                else if (Keywords.Contains("mouth-color-pale"))
                {
                    lblTreatment.Text = "bruise";
                }
                else if (Keywords.Contains("mouth-flow-foam") && Keywords.Contains("appetite-loss") && Keywords.Contains("muscle-tremor") && Keywords.Contains("manic-restlessness"))
                {
                    lblTreatment.Text = "obstetric-disease";
                }
                else if (Keywords.Contains("mouth-flow-foam") && Keywords.Contains("appetite-loss") && Keywords.Contains("muscle-tremor") && Keywords.Contains("manic-restlessness") && Keywords.Contains("bobbing-head"))
                {
                    lblTreatment.Text = "poisoning-diseases";
                }
                else
                {
                    lblTreatment.Text = "Invalid Data";
                }


                if (Keywords.Contains("Ruminant-anomaly") || Keywords.Contains("Depressed"))
                {
                    lblTreatment.Text = "Ssis";
                }
                else if (Keywords.Contains("Abnormal-mouth-color") || Keywords.Contains("appetite-loss"))
                {
                    lblTreatment.Text = "Cold";
                }
                else if (Keywords.Contains("Abnormal-mouth-color") || Keywords.Contains("foreign-matter-feces"))
                {
                    lblTreatment.Text = "Spleen-diarrhea";
                }
                else if (Keywords.Contains("Abnormal-temperature") || Keywords.Contains("abnormal-breathing"))
                {
                    lblTreatment.Text = "asthma";
                }
                else if (Keywords.Contains("Wound-infection-pain"))
                {
                    lblTreatment.Text = "trauma";
                }
                else if (Keywords.Contains("Abnormal-tongue") || Keywords.Contains("Low-urine") || Keywords.Contains("yellow-urine"))
                {
                    lblTreatment.Text = "gonorrhea";
                }
                else if (Keywords.Contains("Vaginal-stench"))
                {
                    lblTreatment.Text = "Uterine-prolapse";
                }
                else if (Keywords.Contains("Breast-enlargement-injury"))
                {
                    lblTreatment.Text = "Lack-of-milk";
                }
                else if (Keywords.Contains("mouth-color-pale"))
                {
                    lblTreatment.Text = "bruise";
                }
                else if (Keywords.Contains("mouth-flow-foam") || Keywords.Contains("appetite-loss") || Keywords.Contains("muscle-tremor") || Keywords.Contains("manic-restlessness"))
                {
                    lblTreatment.Text = "obstetric-disease";
                }
                else if (Keywords.Contains("mouth-flow-foam") || Keywords.Contains("appetite-loss") || Keywords.Contains("muscle-tremor") || Keywords.Contains("manic-restlessness") || Keywords.Contains("bobbing-head"))
                {
                    lblTreatment.Text = "poisoning-diseases";
                }
                else
                {
                    lblTreatment.Text = "Invalid Data";
                }

            }
            catch
            {

            }

        }

       
    }
}