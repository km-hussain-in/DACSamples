using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp
{
    using System.Web.Security;

    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomerLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using(var shop = new ShopDataSetTableAdapters.ShopOperations())
            {
                if(shop.ValidateCustomer(CustomerLogin.UserName, CustomerLogin.Password) == 1)
                {
                    FormsAuthentication.RedirectFromLoginPage(CustomerLogin.UserName, false);
                    e.Authenticated = true;
                }
            }
        }
    }
}