using System;

static class Program
{
	private static T Select<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		string ss = Select("Monday", "Friday");
		Console.WriteLine($"Selected string = {ss}");

		double sd = Select(3.25, 9.75);
		Console.WriteLine($"Selected double = {sd}");

		Interval si = Select(new Interval(4, 50), new Interval(3, 40));
		Console.WriteLine($"Selected Interval = {si}");
	}
}
