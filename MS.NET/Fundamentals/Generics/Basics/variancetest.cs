using System;

interface IStackReader<out V>
{
	bool Empty();
	V Pop();
}

interface IStackWriter<in V>
{
	void Push(V value);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.below)
			target.Push(n.value);
	}
	
}

class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
{
	private V[] values;
	private int count;

	public FiniteStack(int size)
	{
		values = new V[size];
	}

	public void Push(V value)
	{
		values[count++] = value;
	}

	public V Pop()
	{
		return values[--count];
	}

	public bool Empty()
	{
		return count == 0;
	}
}

static class Program
{
	private static void PrintStack(IStackReader<object> stack)
	{
		for(int i = 0; !stack.Empty(); ++i)
		{
			if(i > 0) Console.Write(", ");
			Console.Write(stack.Pop());
		}

		Console.WriteLine();
	}

	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		FiniteStack<string> b = new FiniteStack<string>(16);
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");
		a.Copy(b);

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
		c.Copy(d);

		PrintStack(a);
		PrintStack(b);
		PrintStack(c);
		PrintStack(d);
	}
}
