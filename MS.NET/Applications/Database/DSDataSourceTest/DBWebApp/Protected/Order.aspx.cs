using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp.Protected
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerIdLabel.Text = User.Identity.Name;
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            string customerId = CustomerIdLabel.Text;
            int productNo = int.Parse(ProductNoDropDownList.Text);
            int quantity = int.Parse(QuantityTextBox.Text);
            int? orderNo = null;

            using (var shop = new ShopDataSetTableAdapters.ShopOperations())
                shop.PlaceOrder(customerId, productNo, quantity, ref orderNo);

            OutputLabel.Text = $"New order number is {orderNo}";
        }
    }
}