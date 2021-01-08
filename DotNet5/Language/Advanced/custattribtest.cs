using Finance;
using System;
using RateFunc = System.Func<int, float>;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = args.Length > 1 ? Type.GetType($"Finance.{args[1]},bank") : typeof(PersonalLoan);
		string fn = args.Length > 2 ? args[2] : "UseInterestRate";
		var loan = Activator.CreateInstance(t);
		var rf = (RateFunc)Delegate.CreateDelegate(typeof(RateFunc), loan, fn);
		var mda = (MaxDurationAttribute)Attribute.GetCustomAttribute(t, typeof(MaxDurationAttribute));
		int m = mda?.Limit ?? 10;

		for(int n = 1; n <= m; ++n)
		{
			float i = rf(n) / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi);
		}
	}
}
