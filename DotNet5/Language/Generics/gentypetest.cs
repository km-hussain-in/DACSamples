using System;

class SimpleStack<V>
{
	//nested class - can only refer to static members of outer class
	class Node
	{
		internal V value;
		internal Node below;

		internal Node(V v, Node n) => (value, below) = (v, n);
	}

	private Node top;

	public void Push(V val)
	{
		top = new Node(val, top);
	}

	public V Pop()
	{
		V val = top.value;
		top = top.below;
		return val;
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
		SimpleStack<string> s = new SimpleStack<string>();
		s.Push("Monday");
		s.Push("Tuesday");
		s.Push("Wednesday");
		s.Push("Thursday");
		s.Push("Friday");
		s.Push(null);

		var d = new SimpleStack<double?>(); //new SimpleStack<Nullable<double>>();
		d.Push(23.1);
		d.Push(45.2);
		d.Push(11.3);
		d.Push(37.4);
		d.Push(19.5);
		d.Push(52.6);
		d.Push(null);
		
		while(!s.Empty())
			Console.WriteLine(s.Pop());
		Console.WriteLine("---------------");

		while(!d.Empty())
			Console.WriteLine(d.Pop() ?? -1);
	}
}

