using System;
using System.Reflection;
using RateFunc = System.Func<double, int, float>;

//delegate float RateFunc(double amount, int period);

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = Type.GetType($"Finance.{args[1]},finance");
		object pol = Activator.CreateInstance(t);
		RateFunc rf = (RateFunc)Delegate.CreateDelegate(typeof(RateFunc), pol, args[2]);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = rf(p, n); //rf.Invoke(p, n)
			float i = r / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));

			Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi); 
		}
	}
}
