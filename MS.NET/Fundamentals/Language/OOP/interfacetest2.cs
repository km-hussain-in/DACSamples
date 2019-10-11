using System;

interface IConsumer
{
	void Apply(int action);
}

static class Consumers
{
	//extension method - a method of a static class which can be invoked
	//as an instance method of its this qualified first parameter type
	public static void ApplyAll(this IConsumer that, int actions)
	{
		for(int i = 1; i <= actions; ++i)
			that.Apply(i);
	}

}

class ResourceConsumer : IConsumer, IDisposable
{
	private string id;

	public ResourceConsumer(string name)
	{
		id = name;
		Console.WriteLine("{0} resource acquired", id);
	}

	//implicit interface implementation
	public void Apply(int action)
	{
		if(id != null)
			Console.WriteLine("Action<{0}> applied to {1} resource", action, id);
	}


	public void Dispose()
	{
		Console.WriteLine("{0} resource released", id);
		id = null;
	}	
}

static class Program
{
	private static void Run(string cmd)
	{
		using(var b = new ResourceConsumer("Second"))
		{
			b.ApplyAll(int.Parse(cmd)); //Consumers.ApplyAll(b, ...)
		}
	}

	public static void Main(string[] args)
	{
		var a = new ResourceConsumer("First");
		a.Apply(23);
		a.Dispose();

		try
		{
			Run(args[0]);
		}
		catch {}
	}
}
