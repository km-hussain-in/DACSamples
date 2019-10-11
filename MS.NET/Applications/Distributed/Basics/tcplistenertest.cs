using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		//Step 1: start a listener socket on a wellknown endpoint
		TcpListener listener = new TcpListener(IPAddress.Any, 4010);
		listener.Start();

		//Communicate(listener);

		for(int i = 0; i < 3; ++i)
		{
			var servant = new System.Threading.Thread(delegate()
			{
				Communicate(listener);
			});
			servant.Start();
		}
	}

	private static void Communicate(TcpListener server)
	{
		string[] items = {"cpu", "ram", "hdd", "motherboard", "keyboard", "mouse", "monitor"};
		double[] prices = {12000, 2000, 4500, 8000, 1500, 600, 7500};
		int[] stocks = {100, 500, 90, 100, 50, 50, 20};

		for(;;)
		{
			//Step 2: accept remote client's socket
			TcpClient client = server.AcceptTcpClient();
			client.ReceiveTimeout = 30000;

			//Step 3: exchange data with the client using streams
			Stream strm = client.GetStream();
			StreamReader reader = new StreamReader(strm);
			StreamWriter writer = new StreamWriter(strm);
			writer.AutoFlush = true;

			try
			{
				writer.WriteLine("Welcome to our shop");
				string item = reader.ReadLine();
				int i = Array.IndexOf(items, item.ToLower());
				if(i >= 0)
					writer.WriteLine("Price={0}&Stock={1}", prices[i], stocks[i]);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Communication failure: {0}", ex.Message);
			}

			writer.Close();
			reader.Close();

			//Step 4: disconnect the client and go to step 2
			client.Close();

		}
	}
}
