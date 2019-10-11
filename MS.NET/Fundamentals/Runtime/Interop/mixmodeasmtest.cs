using System;

static class Program
{
	public static void Main(string[] args)
	{
		var emp = new IjwTaxation.LegacyTaxPayer();
		emp.Income = double.Parse(args[0]);
		short age = short.Parse(args[1]);
		Console.WriteLine("Income tax = {0:0.00}", emp.GetIncomeTax(age));
	}
}