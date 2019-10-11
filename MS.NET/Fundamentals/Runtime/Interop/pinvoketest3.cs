using System;
using System.Runtime.InteropServices;

static class Program
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;
		public double Amount;
		public int Period;
	}

	[DllImport(@"legacy\bin\invest.dll")]
	private static extern int InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	delegate float Scheme(int period);

	[DllImport(@"legacy\bin\invest.dll")]
	private static extern double GetMaturityValue(in FixedDeposit fd, Scheme policy);

	
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		FixedDeposit fd;

		InitFixedDeposit(p, n, out fd);
		Console.WriteLine("New fixed-deposit ID is {0}", fd.Id);

		double amount = GetMaturityValue(fd, y => y < 3 ? 5 : 6);
		Console.WriteLine("Maturity-value: {0:0.00}", amount);
	}
}
