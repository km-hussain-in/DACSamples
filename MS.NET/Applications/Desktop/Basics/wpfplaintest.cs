using System;
using System.Windows;

class MainWindow : Window
{
	public MainWindow()
	{
		this.Title = "Hello World!";
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Goodbye User!", "Exiting");
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application app = new Application();
		app.Run(new MainWindow());
	}
}
