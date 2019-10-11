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
    public partial class MainForm : Form
    {
        private CartClient client = new CartClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void BuyButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text.ToLower();
            try
            {
                if (await client.AddItemAsync(item))
                    boughtListBox.Items.Add(item);
                else
                    MessageBox.Show($"Cannot add {item}", "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CheckoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                double amount = await client.CheckoutAsync();
                MessageBox.Show($"Total payment is {amount:0.00}", "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
