using System;

static class Program
{
	private static object Select(int selector, object first, object second)
	{
		if((selector % 2) == 1)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		int s = int.Parse(args[0]);

		string ss = (string)Select(s, "Monday", "Friday");
		Console.WriteLine($"Selected string = {ss}");

		double sd = (double)Select(s, 9.75, 3.25);
		Console.WriteLine($"Selected double = {sd}");

		int si = (int)Select(s, 1234, "abcd");
		Console.WriteLine($"Selected int = {si}");


	}
}
