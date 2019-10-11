using System;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello World";
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Goodbye User!", "Exiting");
	}
}

static class Program
{
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}
