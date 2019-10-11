using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PersonTextBox_TextChanged(object sender, EventArgs e)
        {
            greetButton.Enabled = personTextBox.TextLength > 0;
        }

        private void GreetButton_Click(object sender, EventArgs e)
        {
            //simpleGreeter.Person = personTextBox.Text;
            //simpleGreeter.Period = periodComboBox.Text;
            outputLabel.Text = simpleGreeter.Greet();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            geeterBindingSource.Add(simpleGreeter);
        }
    }
}
