using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

class Circle : UIElement
{
	protected override void OnRender(DrawingContext dc)
	{
		DoubleAnimation da = new DoubleAnimation(100, 10, TimeSpan.FromSeconds(5));
		da.AutoReverse = true;
		//da.RepeatBehavior = RepeatBehavior.Forever;

		AnimationClock anim = da.CreateClock();

		dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 5), new Point(200, 200), null, 100, anim, 100, anim);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		this.InvalidateVisual();
	}
}

class MainWindow : Window
{
	public MainWindow()
	{
		this.Title = "Hello World!";
		this.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
		this.Content = new Circle();
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
