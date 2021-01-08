using System;

delegate void QuoteEventHandler(object sender, QuoteEventArgs e);

class QuoteEventArgs : EventArgs
{
	public double CurrentValue {get;}

	public QuoteEventArgs(double value)
	{
		CurrentValue = value; //read-only property can be assigned in constructor
	}
}

//event source
class Publisher
{
	private static Random rdm = new Random();

	public event QuoteEventHandler Available;

	private static double FetchQuote(int id)
	{
		for(int t = Environment.TickCount; Environment.TickCount < t + 1000 * id;);
		
		return 0.01 * rdm.Next(1000, 10000);
	}

	public void Publish(int count)
	{
		for(int i = 1; i <= count; ++i)
		{
			double val = FetchQuote(i); 
			Available?.Invoke(this, new QuoteEventArgs(val));
			
		}
	}

}

//event sink
class Subscriber
{
	private Publisher pub = new Publisher();

	private void pub_Available(object sender, QuoteEventArgs e)
	{
		Console.WriteLine("New quote with value {0:0.00} arrived", e.CurrentValue);
	}

	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	public void Start()
	{
		pub.Available += pub_Available;
		pub.Available += ShowTime;
		pub.Publish(5);
	}
}

static class Program
{
	public static void Main()
	{
		var sub = new Subscriber();
		sub.Start();
	}
}
