using System;

static class Program
{
	/*
	private static void PrintAsXml(Payroll.Employee obj)
	{
		Console.WriteLine("<Employee>");
		Console.WriteLine("  <Id>{0}</Id>", obj.Id);
		Console.WriteLine("  <Hours>{0}</Hours>", obj.Hours);
		Console.WriteLine("  <Rate>{0}</Rate>", obj.Rate);
		Console.WriteLine("</Employee>");
	}

	private static void PrintAsXml(Interval obj)
	{
		Console.WriteLine("<Interval>");
		Console.WriteLine("  <Minutes>{0}</Minutes>", obj.Minutes);
		Console.WriteLine("  <Seconds>{0}</Seconds>", obj.Seconds);
		Console.WriteLine("</Interval>");
	}
	*/

	private static void PrintAsXml(object obj)
	{
		Type t = obj.GetType();
		Console.WriteLine("<{0}>", t.Name);
		foreach(var pi in t.GetProperties())
			Console.WriteLine("  <{0}>{1}</{0}>", pi.Name, pi.GetValue(obj));
		Console.WriteLine("</{0}>", t.Name);
	}

	public static void Main()
	{
		PrintAsXml(new Payroll.Employee(186, 52));
		Console.WriteLine();
		PrintAsXml(new Interval(3, 45));		
	}
}
