using System;

class SimpleStack<V>
{
	class Node
	{
		internal V value;
		internal Node below;

		internal Node(V v, Node n)
		{
			value = v;
			below = n;
		}
	}

	private Node top;

	public void Push(V value)
	{
		top = new Node(value, top);	
	}

	public V Pop()
	{
		Node n = top;
		top = top.below;
		return n.value;
	}

	public bool Empty()
	{
		return top == null;
	}

	
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		SimpleStack<string> b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");

		SimpleStack<Interval> c = new SimpleStack<Interval>();
		c.Push(new Interval(5, 31));
		c.Push(new Interval(6, 52));
		c.Push(new Interval(4, 13));
		c.Push(new Interval(7, 24));
		c.Push(new Interval(3, 45));

		SimpleStack<object> d = new SimpleStack<object>();
		d.Push("Sunday");
		d.Push(12.3);
		d.Push(new Interval(2, 30));

		while(!a.Empty())
			Console.WriteLine(a.Pop());
		Console.WriteLine("----------------------");

		while(!b.Empty())
			Console.WriteLine(b.Pop());
		Console.WriteLine("----------------------");

		while(!c.Empty())
			Console.WriteLine(c.Pop());
		Console.WriteLine("----------------------");

		while(!d.Empty())
			Console.WriteLine(d.Pop());



	}
}
