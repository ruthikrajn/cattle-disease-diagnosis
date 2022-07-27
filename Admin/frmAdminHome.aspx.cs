using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace patternPrediction.Admin
{
    public partial class frmAdminHome : System.Web.UI.Page
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
                    lblAdminId.ForeColor = System.Drawing.Color.ForestGreen;
                    lblAdminId.Font.Bold = true;
                    lblAdminId.Font.Size = 16;

                    if (DateTime.Now.Hour < 12)
                    {
                        lblAdminId.Text = "Welcome : " + Session["AdminId"].ToString() + ", Good Morning";
                    }
                    else if (DateTime.Now.Hour < 16)
                    {
                        lblAdminId.Text = "Welcome : " + Session["AdminId"].ToString() + ", Good Afternoon";
                    }
                    else
                    {
                        lblAdminId.Text = "Welcome : " + Session["AdminId"].ToString() + ", Good Evening";
                    }

                }
            }
            catch
            {

            }
        }
    }
}