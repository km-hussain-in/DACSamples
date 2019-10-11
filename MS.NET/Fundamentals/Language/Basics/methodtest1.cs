using System;

static class Program
{
	private static double Average(double first, double second)
	{
		return (first + second) / 2;
	}

	private static double Average(double first, double second, double third) => (first + second + third) / 3;

	private static double Average(double first, double second, params double[] remaining)
	{
		double total = first + second;

		foreach(double value in remaining)
		{
			total += value;
		}	

		return total / (2 + remaining.Length);
	}

	public static void Main()
	{
		Console.WriteLine("Average of two values = {0}", Average(23.7, 28.6));
		Console.WriteLine("Average of three values = {0:0.00}", Average(23.7, 28.6, 19.3));
		Console.WriteLine("Average of five values = {0:0.00}", Average(23.7, 28.6, 19.3, 31.5, 14.2)); //Average(23.7, 28.6, new double[]{19.3, 31.5, 14.2})

	}
}
