using System;

static class Program
{
	private static void Swap(ref double first, ref double second)
	{
		double third = first;
		first = second;
		second = third;
	}

	public static double Average(double first, double second, out double deviation)
	{
		deviation = Math.Abs(first - second) / 2;
		return (first + second) / 2;
	}

	public static void Main(string[] args)
	{
		double x = double.Parse(args[0]);
		double y = double.Parse(args[1]);

		Console.WriteLine($"Original values = {x}, {y}");
		Swap(ref x, ref y);
		Console.WriteLine($"Swapped values  = {x}, {y}");

		double d;
		double a = Average(x, y, out d);
		Console.WriteLine($"Average is {a} with deviation of {d}");
	}
}
