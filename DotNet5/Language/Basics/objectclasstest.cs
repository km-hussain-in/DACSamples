using System;

partial class Interval
{
	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
	}

	public static bool operator==(Interval lhs, Interval rhs)
	{
		return lhs.GetHashCode() == rhs.GetHashCode() && lhs.Equals(rhs);
	}

	public static bool operator!=(Interval lhs, Interval rhs) => !(lhs == rhs);


	~Interval()
	{
		Console.WriteLine("Disposing Interval {0}.", this);
	}	
}

static class Program
{
	static void Run()
	{
		var a = new Interval(5, 30);
		var b = new Interval(3, 5);
		var c = new Interval(4, 90);
		var d = b;
		var sum = a + b + c + d;

		Console.WriteLine("Interval sum = {0}", sum.ToString());
		Console.WriteLine($"Interval a = {a}");
		Console.WriteLine($"Interval b = {b}");
		Console.WriteLine($"Interval c = {c}");
		Console.WriteLine($"Interval d = {d}");
		Console.WriteLine();

		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));
		Console.WriteLine();

		Console.WriteLine("a is equal to b: {0}", a == b);
		Console.WriteLine("a is equal to c: {0}", a == c);
		Console.WriteLine("d is equal to b: {0}", d == b);
		Console.WriteLine();
	}

	static void Main()
	{
		Run();
		GC.Collect();
		GC.WaitForPendingFinalizers();		
	}
}
