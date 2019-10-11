using System;
using System.Threading.Tasks;

class Translator
{
	private int level;

	internal Translator(int l)
	{
		level = l;
	}

	public string Translate(object source)
	{
		Worker.DoWork(level);

		return source.ToString().ToUpper();
	}
	
}

static class Program
{
	public static void Main()
	{
		Console.Write("Part (1/2): ");
		string p1 = Console.ReadLine();
		Translator t1 = new Translator(90);
		//string r1 = t1.Translate(p1);
		Task<string> r1 = Task<string>.Factory.StartNew(t1.Translate, p1);

		Console.Write("Part (2/2): ");
		string p2 = Console.ReadLine();
		Translator t2 = new Translator(60);
		//string r2 = t2.Translate(p2);
		Task<string> r2 = Task<string>.Factory.StartNew(t2.Translate, p2);

		//string r = r1 + " AND " + r2;
		string r = r1.Result + " AND " + r2.Result;

		Console.WriteLine("Result = {0}", r);
	}
}