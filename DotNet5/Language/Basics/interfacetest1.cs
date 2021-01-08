using Banking;
using System;

static class Program
{
	static void PayAnnualInterest(Account[] accounts)
	{
		foreach(var acc in accounts)
		{
			var p = acc as IProfitable;
			if(p != null)
			{
				decimal i = p.GetInterest(12);
				acc.Deposit(i);
			}
		}
	}

	static void Main()
	{
		Account[] bank = new Account[5];
		bank[0] = Banker.OpenSavingsAccount();
		bank[0].Deposit(5000);
		bank[1] = Banker.OpenCurrentAccount();
		bank[1].Deposit(20000);
		bank[2] = Banker.OpenSavingsAccount();
		bank[2].Deposit(25000);
		bank[3] = Banker.OpenCurrentAccount();
		bank[3].Deposit(40000);
 		bank[4] = Banker.OpenSavingsAccount();
		bank[4].Deposit(45000);

		PayAnnualInterest(bank);

		foreach(var acc in bank)
			Console.WriteLine($"{acc.Id}\t{acc.Balance:0.00}");

	}
}
