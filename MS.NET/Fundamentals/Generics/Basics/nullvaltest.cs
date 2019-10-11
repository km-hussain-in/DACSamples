using System;

static class Program
{
	//private static Nullable<double> GetBalance(string name)
	private static double? GetBalance(string name)
	{
		string[] names = {"jack", "jill", "john", "jane"};
		double[] balances = {9000, 13000, 12000, 8000};
		int i = Array.IndexOf(names, name);

		if(i >= 0)
			return balances[i];

		return null;
	}
	
	public static void Main(string[] args)
	{
		double? bal = GetBalance(args[0]);
		
		if(bal == null)
			Console.WriteLine("Cannot find {0}", args[0]);
		else
			Console.WriteLine("Balance = {0}", bal);
		
		Console.WriteLine("Interest = {0}", 0.04 * (bal ?? 0));
	}
}
