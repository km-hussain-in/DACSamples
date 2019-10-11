using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = Type.GetType($"Finance.{args[1]},finance");
		object pol = Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = (float)t.InvokeMember(args[2], BindingFlags.InvokeMethod, null, pol, new object[]{p, n});
			float i = r / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));

			Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi); 
		}
	}
}
