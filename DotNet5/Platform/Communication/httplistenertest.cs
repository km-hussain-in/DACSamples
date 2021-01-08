using System;
using System.IO;
using System.Net;

static class Program
{
	public static void Main()
	{
		string[] items = {"cpu", "hdd", "keyboard", "motherboard", "mouse", "ram"};
		double[] prices = {18000, 4500, 850, 6200, 450, 2400};
		int[] stocks = {25, 38, 150, 25, 120, 65};

		var server = new HttpListener();
		server.Prefixes.Add("http://*:5000/shop/");
		server.Start();

		for(;;)
		{
			var client = server.GetContext();
			string item = client.Request.Url.Segments[2];
			var writer = new StreamWriter(client.Response.OutputStream);

			int i = Array.IndexOf(items, item);
			if(i >= 0)
			{
				client.Response.ContentType = "text/plain";
				writer.WriteLine("price={0}&stock={1}", prices[i], stocks[i]);
			}
			else
			{
				client.Response.StatusCode = 404;
			}

			writer.Close();
		}
	}
}

//Windows (Administrator) - netsh http add urlacl url=http://*:5000/ user="NT AUTHORITY\Authenticated Users"