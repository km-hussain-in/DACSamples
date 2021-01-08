using System;

interface IConsumer : IDisposable
{
	void Apply(int action); 

	void ApplyAll(int first, int last)
	{
		for(int action = first; action <= last; ++action)
			Apply(action);
	}
}

interface IRestore
{
	void Apply(int action);
}

class Resource : IConsumer, IRestore
{
	private string id;

	public Resource(string name)
	{
		id = name;
		Console.WriteLine($"{id} resource acquired");
	}

	//explicit interface implementation
	void IConsumer.Apply(int action)
	{
		if(id != null)
			Console.WriteLine($"{id} resource consumed with action<{action}>");
	}

	void IRestore.Apply(int action) 
	{
		if(id != null)
			Console.WriteLine($"{id} resource restored from action<{action}>");
	}

	void IDisposable.Dispose()
	{
		if(id != null)
			Console.WriteLine($"{id} resource released");
		id = null;
	}
}

static class Program
{
	private static void Run(string cmd)
	{
		using(IConsumer b = new Resource("Second"))
		{
			b.ApplyAll(1, int.Parse(cmd)); 
		}
	}

	public static void Main(string[] args)
	{
		IConsumer a = new Resource("First");
		a.Apply(1);
		IRestore ra = (IRestore)a;
		ra.Apply(1);
		a.Dispose();
		
		try
		{
			Run(args[0]);
		}
		catch {}
	}
}