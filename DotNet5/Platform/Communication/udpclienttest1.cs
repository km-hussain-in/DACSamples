using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		string[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random gen = new Random();

		var publisher = new UdpClient("230.0.0.1", 4000);

		for(;;)
		{
			int i = gen.Next(0, symbols.Length);
			double price = 0.01 * gen.Next(1000, 10000);
			string msg = $"{symbols[i]} - {price:0.00}";
			byte[] data = Encoding.UTF8.GetBytes(msg);
			publisher.Send(data, data.Length);
			System.Threading.Thread.Sleep(10000);
		}

	}
}
