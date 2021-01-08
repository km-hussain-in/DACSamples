using System;
using System.Threading;
using System.Threading.Tasks;

class Computation
{

	public long Compute(int low, int high)
	{
		long result = 0;

		for(int value = low; value <= high; ++value)
		{
			Worker.DoWork(value);
			result += value;
		}

		return result;
	}

	public Task<long> ComputeAsync(int low, int high)
	{
		return Task<long>.Run(() => Compute(low, high));
	}
}

static class Program
{
	/*
	private static Task DoComputation()
	{
		Console.Write("Computing...");
		var c = new Computation();
		
		return c.ComputeAsync(1, 20)
			.ContinueWith(t =>
			{
				long r = t.Result;
				Console.WriteLine("Done!");
				Console.WriteLine("Result = {0}", r);
			});
	}
	*/

	private static async Task DoComputation()
	{
		Console.Write("Computing...");
		var c = new Computation();
		long r = await c.ComputeAsync(1, 20);
		Console.WriteLine("Done!");
		Console.WriteLine("Result = {0}", r);
	}

	public static void Main()
	{
		var job = DoComputation();
		while(!job.IsCompleted)
		{
			Console.Write(".");
			Thread.Sleep(500);
		}
	}
}
