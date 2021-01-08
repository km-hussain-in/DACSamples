using System;
using System.Collections.Generic;

class SimpleStack<V>
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


	//indexer property
	public V this[int index]
	{
		get
		{
			Node n = top;
			for(int i = 0; n != null; ++i, n = n.below)
				if(i == index) return n.value;

			throw new IndexOutOfRangeException();
		}
	}

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.below)
			yield return n.value;
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		SimpleStack<string> s = new SimpleStack<string>();
		s.Push("Monday");
		s.Push("Tuesday");
		s.Push("Wednesday");
		s.Push("Thursday");
		s.Push("Friday");

		if(args.Length > 0)
		{
			int i = int.Parse(args[0]);
			Console.WriteLine(s[i]);
		}
		else
		{
			foreach(string i in s)
				Console.WriteLine(i);
		}
	}
}

