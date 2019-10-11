using System;
using System.Text;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport(@"legacy\bin\hashenc32.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Unicode)]
	private extern static int HashOfString(string str);

	[DllImport(@"legacy\bin\hashenc32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi)]
	private extern static int EncodeBuffer(StringBuilder buf, int sz);

	public static void Main(string[] args)
	{
		Console.WriteLine("Original string = {0}", args[0]);
		Console.WriteLine("Hash of string  = {0:X}", HashOfString(args[0]));

		var buf = new StringBuilder(args[0]);
		EncodeBuffer(buf, buf.Length);
		Console.WriteLine("Encoded string  = {0}", buf);
	}
}
