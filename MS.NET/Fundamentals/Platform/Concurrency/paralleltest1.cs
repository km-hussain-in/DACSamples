using System;
using System.Threading.Tasks;

static class Program
{
	public static void Main()
	{
		long result = 0;
		var clock = new System.Diagnostics.Stopwatch();
		
		clock.Start();
		#if NOPARALLEL
		for(int value = 1; value < 21; ++value)
		{
			Worker.DoWork(value);
			result += value * value;
		}
		#else
		Parallel.For(1, 21, value => 
		{
			Worker.DoWork(value);
			result += value * value;
		});
		#endif
		clock.Stop();

		Console.WriteLine("Result = {0}", result);
		Console.WriteLine("Processing time = {0}", clock.Elapsed);
	}
}
