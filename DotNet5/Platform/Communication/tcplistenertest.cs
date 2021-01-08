using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		var listener = new TcpListener(IPAddress.Any, 4000);
		listener.Start();

		for(int i = 0; i < 3; ++i)
		{
			var child = new System.Threading.Thread(() => Communicate(listener));
			child.Start();
		}
	}

	private static void Communicate(TcpListener server)
	{
		string[] items = {"cpu", "hdd", "keyboard", "motherboard", "mouse", "ram"};
		double[] prices = {18000, 4500, 850, 6200, 450, 2400};
		int[] stocks = {25, 38, 150, 25, 120, 65};

		for(;;)
		{
			var client = server.AcceptTcpClient();
			var exchange = client.GetStream(); 
			var reader = new StreamReader(exchange);
			var writer = new StreamWriter(exchange);
			
			client.ReceiveTimeout = 60000;
			writer.AutoFlush = true;
			try
			{
				writer.WriteLine("Welcome to our PC store");
				string item = reader.ReadLine();
				int i = Array.IndexOf(items, item);
				if(i >= 0)
					writer.WriteLine("price={0:0.00}&stock={1}", prices[i], stocks[i]);

			}
			catch(Exception ex)
			{
				Console.WriteLine("Communication Error: {0}", ex.Message);
			}

			writer.Close();
			reader.Close();
			client.Close();
				
		}

		
	}
}
