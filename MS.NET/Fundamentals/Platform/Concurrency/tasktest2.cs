using System;
using System.Threading;
using System.Threading.Tasks;

class Computation
{
	public long Compute(int low, int high)
	{
		long total = 0;

		for(int value = low; value <= high; ++value)
		{
			Worker.DoWork(value);
			total += value * value;
		}

		return total;
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
		
		Computation c = new Computation();
		return c.ComputeAsync(1, 20)
			.ContinueWith(t =>
			{
				long r = t.Result;
				Console.WriteLine("Done!");
				Console.WriteLine("Result = {0}", r);
			});
	}
	*/

	//async modifier - method returns using await statement instead of return statement
	private static async Task DoComputation()
	{
		Console.Write("Computing...");
		
		Computation c = new Computation();
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
