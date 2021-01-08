using System;
using System.IO;
using System.Net;

static class Program
{
	public static void Main(string[] args)
	{
		string item = args[0].ToLower();
		int quantity = args.Length > 1 ? int.Parse(args[1]) : 1;
		string host = args.Length > 2 ? args[2] : "localhost";
		string url = $"http://{host}:5000/shop/{item}";
		var client = new WebClient();

		try
		{
			Stream input = client.OpenRead(url);
			var reader = new StreamReader(input);
			string response = reader.ReadLine();
			string[] info = response.Split('&');
			double price = double.Parse(info[0].Substring(6));
			int stock = int.Parse(info[1].Substring(6));
			if(quantity <= stock)
				Console.WriteLine("Total payment: {0:0.00}", quantity * price);
			else
				Console.WriteLine("Out of stock!");
			reader.Close();
		}
		catch
		{
			Console.WriteLine("Not available!");
		}
	}
}
