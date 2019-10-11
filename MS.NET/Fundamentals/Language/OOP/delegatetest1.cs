using System;

delegate bool Filter(int value);

static class Printer
{
	public static void PrintSquares(string caption, int[] values, Filter check = null)
	{
		Console.Write("{0} squares:", caption);

		foreach(int value in values)
		{
			if(check == null || check.Invoke(value))
				Console.Write(" {0}", value * value);
		}

		Console.WriteLine();
	}
}

static class Program
{
	private static bool IsOdd(int n)
	{
		return (n % 2) == 1;
	}

	//nested class
	class IsBiggerThan
	{
		private int limit;

		public IsBiggerThan(int l) => limit = l;

		public bool Confirm(int value)
		{
			return value > limit;
		}
	}

	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};

		Printer.PrintSquares("All", numbers);
		Printer.PrintSquares("Odd", numbers, IsOdd);
		Printer.PrintSquares("Big", numbers, new IsBiggerThan(5).Confirm);
	}
}
