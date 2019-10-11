using System;
using System.Collections.Generic;

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

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.below)
			yield return n.value;
	}
	
}

static class Program
{
	public static void Main()
	{
		int[] a = {1, 4, 9, 16, 25};
		Console.WriteLine("All integers in array");
		foreach(int i in a)
			Console.WriteLine(i);

		SimpleStack<string> b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");
		Console.WriteLine("All strings on stack");
		foreach(string s in b)
			Console.WriteLine(s);
	}
}
