using System;
using System.Threading;

class JointAccount
{
	public int Balance {get; private set;}

	public void Deposit(int amount)
	{
		lock(this)
		{
			Worker.DoWork(amount / 1000);
			Balance += amount;
		}
	}

	public bool Withdraw(int amount)
	{
		bool success = false;

		Monitor.Enter(this);
		if(Balance >= amount)
		{
			Worker.DoWork(amount / 1000);
			Balance -= amount;
			success = true;
		}
		Monitor.Exit(this);

		return success;
	}
	
}

static class Program
{
	public static void Main(string[] args)
	{
		var acc = new JointAccount();
		acc.Deposit(5000);

		Console.WriteLine("Joint account opened for Jack and Jill");
		Console.WriteLine("Initial Balance: {0}", acc.Balance);

		var child = new Thread(() =>
		{
			Console.WriteLine("Jack is withdrawing 3000 from this account");
			if(!acc.Withdraw(3000))
				Console.WriteLine("Jack's transaction failed!");
		});
		child.Start();

		Console.WriteLine("Jill is withdrawing 4000 from this account");
		if(!acc.Withdraw(4000))
			Console.WriteLine("Jill's transaction failed!");

		child.Join(); // wait for child to exit

		Console.WriteLine("Final Balance: {0}", acc.Balance);
		

	}
}
