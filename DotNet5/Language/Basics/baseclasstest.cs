using Payroll;
using System;

static class Employees
{
	internal static double GetIncomeTax(this Employee that)
	{
		double i = that.GetIncome();
		
		return i > 3500 ? 0.15 * (i - 3500) : 0;
	}

}

static class Program
{

	static double GetAverageIncome(Employee[] group)
	{
		double total = 0;

		foreach(var member in group)
			total += member.GetIncome();

		return total / group.Length;
	}

	static double GetTotalSales(Employee[] group)
	{
		double total = 0;

		foreach(var member in group)
		{
			var sp = member as SalesPerson;
			if(sp != null) 
				total += sp.Sales;
		}

		return total;
	}	
	

	static void Main()
	{
		var jack = new Employee();
		jack.Hours = 50;
		jack.Rate = 58;
		Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.GetIncome(), Employees.GetIncomeTax(jack));

		var jill = new SalesPerson(50, 58, 8600);
		Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.GetIncome(), jill.GetIncomeTax());

		SalesPerson john = new (34, 44, 6400);
		Console.WriteLine("John's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", john.Id, john.GetIncome(), john.GetIncomeTax());

		Console.WriteLine("Number of Employees = {0}", Employee.CountActive());

		Employee[] department = {jack, jill, john};
		Console.WriteLine("Average income = {0:0.00}", GetAverageIncome(department));
		Console.WriteLine("Total sales    = {0:0.00}", GetTotalSales(department));

	}
}
