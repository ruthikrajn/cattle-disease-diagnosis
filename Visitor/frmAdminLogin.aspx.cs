using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace patternPrediction.Visitor
{
    public partial class frmAdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLoginId.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                Class1 obj = new Class1();


                if (obj.CheckAdminLogin(txtLoginId.Text, txtPassword.Text))
                {
                    Session["AdminId"] = txtLoginId.Text;
                    Response.Redirect("~/Admin/frmAdminHome.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid UserId/Password')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }        
    }
}