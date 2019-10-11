using System;

class Interval
{
	private int min, sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
	}

	public int Time => 60 * min + sec;

	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", min, sec);
	}

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.min, lhs * rhs.sec);	
	}

	public static Interval operator++(Interval val)
	{
		return new Interval(val.min, val.sec + 1);
	}

	//indexer property	
	public int this[int index]
	{
		get
		{
			return index == 0 ? sec : min;
		}
	}
}


static class Program
{
	public static void Main()
	{
		Interval a = new Interval(3, 45);
		a.Print();
	
		Interval b = new Interval(3, 80);
		b.Print();

		Interval c = a + b;
		c.Print();

		Interval d = 3 * a;
		d.Print();

		//Interval e = ++b;
		Interval e = b++;
		b.Print();
		Console.WriteLine("{0} minutes and {1} seconds", e[1], e[0]);
	}
}
