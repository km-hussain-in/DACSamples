using System;

unsafe static class Squaring
{
	public static int SquareOne(double* pVal)
	{
		double value = *pVal;
		if(value > 0)
		{
			*pVal = value * value;
			return 1;
		}
		return 0;
	}
	
	public static double SquareAll(double* values, int count)
	{
		double sum = 0;
		int i;
		for(i = 0; i < count; ++i)
		{
			if(SquareOne(values + i) == 1)
				sum += values[i];
		}
		return sum;
	} 
}

static class Program
{
	public unsafe static void Main()
	{
		double a = 3.5;
		Squaring.SquareOne(&a);	
		Console.WriteLine("Square = {0}", a);

		double[] b = {1.2, 2.3, 3.4, 4.5, 5.6};
		fixed(double* ppb = &b[0])
		{
			double s = Squaring.SquareAll(ppb, 5);
			Console.WriteLine("Sum = {0}", s);
		}	
	}
}
