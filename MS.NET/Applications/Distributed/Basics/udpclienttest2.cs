using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		UdpClient subscriber = new UdpClient(5010);
		IPAddress addr = IPAddress.Parse("230.0.0.1");
		subscriber.JoinMulticastGroup(addr);

		IPEndPoint remote = null;
		for(int i = 0; i < 5; ++i)
		{
			byte[] message = subscriber.Receive(ref remote);
			string text = Encoding.UTF8.GetString(message);
			Console.WriteLine(text);	
		}

		subscriber.DropMulticastGroup(addr);
		subscriber.Close();
	}
}
