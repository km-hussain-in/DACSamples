using System;
using System.Threading.Tasks;

class Computation
{
	private int low, high;

	internal Computation(int low, int high)
	{
		this.low = low;
		this.high = high;
	}

	public long Compute()
	{
		long result = 0;

		for(int value = low; value <= high; ++value)
		{
			Worker.DoWork(value);
			result += value;
		}

		return result;
	}
}

static class Program
{
	public static void Main()
	{
		Console.Write("Limit (1/2): ");
		int m = int.Parse(Console.ReadLine()); 
		var c1 = new Computation(1, m);
		//long r1 = c1.Compute();
		var t1 = Task<long>.Run(c1.Compute);

		Console.Write("Limit (2/2): ");
		int n = int.Parse(Console.ReadLine()); 
		var c2 = new Computation(m + 1, n);
		//long r2 = c2.Compute();
		var t2 = Task<long>.Run(c2.Compute);

		//long r = r1 + r2;
		long r = t1.Result + t2.Result;

		Console.WriteLine("Result = {0}", r);
	}
}
