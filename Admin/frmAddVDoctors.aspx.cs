using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace patternPrediction.Admin
{
    public partial class frmAddVDoctors : System.Web.UI.Page
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
                    if (!this.IsPostBack)
                    {
                        LoadCities();
                    }

                    GetDoctors();
                }
            }
            catch
            {

            }
        }

        //funcion to load cities
        public void LoadCities()
        {
            DataTable tab = new DataTable();
            Class1 obj = new Class1();

            tab = obj.GetCities();

            if (tab.Rows.Count > 0)
            {
                DropDownListCity.Items.Clear();
                DropDownListCity.DataSource = tab;
                DropDownListCity.DataTextField = "City";
                DropDownListCity.DataValueField = "CityId";

                DropDownListCity.DataBind();

                DropDownListCity.Items.Insert(0, "- Select -");

            }
            else
            {
                DropDownListCity.Items.Insert(0, "- Input City First-");

            }
        }

        //function to get all inchargers
        private void GetDoctors()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            Class1 obj = new Class1();

            tab = obj.GetICs();

            if (tab.Rows.Count > 0)
            {
                tblICs.Rows.Clear();

                tblICs.BorderStyle = BorderStyle.Double;
                tblICs.GridLines = GridLines.Both;
                tblICs.BorderColor = System.Drawing.Color.Black;

                TableRow headerrow = new TableRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.Black;
                headerrow.BackColor = System.Drawing.Color.Goldenrod;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>City</b>";
                headerrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>ID</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Password</b>";
                headerrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>ContactNo</b>";
                headerrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>Edit</b>";
                headerrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>Delete</b>";
                headerrow.Controls.Add(cell7);

                tblICs.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellCity = new TableCell();
                    cellCity.Width = 150;

                    DataTable tabCity = new DataTable();
                    tabCity = obj.GetCityById(int.Parse(tab.Rows[cnt]["CityId"].ToString()));

                    cellCity.Text = tabCity.Rows[0]["City"].ToString();
                    row.Controls.Add(cellCity);

                    TableCell cellIAId = new TableCell();
                    cellIAId.Width = 150;
                    cellIAId.Text = tab.Rows[cnt]["InchargerId"].ToString();
                    row.Controls.Add(cellIAId);

                    TableCell cellPwd = new TableCell();
                    cellPwd.Width = 150;
                    cellPwd.Text = tab.Rows[cnt]["Password"].ToString();
                    row.Controls.Add(cellPwd);

                    TableCell cellMobile = new TableCell();
                    cellMobile.Width = 150;
                    cellMobile.Text = tab.Rows[cnt]["ContactNo"].ToString();
                    row.Controls.Add(cellMobile);


                    TableCell cellEdit = new TableCell();

                    ImageButton btnEdit = new ImageButton();
                    btnEdit.Width = 15;
                    btnEdit.Height = 15;
                    btnEdit.ImageUrl = "~/images/edit-10-xxl.png";
                    btnEdit.ToolTip = "Click here to Edit the IA";
                    btnEdit.ID = "Edit~" + tab.Rows[cnt]["InchargerId"].ToString();

                    btnEdit.Click += new ImageClickEventHandler(btnEdit_Click);

                    cellEdit.Controls.Add(btnEdit);
                    row.Controls.Add(cellEdit);

                    TableCell cellDelete = new TableCell();

                    ImageButton btnDelete = new ImageButton();
                    btnDelete.Width = 15;
                    btnDelete.Height = 15;
                    btnDelete.ImageUrl = "~/images/deletebtn.jpg";
                    btnDelete.ToolTip = "Click here to Delete the IA";
                    btnDelete.ID = "Del~" + tab.Rows[cnt]["InchargerId"].ToString();
                    btnDelete.OnClientClick = "return confirm('Are you sure do you want to Delete')";
                    btnDelete.Click += new ImageClickEventHandler(btnDelete_Click);

                    cellDelete.Controls.Add(btnDelete);
                    row.Controls.Add(cellDelete);


                    tblICs.Controls.Add(row);

                }

            }
            else
            {
                tblICs.Rows.Clear();
                tblICs.GridLines = GridLines.None;
                tblICs.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;

                cell.Text = "No Records Found!!!";


                row.Controls.Add(cell);
                tblICs.Controls.Add(row);

            }

        }

        void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Class1 obj = new Class1();
            ImageButton btn = (ImageButton)sender;
            string[] s = btn.ID.ToString().Split('~');

            Session["IC"] = null;
            Session["IC"] = s[1];

            DataTable tab = new DataTable();
            tab = obj.GetICById(s[1]);

            if (tab.Rows.Count > 0)
            {
                txtICID.Text = tab.Rows[0]["InchargerId"].ToString();
                txtName.Text = tab.Rows[0]["Name"].ToString();
                txtPassword.Text = tab.Rows[0]["Password"].ToString();
                txtAddress.Text = tab.Rows[0]["Address"].ToString();
                txtContactNo.Text = tab.Rows[0]["ContactNo"].ToString();
                txtEmailId.Text = tab.Rows[0]["EmailId"].ToString();

                string dataTextFieldCity = DropDownListCity.Items.FindByValue(tab.Rows[0]["CityId"].ToString()).ToString();

                ListItem item = new ListItem(dataTextFieldCity, tab.Rows[0]["CityId"].ToString());
                int index = DropDownListCity.Items.IndexOf(item);

                if (index != -1)

                    DropDownListCity.SelectedIndex = index;
            }

            btnIC.Text = "Update";
        }

        //function to clear textboxes
        private void ClearTexts()
        {
            txtAddress.Text = txtContactNo.Text = txtEmailId.Text = txtICID.Text = txtName.Text = txtPassword.Text = string.Empty;
            DropDownListCity.SelectedIndex = 0;
        }

        void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;

                Class1 obj = new Class1();
                string[] s = btn.ID.Split('~');
                obj.DeleteIA(s[1]);
                ClearTexts();
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Deleted Successfully!!!')</script>");
                GetDoctors();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Deletion Error!!!')</script>");
            }
        }

        protected void btnIC_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 obj = new Class1();

                if (DropDownListCity.SelectedIndex > 0)
                {
                    if (btnIC.Text == "Add")
                    {
                        if (obj.CheckICId(txtICID.Text))
                        {
                            obj.InsertIC(txtICID.Text, txtPassword.Text, txtName.Text, txtAddress.Text, int.Parse(DropDownListCity.SelectedValue), txtContactNo.Text, txtEmailId.Text);
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Added Successfully!!')</script>");
                            ClearTexts();
                            GetDoctors();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Id Exists!!!')</script>");
                        }
                    }
                    else if (btnIC.Text == "Update")
                    {
                        if (txtICID.Text.Equals(Session["IC"].ToString()))
                        {
                            obj.UpdateIC(txtICID.Text, txtPassword.Text, txtName.Text, txtAddress.Text, int.Parse(DropDownListCity.SelectedValue), txtContactNo.Text, txtEmailId.Text, Session["IC"].ToString());
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Updated Successfully!!!')</script>");
                            ClearTexts();
                            GetDoctors();
                            btnIC.Text = "Add";
                        }
                        else
                        {
                            if (obj.CheckICId(txtICID.Text))
                            {
                                obj.UpdateIC(txtICID.Text, txtPassword.Text, txtName.Text, txtAddress.Text, int.Parse(DropDownListCity.SelectedValue), txtContactNo.Text, txtEmailId.Text, Session["IC"].ToString());
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Details Updated Successfully!!!')</script>");
                                ClearTexts();
                                GetDoctors();
                                btnIC.Text = "Add";
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Record Id Exists!!!')</script>");
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select City!!!')</script>");
                }

            }
            catch
            {

            }

        }


    }
}