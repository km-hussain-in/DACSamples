using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
	public static void Main(string[] args)
	{
		int min = args.Length > 0 ? int.Parse(args[0]) : 0;
		double dist = args.Length > 1 ? double.Parse(args[1]) : 500;
		List<Interval> source = new List<Interval>
		{
			new Interval(4, 31),
			new Interval(3, 42),
			new Interval(7, 23),
			new Interval(5, 14),
			new Interval(6, 54),
			new Interval(2, 35)
		};

		var selection = from i in source
				where i.Time > min
				orderby i.Seconds
				select new
				{
					Duration = i,
					Speed = 3.6 * dist / i.Time	
				};

		foreach(var entry in selection)
			Console.WriteLine("{0}\t{1:0.000}", entry.Duration, entry.Speed);
	}
}
