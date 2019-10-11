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
			
			var writer = new BinaryWriter(new FileStream("product.dat", FileMode.Create));
			writer.Write(price);
			writer.Write(stock);
			writer.Write(item);
			writer.Close();
		}
		else
		{
			var reader = new BinaryReader(new FileStream("product.dat", FileMode.Open));
			float price = reader.ReadSingle();
			short stock = reader.ReadInt16();
			string item = reader.ReadString();
			reader.Close();

			Console.WriteLine("{0} {1} {2}", item, price, stock);		
		}
	
	}
}
