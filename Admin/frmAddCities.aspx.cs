using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace patternPrediction.Admin
{
    public partial class frmAddCities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Visitor/frmLogin.aspx");
                }
                else
                {
                    GetCities();
                }
            }
            catch
            {

            }
        }



        #region ----- Manage Cities -----

        //function to get all cities
        private void GetCities()
        {
            try
            {
                DataTable tab = new DataTable();
                Class1 obj = new Class1();

                int serialNo = 1;

                tab = obj.GetCities();

                if (tab.Rows.Count > 0)
                {
                    tblCities.Rows.Clear();

                    tblCities.BorderStyle = BorderStyle.Double;
                    tblCities.GridLines = GridLines.Both;
                    tblCities.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.Black;

                    mainrow.BackColor = System.Drawing.Color.Goldenrod;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>City Name</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell4);

                    tblCities.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 250;
                        cellType.Text = tab.Rows[i]["City"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cell_delete = new TableCell();

                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.DarkRed;
                        lbtn_delete.Text = "Delete";
                        lbtn_delete.Font.Bold = true;
                        lbtn_delete.ID = tab.Rows[i]["CityId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);

                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        tblCities.Controls.Add(row);
                    }
                }
                else
                {
                    tblCities.Rows.Clear();

                    tblCities.BorderStyle = BorderStyle.None;
                    tblCities.GridLines = GridLines.None;

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Cities Found";

                    rno.Controls.Add(cellno);
                    tblCities.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        void lbtn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;

                Class1 obj = new Class1();
                obj.DeleteCity(int.Parse(btn.ID.ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('City Deleted Successfully!!!')</script>");
                GetCities();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!(Firts Delete Related Records!!)')</script>");
            }
        }


        //click event to insert the new city
        protected void btnCity_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 obj = new Class1();

                if (obj.CheckCity(txtCity.Text))
                {
                    obj.InsertCity(txtCity.Text);
                    ClearTextboxes();
                    GetCities();

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New City Added Successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('City Name Already Exists!!!')</script>");
                }

            }
            catch
            {

            }
        }

        //function to clear the textboxes
        private void ClearTextboxes()
        {
            txtCity.Text = string.Empty;
        }

        #endregion
      
    }
}