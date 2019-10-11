using System;

static class Program
{

	private static T Select<T>(int sign, T first, T second)
	{
		if(sign < 0)
			return first;
		return second;
	}


	public static void Main(string[] args)
	{
		int s = args.Length > 0 ? int.Parse(args[0]) : 0;
		
		string ss = Select(s, "Monday", "Friday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = Select(s, 7.25, 9.75);
		Console.WriteLine("Selected double = {0}", sd);

		//int si = Select(s, 1234, "abcd");

		Interval si = Select(s, new Interval(3, 45), new Interval(2, 30));
		Console.WriteLine("Selected Interval = {0}", si);
	}
}

