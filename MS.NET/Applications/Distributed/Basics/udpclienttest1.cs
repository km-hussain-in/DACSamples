using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		string[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random rdm = new Random();

		UdpClient publisher = new UdpClient("230.0.0.1", 5010);
		for(;;)
		{
			int i = rdm.Next(0, symbols.Length);
			string text = string.Format("{0} : {1:0.00}", symbols[i], 0.01 * rdm.Next(1000, 10000));
			byte[] message = Encoding.UTF8.GetBytes(text);
			publisher.Send(message, message.Length);
			System.Threading.Thread.Sleep(10000);
		}
	}
}
