using System;
using System.Linq;

static class Program
{
	public static void Main()
	{
		long result = 0;
		var source = Enumerable.Range(1, 20);
		var clock = new System.Diagnostics.Stopwatch();
		
		clock.Start();
		#if NOPARALLEL
		result = (from n in source select n * Worker.DoWork(n)).Sum();
		#else
		result = (from n in source.AsParallel() select n * Worker.DoWork(n)).Sum();
		#endif
		clock.Stop();

		Console.WriteLine("Result = {0}", result);
		Console.WriteLine("Processing time = {0}", clock.Elapsed);
	}
}
