using System;
using System.Dynamic;

class FormalGreeter
{
	public string Meet(string name) => $"Hello {name}.";

	public string Leave(string name) => $"Goodbye {name}.";
}

class CasualGreeter : DynamicObject
{
	public string Meet(string name) => $"Hi {name}.";

	public string Leave(string name) => $"Bye {name}.";

	public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
	{
		if(arguments.Length == 1)
		{
			result = $"{method.Name} you, {arguments[0]}!";
			return true;
		}

		result = null;			
		return false;
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		Type t = Type.GetType(args[0]);
		dynamic g = Activator.CreateInstance(t);

		Console.WriteLine(g.Meet("Jack")); //DLR binding - duck typing
		Console.WriteLine(g.Leave("Jack"));

		try
		{
			Console.WriteLine(g.Kill("Jack"));
		}
		catch(Exception ex)
		{
			Console.WriteLine("Error: {0}", ex.Message);
		}
	}
}
