using System;
using System.Runtime.InteropServices;

static class Program
{
	public static void Main(string[] args)
	{
		double perimeter = double.Parse(args[0]);
		double area = double.Parse(args[1]);
		double a = 1, b = -perimeter / 2, c = area;

		var eqn = new QuadEq.QuadraticEquationClass(); //COM object is activated and its RCW is returned

		if(eqn.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;
			eqn.Solve(a, b, c, out r1, out r2);
			Console.WriteLine("Dimensions = {0}, {1}", r1, r2);
		}
		else
			Console.WriteLine("No such rectangle!");
	}
}