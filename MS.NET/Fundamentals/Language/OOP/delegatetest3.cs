using System;

delegate void QuoteEventHandler(object sender, QuoteEventArgs e);

class QuoteEventArgs : EventArgs
{
	public double Value {get;}

	public QuoteEventArgs(double val) => Value = val;
}

//event source
class Publisher
{
	public event QuoteEventHandler Available;

	private static Random generator = new Random();

	private static double Generate(int id)
	{
		for(int t = Environment.TickCount + 1000 * id; t > Environment.TickCount;);

		return 0.01 * generator.Next(1000, 10000);
	}

	public void Publish(int count)
	{
		for(int i = 1; i <= count; ++i)
		{
			double value = Generate(i);
			var e = new QuoteEventArgs(value);

			Available?.Invoke(this, e); //if(Available != null) Available.Invoke(this, e)		
		}
	}

}

//event sink
class Subscriber
{
	private Publisher pub = new Publisher();

	private void pub_Available(object sender, QuoteEventArgs e)
	{
		Console.WriteLine("Quote recieved with value = {0}", e.Value); 
	}

	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	public void Run()
	{
		pub.Available += pub_Available;
		pub.Available += ShowTime; //contravariance for second parameter
		pub.Publish(5);
	}
}

static class Program
{
	public static void Main()
	{
		var sub = new Subscriber();
		sub.Run();
	}
}
