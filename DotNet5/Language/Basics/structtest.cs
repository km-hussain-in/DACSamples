using System;

struct Box
{
	public int Length;
	public int Breadth;
	public int Height;

	public Box(int l, int b, int h)
	{
		Length = l;
		Breadth = b;
		Height = h;
	}

	public long GetArea()
	{
		return 2 * (Length * Breadth + Breadth * Height + Height * Length);
	}

	public long GetVolume() => Length * Breadth * Height;
}

static class Program
{
	static void Print(string name, Box x)
	{
		Console.WriteLine($"{name} Box = [{x.Length}, {x.Breadth}, {x.Height}]");
	}

	static void Expand(ref Box x)
	{
		x.Length += 1;
		x.Breadth += 1;
		x.Height += 1;
	}

	static bool TryCreateCube(int size, out Box cube)
	{
		cube = new Box();

		if(size < 100)
		{
			cube.Length = cube.Breadth = cube.Height = size;
			return true; 
		}

		return false;
	}

	static void Main(string[] args)
	{
		Box a;
		a.Length = 10;
		a.Breadth = 20;
		a.Height = 30;
		Console.WriteLine("Area of first box is {0} and its volume is {1}", a.GetArea(), a.GetVolume());

		Box b = new Box(25, 20, 15);
		Console.WriteLine("Area of second box is {0} and its volume is {1}", b.GetArea(), b.GetVolume());
		Print("Original Second", b);
		Console.WriteLine("Expanding second box...");
		Expand(ref b);
		Print("Expanded Second", b);

		if(args.Length > 0)
		{
			int s = int.Parse(args[0]);
			if(TryCreateCube(s, out Box c))
				Console.WriteLine("Area of third box is {0} and its volume is {1}", c.GetArea(), c.GetVolume());
			else
				Console.WriteLine("Cannot create third box!");
		}
	}
}
