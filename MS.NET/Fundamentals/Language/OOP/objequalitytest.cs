using System;

partial class Interval
{
	private static int count;

	partial void OnCreate()
	{
		++count;
		#if TESTING
		Console.WriteLine("Interval instance<{0}> activated", count);
		#endif
	}

	public static int CountInstances() => count;

	public static bool operator==(Interval x, Interval y)
	{
		return x.GetHashCode() == y.GetHashCode() && x.Equals(y);	
	}

	public static bool operator!=(Interval x, Interval y) => !(x == y);

}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(4, 30);
		Interval b = new Interval(3, 40);
		Interval c = new Interval(2, 150);
		Interval d = b;

		Console.WriteLine("Interval a = {0}", a.ToString());
		Console.WriteLine("Interval b = {0}", b);
		Console.WriteLine("Interval c = {0}", c);
		Console.WriteLine("Interval d = {0}", d);

		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));

		Console.WriteLine("a is equal to b: {0}", a == b);
		Console.WriteLine("a is equal to c: {0}", a == c);
		Console.WriteLine("d is equal to b: {0}", d == b);


		Console.WriteLine("Number of Intervals = {0}", Interval.CountInstances());
	}
}
