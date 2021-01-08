using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		using(var input = new FileStream(args[0], FileMode.Open))
		{
			using(var output = new FileStream(args[1], FileMode.CreateNew))
			{
				byte[] buffer = new byte[80];
				while(input.Position < input.Length)
				{
					int n = input.Read(buffer, 0, 80);
					for(int i = 0; i < n; ++i)
						buffer[i] = (byte)(buffer[i] ^ '#');
					output.Write(buffer, 0, n);
				}
			}
		}
	}
}
