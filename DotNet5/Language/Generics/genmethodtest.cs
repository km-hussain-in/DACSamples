using System;

static class Program
{
	private static T Select<T>(int selector, T first, T second)
	{
		if((selector % 2) == 1)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		int s = int.Parse(args[0]);

		string ss = Select(s, "Monday", "Friday");
		Console.WriteLine($"Selected string = {ss}");

		double sd = Select(s, 9.75, 3.25);
		Console.WriteLine($"Selected double = {sd}");

		int si = Select(s, 1234, 0xabcd);
		Console.WriteLine($"Selected int = {si}");

	}
}
