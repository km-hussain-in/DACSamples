using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		var address = IPAddress.Parse("230.0.0.1");
		var subscriber = new UdpClient(4000);
		subscriber.JoinMulticastGroup(address);

		IPEndPoint remote = null;
		for(int i = 0; i < 5; ++i)
		{
			byte[] data = subscriber.Receive(ref remote);
			string msg = Encoding.UTF8.GetString(data);
			Console.WriteLine(msg);
		}

		subscriber.DropMulticastGroup(address);
		subscriber.Close();
	}
}
