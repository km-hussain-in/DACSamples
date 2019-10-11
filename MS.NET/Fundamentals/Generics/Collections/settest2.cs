using System;
using System.Collections.Generic;

static class Program
{
	class IntervalComparison : IComparer<Interval>
	{
		public int Compare(Interval x, Interval y)
		{
			return x.Seconds - y.Seconds;
		}
	}

	public static void Main()
	{
		//ISet<Interval> store = new SortedSet<Interval>();
		ISet<Interval> store = new SortedSet<Interval>(new IntervalComparison());
		store.Add(new Interval(6, 41));
		store.Add(new Interval(7, 32));
		store.Add(new Interval(4, 53));
		store.Add(new Interval(3, 24));
		store.Add(new Interval(5, 15));
		store.Add(new Interval(2, 84));

		foreach(Interval i in store)
			Console.WriteLine(i);
		
	}
}
