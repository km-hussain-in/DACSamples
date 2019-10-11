using System;
using System.IO;
using System.Net;

static class Program
{
	public static void Main(string[] args)
	{
		string url = $"http://localhost:8010/shop?item={args[0]}";
		WebClient client = new WebClient();

		try
		{
			Stream content = client.OpenRead(url);
			StreamReader reader = new StreamReader(content);
			string text = reader.ReadLine();
			string[] tokens = text.Split('&');
			Console.WriteLine(tokens[0]);
			Console.WriteLine(tokens[1]);
			reader.Close();
		}
		catch(WebException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
