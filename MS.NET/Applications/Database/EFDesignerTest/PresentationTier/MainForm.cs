using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationTier
{
    using Sales;
    using System.ServiceModel;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            string customerId = customerIdTextBox.Text.ToUpper();
            int productNo = int.Parse(productNoTextBox.Text);
            int quantity = int.Parse(quantityTextBox.Text);

            using (var service = new ChannelFactory<IOrderManager>(new NetTcpBinding(), "net.tcp://localhost:4040/sales/ordermanager"))
            {
                IOrderManager client = service.CreateChannel();
                try
                {
                    int orderNo = client.PlaceOrder(customerId, productNo, quantity);
                    MessageBox.Show($"New order number is {orderNo}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Cannot place order with specified inputs", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
