using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		Assembly asm;
		if(args[0].EndsWith(".dll") || args[0].EndsWith(".exe"))
			asm = Assembly.LoadFrom(args[0]);
		else
			asm = Assembly.Load(args[0]);

		foreach(Type t in asm.GetTypes())
			Console.WriteLine(t.Name);

		MethodInfo mi = asm.EntryPoint;
		if(mi?.GetParameters().Length == 0)
			mi.Invoke(null, null);
		
	}
}
