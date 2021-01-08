using Banking;
using System;

static class Program
{
	static void Main(string[] args)
	{
		var jack = Banker.OpenCurrentAccount();
		jack.Deposit(15000);

		var jill = Banker.OpenSavingsAccount();
		jill.Deposit(10000);

		try
		{
			decimal payment = decimal.Parse(args[0]);
			jill.Transfer(payment, jack);
			Console.WriteLine("Payment transferred.");
		}
		catch(InsufficientFundsException)
		{
			Console.WriteLine("Payment transfer failed due to lack of funds!");
		}
		catch(Exception ex)
		{
			Console.WriteLine("Input Error: {0}", ex.Message);
		}

		Console.WriteLine($"Jack's Account ID is {jack.Id} and Balance is {jack.Balance}");
		Console.WriteLine($"Jill's Account ID is {jill.Id} and Balance is {jill.Balance}");
	}
}
