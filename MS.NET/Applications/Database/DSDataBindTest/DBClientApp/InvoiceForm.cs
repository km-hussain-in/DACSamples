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
    public partial class InvoiceForm : Form
    {
        public string CustomerId { get; set; }

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{CustomerId} - Invoice";
            this.invoiceTableAdapter.Fill(shopDataSet.Invoice, CustomerId);
        }
    }
}
