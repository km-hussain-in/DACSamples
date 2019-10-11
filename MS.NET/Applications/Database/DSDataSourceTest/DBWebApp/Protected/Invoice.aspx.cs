using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp.Protected
{
    using System.Web.Security;

    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerIdLabel.Text = User.Identity.Name;
        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Server.Transfer("~/Product.aspx");
            Response.Redirect("~/Product.aspx");
        }
    }
}