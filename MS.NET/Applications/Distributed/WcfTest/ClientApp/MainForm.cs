using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    using Shopping;
    using System.ServiceModel;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text.ToLower();
            int quantity = (int)quantityNumericUpDown.Value;

            using(ChannelFactory<IShopKeeper> service = new ChannelFactory<IShopKeeper>(new NetTcpBinding(), "net.tcp://localhost:4020/shopping/shopkeeper"))
            {
                IShopKeeper proxy = service.CreateChannel();
                ItemInfo info = proxy.GetItemInfo(item);
                if (info?.CurrentStock >= quantity)
                {
                    float discount = proxy.GetBulkDiscount(quantity);
                    double amount = quantity * info.UnitPrice * (1 - discount / 100);
                    paymentTextBox.Text = amount.ToString("0.00");
                }
                else
                    paymentTextBox.Text = "Not Available";                       
            }
        }
    }
}
