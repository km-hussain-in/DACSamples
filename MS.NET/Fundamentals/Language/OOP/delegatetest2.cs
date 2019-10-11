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
	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};

		Printer.PrintSquares("All", numbers);
		//passing anonymous method for delegate
		Printer.PrintSquares("Odd", numbers, delegate(int n){ return (n % 2) == 1;});
		//passing lambda expression for delegate
		Printer.PrintSquares("Big", numbers, n => n > 5);
	}
}
