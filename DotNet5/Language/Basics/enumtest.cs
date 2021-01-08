using System;

enum RiskLevel {None, Low, High}

class Investment
{
	private double amount;
	private short years;
	private RiskLevel risk;

	public Investment(double amountVal, short yearsVal)
	{
		amount = amountVal;
		years = yearsVal;
		risk = RiskLevel.None;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes ? RiskLevel.High : RiskLevel.None;
	}

	public void AdjustRisk(RiskLevel level)
	{
		risk = level;
	}

	public double GetIncome()
	{
		float rate;
		switch(risk)
		{
			case RiskLevel.High:
				rate = 8;
				break;
			case RiskLevel.Low:
				rate = 7;
				break;
			default:
				rate = 6;
				break;
		}

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
		inv.AdjustRisk(RiskLevel.Low);
		Console.WriteLine("Income in low-risk scheme : {0:0.00}", inv.GetIncome());
	}
}
