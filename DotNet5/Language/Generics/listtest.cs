using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IList<Interval> store = new List<Interval>();
		store.Add(new Interval(5, 31));
		store.Add(new Interval(3, 42));
		store.Add(new Interval(7, 23));
		store.Add(new Interval(6, 14));
		store.Add(new Interval(4, 55));
		store.Add(new Interval(5, 74));

		foreach(var i in store)
			Console.WriteLine(i);
		
		Console.WriteLine("Third Interval = {0}", store[2]);
	}
}
