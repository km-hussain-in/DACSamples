using System;

static class Program
{
	public static void Main(string[] args)
	{
		double w = double.Parse(args[0]);
		double d = double.Parse(args[1]);
		Type t = Type.GetTypeFromProgID("METLogistics.AirCargo");
		dynamic cargo = Activator.CreateInstance(t);

		Console.WriteLine("Tariff: {0:0.00}", cargo.QuoteTariff(w, d)); //DLR will use IDispatch to forward the call
		Console.WriteLine("Time  : {0:0.0}", cargo.EstimateTime(d));
	}
}
