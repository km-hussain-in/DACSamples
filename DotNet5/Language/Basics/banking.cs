namespace Banking
{
	using System;

	public class InsufficientFundsException : ApplicationException {}

	public abstract class Account
	{
		public long Id { get; internal set; }

		public decimal Balance { get; protected set; }

		public abstract void Deposit(decimal amount);

		public abstract void Withdraw(decimal amount); 

		public void Transfer(decimal amount, Account that)
		{
			if(!ReferenceEquals(this, that))
			{
				this.Withdraw(amount);
				that.Deposit(amount);
			}
		}
	}

	public interface IProfitable
	{
		decimal GetInterest(int months);
	}

	sealed class CurrentAccount : Account
	{
		public override void Deposit(decimal amount)
		{
			if(Balance < 0)
				amount *= 0.9M;
			Balance += amount;
		}

		public override void Withdraw(decimal amount)
		{
			Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account, IProfitable
	{
		const decimal MinBal = 5000;

		internal SavingsAccount()
		{
			Balance = MinBal;
		}

		public override void Deposit(decimal amount)
		{
			Balance += amount;
		}

		public override void Withdraw(decimal amount)
		{
			if(Balance - amount < MinBal)
				throw new InsufficientFundsException();

			Balance -= amount;
		}

		public decimal GetInterest(int months)
		{
			decimal rate = Balance < 3 * MinBal ? 4 : 5;
			
			return Balance * months * rate / 1200;			
		}
	}

	public static class Banker
	{
		private static long nid;

		static Banker()
		{
			nid = DateTime.Now.Ticks % 1000000;
		}

		public static Account OpenCurrentAccount()
		{
			return new CurrentAccount {Id = 100000000 + nid++};
		}

		public static Account OpenSavingsAccount()
		{
			return new SavingsAccount {Id = 200000000 + nid++};
		}

	}

}
