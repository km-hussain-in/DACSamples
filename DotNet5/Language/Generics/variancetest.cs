using System;

interface IStackReader<out V>
{
	V Pop();
	bool Empty();
}

interface IStackWriter<in V>
{
	void Push(V val);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
{
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.below)
			target.Push(n.value);
	}
}

static class Program
{
	public static void PrintStack(IStackReader<object> stack)
	{
		for(int count = 0; !stack.Empty(); ++count)
		{
			if(count > 0)
				Console.Write(", ");
			Console.Write(stack.Pop());
		}

		Console.WriteLine();
	}

	public static void Main()
	{
		SimpleStack<string> s = new SimpleStack<string>();
		s.Push("Monday");
		s.Push("Tuesday");
		s.Push("Wednesday");
		s.Push("Thursday");
		s.Push("Friday");

		SimpleStack<Interval> i = new SimpleStack<Interval>();
		i.Push(new Interval(5, 41));
		i.Push(new Interval(7, 32));
		i.Push(new Interval(4, 53));
		i.Push(new Interval(3, 24));
		i.Push(new Interval(6, 15));
		
		SimpleStack<Interval> j = new SimpleStack<Interval>();
		i.Copy(j);

		SimpleStack<object> a = new SimpleStack<object>();
		a.Push(23.1);
		a.Push(new Interval(2, 30));
		a.Push("Saturday");
		s.Copy(a);
		
		PrintStack(s);
		PrintStack(i);
		PrintStack(j);
		PrintStack(a);
	}
}

