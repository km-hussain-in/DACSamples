using System;

static class Program
{
	/*
	private static string Select(int sign, string first, string second)
	{
		if(sign < 0)
			return first;
		return second;
	}

	private static double Select(int sign, double first, double second)
	{
		if(sign < 0)
			return first;
		return second;
	}
	*/

	private static object Select(int sign, object first, object second)
	{
		if(sign < 0)
			return first;
		return second;
	}


	public static void Main(string[] args)
	{
		int s = args.Length > 0 ? int.Parse(args[0]) : 0;
		
		string ss = (string)Select(s, "Monday", "Friday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = (double)Select(s, 7.25, 9.75);
		Console.WriteLine("Selected double = {0}", sd);

		int si = (int)Select(s, 1234, "abcd");
		Console.WriteLine("Selected int = {0}", si);
	}
}

