using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group)
		{
			total += emp.GetIncome();
		}

		return total / group.Length;
	}

	private static double GetTotalBonus(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group)
		{
			if(emp is SalesPerson)
				total += 3000;
			else
				total += 5000;			
		}

		return total;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group)
		{
			SalesPerson sp = emp as SalesPerson;
			if(sp != null)
				total += sp.Sales;
		}

		return total;
	}


	public static void Main()
	{
		Employee[] department = new Employee[5];
		department[0] = new Employee(186, 52);
		department[1] = new Employee(175, 225);
		department[2] = new SalesPerson(190, 45, 62000);
		department[3] = new Employee(195, 65);
		department[4] = new SalesPerson(178, 48, 38000);

		Console.WriteLine("Average Income: {0:0.00}", GetAverageIncome(department));
		Console.WriteLine("Total Bonus   : {0:0.00}", GetTotalBonus(department));
		Console.WriteLine("Total Sales   : {0:0.00}", GetTotalSales(department));

	}
}

