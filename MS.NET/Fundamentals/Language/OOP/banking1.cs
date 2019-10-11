using System;

namespace Banking
{
	public class InsufficientFundsException : ApplicationException {}

	//non-activatable (must inherit) class
	public abstract class Account
	{
		public int Id {get; internal set;}

		public double Balance {get; protected set;}

		//pure (must override) method
		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(!ReferenceEquals(this, that))
			{
				this.Withdraw(amount);
				that.Deposit(amount);
			}	
		}
	}

	//non-inheritable class
	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			if(Balance < 0)
				amount *= 0.9;
			Balance += amount;		
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account
	{
		const double MinBalance = 5000;

		internal SavingsAccount()
		{
			Balance = MinBalance;
		}

		public override void Deposit(double amount)
		{	
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinBalance)
				throw new InsufficientFundsException();
			Balance -= amount;
		}
	}

	public static class Banker
	{
		private static int nid;

		static Banker()
		{
			nid = Environment.TickCount % 1000000;
		}

		public static Account OpenCurrentAccount()
		{
			var acc = new CurrentAccount();
			acc.Id = 10000000 + nid++;
			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			var acc = new SavingsAccount();
			acc.Id = 20000000 + nid++;
			return acc;
		}

	}

}

