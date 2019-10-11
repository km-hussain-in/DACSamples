using System;
using System.Threading;

static class Program
{
	[ThreadStatic]
	private static string client;

	private static void HandleJob(int id)
	{
		Console.WriteLine("Worker<{0}> has accepted job<{1}> for client<{2}>", Thread.CurrentThread.ManagedThreadId, id, client);
		Worker.DoWork(id);
		Console.WriteLine("Worker<{0}> has finished job<{1}> for client<{2}>", Thread.CurrentThread.ManagedThreadId, id, client);
	}

	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? int.Parse(args[0]) : 4;

		Thread child = new Thread(delegate()
		{
			client = "Jack";
			HandleJob(n);
		});
		child.IsBackground = n > 8;
		child.Start();

		client = "Jill";
		HandleJob(5);
	}
}
