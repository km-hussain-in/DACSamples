using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
	
class SimpleStack<V> : IEnumerable<V>
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

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	
}

static class Program
{
	public static void Main()
	{
		var source = new SimpleStack<int>();
		source.Push(31);
		source.Push(52);
		source.Push(63);
		source.Push(74);
		source.Push(45);
		source.Push(26);
		source.Push(17);

		/*
		//imperatively selection squares of odd values in source
		foreach(int n in source)
		{
			if((n % 2) == 1)
				Console.WriteLine(n * n);
		}
		*/

		//declaratively selection squares of odd values in source
		//var selection = source.Where(n => (n % 2) == 1).Select(n => n * n);
		var selection = from n in source where (n % 2) == 1 select n * n;
		foreach(int n in selection)
			Console.WriteLine(n);
		
	}
}
