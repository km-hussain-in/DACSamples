using System;

struct Rectangle
{
	private int length;
	private int breadth;

	public Rectangle(int l, int b)
	{
		length = l;
		breadth = b;
	}

	//property - methods which can be called using field-access syntax
	public int Length
	{
		get
		{
			return length;
		}

		set
		{
			length = value;
		}
	}

	public int Breadth
	{
		get => breadth;
		set => breadth = value;
	}

	//read-only property
	public int Perimeter
	{
		get => 2 * (length + breadth);
	}

	public int Area => length * breadth;
}

static class Program
{
	public static void Main()
	{
		Rectangle r = new Rectangle(50, 40);

		Rectangle s = new Rectangle();
		s.Length = s.Breadth = r.Length;

		Console.WriteLine($"Perimeter of first rectangle = {r.Perimeter}");
		Console.WriteLine($"Area of second rectangle = {s.Area}");
	}
}
