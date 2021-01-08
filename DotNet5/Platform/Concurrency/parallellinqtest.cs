using System;
using System.Linq;

static class Program
{
	public static void Main()
	{
		var sequence = Enumerable.Range(1, 20);

		int t1 = Environment.TickCount;
		var r = (from n in sequence.AsParallel() select Worker.DoWork(n)).Sum();
		int t2 = Environment.TickCount;

		Console.WriteLine("Result = {0}, computed in {1:0.0} seconds.", r, (t2 - t1) / 1000.0);
	}
}
