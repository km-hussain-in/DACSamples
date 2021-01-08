using System;
using System.IO;
using System.Net.Sockets;

static class Program
{
	public static void Main(string[] args)
	{
		string item = args[0].ToLower();
		int quantity = args.Length > 1 ? int.Parse(args[1]) : 1;
		string host = args.Length > 2 ? args[2] : "localhost";

		var client = new TcpClient(host, 4000);
		var exchange = client.GetStream();
		var reader = new StreamReader(exchange);
		var writer = new StreamWriter(exchange);
		
		Console.WriteLine(reader.ReadLine());
		writer.WriteLine(item);
		writer.Flush();
		string response = reader.ReadLine();
		if(response != null)
		{
			string[] info = response.Split('&');
			double price = double.Parse(info[0].Substring(6));
			int stock = int.Parse(info[1].Substring(6));
			if(quantity <= stock)
				Console.WriteLine("Total payment: {0:0.00}", quantity * price);
			else
				Console.WriteLine("Out of stock!");
		}
		else
		{
			Console.WriteLine("Not available!");
		}

		writer.Close();
		reader.Close();
		client.Close();
	}
}
