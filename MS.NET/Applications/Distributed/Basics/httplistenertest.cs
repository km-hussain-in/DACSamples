using System;
using System.IO;
using System.Net;

static class Program
{
	public static void Main()
	{
		string[] items = {"cpu", "ram", "hdd", "motherboard", "keyboard", "mouse", "monitor"};
		double[] prices = {12000, 2000, 4500, 8000, 1500, 600, 7500};
		int[] stocks = {100, 500, 90, 100, 50, 50, 20};

		HttpListener server = new HttpListener();
		server.Prefixes.Add("http://*:8010/shop/");
		server.Start();

		for(;;)
		{
			HttpListenerContext client = server.GetContext();
			StreamWriter writer = new StreamWriter(client.Response.OutputStream);
			string item = client.Request.QueryString["item"];
			int i = Array.IndexOf(items, item);
			if(i >= 0)
			{
				client.Response.ContentType = "text/plain";
				writer.WriteLine("Price={0}&Stock={1}", prices[i], stocks[i]);
			}	
			else
				client.Response.StatusCode = 404;
			writer.Close();
					
		}
	}
}
