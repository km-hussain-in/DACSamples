using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)
		{
			string item = args[0];
			float price = float.Parse(args[1]);
			short stock = short.Parse(args[2]);
			
			var writer = new StreamWriter(new FileStream("product.txt", FileMode.Create));
			writer.WriteLine(price);
			writer.WriteLine(stock);
			writer.WriteLine(item);
			writer.Close();
		}
		else
		{
			var reader = new StreamReader(new FileStream("product.txt", FileMode.Open));
			float price = float.Parse(reader.ReadLine());
			short stock = short.Parse(reader.ReadLine());
			string item = reader.ReadLine();
			reader.Close();

			Console.WriteLine("{0} {1} {2}", item, price, stock);		
		}
	
	}
}
