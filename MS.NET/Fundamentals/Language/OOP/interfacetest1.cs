using Banking;
using static Banking.Banker; //bring static members of Banker into current scope
using System;

static class Program
{
	private static void PayAnnualInterest(Account[] accounts)
	{
		foreach(Account acc in accounts)
		{
			IProfitable p = acc as IProfitable;
			if(p != null)
			{
				double interest = p.GetInterest(12);
				acc.Deposit(interest);
			}
		}
	}

	public static void Main()
	{
		Account[] bank = new Account[5];
		bank[0] = OpenSavingsAccount();
		bank[0].Deposit(5000);
		bank[1] = OpenCurrentAccount();
		bank[1].Deposit(20000);
		bank[2] = OpenSavingsAccount();
		bank[2].Deposit(25000);
		bank[3] = OpenCurrentAccount();
		bank[3].Deposit(40000);
		bank[4] = OpenSavingsAccount();
		bank[4].Deposit(45000);

		PayAnnualInterest(bank);

		foreach(Account acc in bank)
			Console.WriteLine("{0}\t{1:0.00}", acc.Id, acc.Balance);

	}
}