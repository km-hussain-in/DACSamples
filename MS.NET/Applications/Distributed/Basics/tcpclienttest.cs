using System;
using System.IO;
using System.Net.Sockets;

static class Program
{
	public static void Main(string[] args)
	{
		string server = args.Length > 1 ? args[1] : "localhost";
		TcpClient client = new TcpClient(server, 4010);

		Stream strm = client.GetStream();
		StreamReader reader = new StreamReader(strm);
		StreamWriter writer = new StreamWriter(strm);

		Console.WriteLine(reader.ReadLine());
		writer.WriteLine(args[0]);
		writer.Flush();
		string response = reader.ReadLine();
		if(response != null)
		{
			string[] tokens = response.Split('&');
			Console.WriteLine(tokens[0]);
			Console.WriteLine(tokens[1]);
		}		
		else
			Console.WriteLine("Item not available!");

		writer.Close();
		reader.Close();
		client.Close();
	}
}
