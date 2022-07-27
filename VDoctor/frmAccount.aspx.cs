using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace patternPrediction.VDoctor
{
    public partial class frmAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ICId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Visitor/frmLogin.aspx");
                }
                else
                {
                    if (!this.IsPostBack)

                        txtOldPassword.Focus();
                }
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = new DataTable();
                Class1 obj = new Class1();
                tab.Rows.Clear();

                tab = obj.GetICById(Session["ICId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Text.Equals(oldPassword))
                {
                    obj.UpdateICPassword(txtNewPassword.Text, Session["ICId"].ToString());
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User Password changed successfully')</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('User Old password incorrect')</script>");
                }
            }
            catch
            {

            }
        }
    }
}