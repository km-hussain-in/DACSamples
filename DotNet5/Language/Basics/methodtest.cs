using System;

static class Program
{

	static double GetIncome(double amount, short years, bool risky)
	{
		float rate = risky ? 8 : 6;
		return amount * Math.Pow(1 + rate / 100, years) - amount;
	}

	static (double, double) GetIncome(short years, bool risky=false)
	{
		double amount = risky ? 20000 : 5000;
		double income = GetIncome(amount, years, risky);

		return (amount, income);	
	}

	static void Main(string[] args)
	{

		if(args.Length > 1)
		{
			double a = double.Parse(args[0]);
			short y = short.Parse(args[1]);

			Console.WriteLine("Income in no-risk scheme  : {0:0.00}", GetIncome(a, y, false));
			Console.WriteLine("Income in high-risk scheme: {0:0.00}", GetIncome(a, y, true));
		}
		else
		{
			(double a, double i) = GetIncome(1);
			Console.WriteLine("Annual income on safe investment of amount {0:0.00} will be {1:0.00}", a, i);
		}

	}

}