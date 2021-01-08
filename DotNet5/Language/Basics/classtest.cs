using System;

class Investment
{
	private double amount;
	private short years;
	private bool risky;

	public Investment(double amountVal, short yearsVal)
	{
		amount = amountVal;
		years = yearsVal;
		risky = false;
	}

	public void AllowRisk(bool yes)
	{
		risky = yes;
	}

	public double GetIncome()
	{
		float rate = risky ? 8 : 6;

		return amount * Math.Pow(1 + rate / 100, years) - amount;
	}	
}

static class Program
{
	static void Main(string[] args)
	{
		var a = double.Parse(args[0]);
		var y = short.Parse(args[1]);
		var inv = new Investment(a, y);

		Console.WriteLine("Income in no-risk scheme  : {0:0.00}", inv.GetIncome());
		inv.AllowRisk(true);
		Console.WriteLine("Income in high-risk scheme: {0:0.00}", inv.GetIncome());

	}
}
