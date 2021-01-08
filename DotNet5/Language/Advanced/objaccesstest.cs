using System;

static class Program
{
	private static void PrintAsXml(object obj)
	{
		Type t = obj.GetType();
		Console.WriteLine("<{0}>", t.Name);
		foreach(var p in t.GetProperties())
			Console.WriteLine("  <{0}>{1}</{0}>", p.Name, p.GetValue(obj));
		Console.WriteLine("</{0}>", t.Name);
		Console.WriteLine();
	}
	
	public static void Main()
	{
		PrintAsXml(new Interval(3, 45));
		PrintAsXml(new Payroll.Employee(50, 58));
	}
}
