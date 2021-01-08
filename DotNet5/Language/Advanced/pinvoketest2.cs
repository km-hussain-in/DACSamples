using System;
using System.Runtime.InteropServices;

static class Program
{
	struct FixedDeposit
	{
		public int Id;

		public double Amount;

		public short Period;
	}	


	[DllImport("bizcalc")]
	private extern static bool FixedDepositInit(double amount, short period, out FixedDeposit fd);

	delegate float PolicyFunc(short period);

	[DllImport("bizcalc")]
	private extern static double FixedDepositMaturityValue(in FixedDeposit fd, PolicyFunc policy);


	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		short n = short.Parse(args[1]);

		if(FixedDepositInit(p, n, out FixedDeposit fd))
		{
			Console.WriteLine("New fixed-deposit ID: {0}", fd.Id);
			double mv = FixedDepositMaturityValue(fd, y => y < 3 ? 6 : 7);
			Console.WriteLine("Maturity value: {0:0.00}", mv);
		}
	}
}
