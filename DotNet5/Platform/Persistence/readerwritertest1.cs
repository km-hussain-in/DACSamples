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
			
			var writer = new BinaryWriter(new FileStream("product.dat", FileMode.Create));
			writer.Write(stock);
			writer.Write(price);
			writer.Write(name);
			writer.Close();
		}
		else
		{
			var reader = new BinaryReader(new FileStream("product.dat", FileMode.Open));
			short stock = reader.ReadInt16();
			float price = reader.ReadSingle();
			string name = reader.ReadString();
			reader.Close();
		
			Console.WriteLine("{0} {1} {2}", name, price, stock);
		}
	}
}
