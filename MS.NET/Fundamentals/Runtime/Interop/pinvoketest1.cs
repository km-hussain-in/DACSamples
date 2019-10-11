using System;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport("legacy\\bin\\asset.dll", EntryPoint="DDB")]
	private extern static double GetPriceAfter(double cost, short life, short after);

	public static void Main(string[] args)
	{
		double cost = double.Parse(args[0]);
		short life = short.Parse(args[1]);

		for(short years = 1; years <= life; ++years)
			Console.WriteLine("{0}\t{1:0.00}", years, GetPriceAfter(cost, life, years));
	}
}
