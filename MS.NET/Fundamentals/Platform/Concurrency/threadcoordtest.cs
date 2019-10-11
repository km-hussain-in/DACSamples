using System;
using System.Threading;

static class Program
{
	private static volatile int value = 0;
	private static object coordinator = new object();
	
	private static void Consume()
	{
		Console.WriteLine("Consumer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);

		//while(value == 0) Thread.Yield();

		lock(coordinator)
		{
			Monitor.Wait(coordinator);
			int result = value * Worker.DoWork(value);
			Console.WriteLine("Processed value = {0}", result);
		}
	}

	private static void Produce()
	{
		Console.WriteLine("Producer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);

		int result = Worker.DoWork();

		lock(coordinator)
		{
			value = result;
			Monitor.Pulse(coordinator);
		}

	}

	public static void Main()
	{
		Thread producer = new Thread(Produce);
		producer.Start();
	
		Thread consumer = new Thread(Consume);
		consumer.Start();

	}
}	