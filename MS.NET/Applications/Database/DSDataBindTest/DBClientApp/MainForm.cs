using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClientApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CustomerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.shopDataSet);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.shopDataSet.Customer);

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var invoiceForm = new InvoiceForm();
            invoiceForm.CustomerId = customerIdTextBox.Text;
            //invoiceForm.ShowDialog(this);
            //invoiceForm.Dispose();
            invoiceForm.Show(this);
        }
    }
}
