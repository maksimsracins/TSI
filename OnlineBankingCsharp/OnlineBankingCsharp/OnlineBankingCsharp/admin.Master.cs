using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBankingCsharp
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession || Session["Email"] == null)
            {
                panelLogin.Visible = true;
                panelLogout.Visible = false;
            }
            else
            {
                panelLogin.Visible = false;
                panelLogout.Visible = true;
                LoginName.Text = Session["Firstname"].ToString();
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            panelLogin.Visible = true;
            panelLogout.Visible = false;
            Response.Redirect("~/login.aspx", false);
        }
    }
}