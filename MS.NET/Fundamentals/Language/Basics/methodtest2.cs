using System;

static class Program
{
	private static double GetIncome(double invest, int period=3, string risk="medium")
	{
		float rate;

		switch(risk)
		{
			case "low":
				rate = 6;
				break;
			case "high":
				rate = 9;
				break;
			default:
				rate = 7;
				break;
		}

		double amount = invest * Math.Pow(1 + rate / 100, period);

		return amount - invest;
	}

	public static void Main(string[] args)
	{
		try
		{
			double inv = double.Parse(args[0]);
		
			Console.WriteLine("Income in Bronze scheme: {0:0.00}", GetIncome(inv, 2, "low"));
			Console.WriteLine("Income in Silver scheme: {0:0.00}", GetIncome(inv, 4));
			Console.WriteLine("Income in Gold scheme: {0:0.00}", GetIncome(inv, risk : "high"));
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("USAGE: methodtest2 amount-to-invest");
		}
		catch(FormatException)
		{
			Console.WriteLine("ERROR: amount-to-invest is not a number");
		}
	}
}
