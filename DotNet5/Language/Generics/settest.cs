using System;
using System.Collections.Generic;

static class Program
{

	class IntervalSecondsComparer : IComparer<Interval>
	{
		public int Compare(Interval x, Interval y) => x.Seconds - y.Seconds;	
	}

	public static void Main()
	{
		ISet<Interval> store = 
			//new HashSet<Interval>();
			//new SortedSet<Interval>();
			new SortedSet<Interval>(new IntervalSecondsComparer());
		store.Add(new Interval(5, 31));
		store.Add(new Interval(3, 42));
		store.Add(new Interval(7, 23));
		store.Add(new Interval(6, 14));
		store.Add(new Interval(4, 55));
		store.Add(new Interval(5, 74));

		foreach(var i in store)
			Console.WriteLine(i);
	}
}
