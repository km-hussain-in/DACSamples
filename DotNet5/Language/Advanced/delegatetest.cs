using System;

delegate int Sequence(int index);

static class Series
{
	public static long Sum(int count, Sequence term)
	{
		long total = 0;
		for(int i = 1; i <= count; ++i)
			total += term(i); //term.Invoke(i)
		return total;
	}
}

static class Program
{
	private static int Odd(int m)
	{	
		return 2 * m - 1;
	}

	public static void Main(string[] args)
	{
		int n = int.Parse(args[0]);

		long a = Series.Sum(n, Odd); //passing method reference
		Console.WriteLine("Sum of odd numbers = {0}", a);

		long b = Series.Sum(n, m => m * m); //passing lambda expression
		Console.WriteLine("Sum of square numbers = {0}", b);

	}
}
