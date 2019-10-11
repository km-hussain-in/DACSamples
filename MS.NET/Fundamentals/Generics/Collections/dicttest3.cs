using System;
using System.Collections.Generic;

static class Program
{
	public static void Main(string[] args)
	{
		IDictionary<string, Interval> store = new SortedDictionary<string, Interval>();
		store.Add("monday", new Interval(6, 41));
		store.Add("tuesday", new Interval(7, 32));
		store.Add("wednesday", new Interval(4, 53));
		store.Add("thursday", new Interval(3, 24));
		store.Add("friday", new Interval(5, 15));

		if(args.Length == 0)
		{
			foreach(var i in store)
				Console.WriteLine("{0, -12}{1}", i.Key, i.Value);
		}
		else
		{
			string key = args[0].ToLower();
			if(store.TryGetValue(key, out Interval val))
			{
				Console.WriteLine("Value = {0}", val);
			}
			else
			{
				Console.WriteLine("Cannot find {0}", key);
			}
		}		
	}
}
