using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)
		{
			string name = args[0].ToUpper();
			float price = float.Parse(args[1]);
			short stock = short.Parse(args[2]);
			
			var writer = new StreamWriter(new FileStream("product.txt", FileMode.Create));
			writer.WriteLine(stock);
			writer.WriteLine(price);
			writer.WriteLine(name);
			writer.Close();
		}
		else
		{
			var reader = new StreamReader(new FileStream("product.txt", FileMode.Open));
			short stock = short.Parse(reader.ReadLine());
			float price = float.Parse(reader.ReadLine());
			string name = reader.ReadLine();
			reader.Close();
		
			Console.WriteLine("{0} {1} {2}", name, price, stock);
		}
	}
}
