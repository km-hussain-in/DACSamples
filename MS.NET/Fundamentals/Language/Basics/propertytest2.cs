using System;

class Customer
{
	//auto property
	public string Name {get; set;}

	//auto property with initializer
	public decimal Credit {get; set;} = 5000;
	
}

static class Program
{
	public static void Main()
	{
		Customer a = new Customer();
		a.Name = "Jack";
		a.Credit = 4000;
		Console.WriteLine("{0}'s credit is {1}", a.Name, a.Credit);
		
		//object initializer
		Customer b = new Customer {Name = "John", Credit = 3000};
		Console.WriteLine("{0}'s credit is {1}", b.Name, b.Credit);

		//implicitly typed local (var=Customer)
		var c = new Customer {Name = "Jill"};
		Console.WriteLine("{0}'s credit is {1}", c.Name, c.Credit);

		//anonymous type	
		var d = new {Id = 23, Score = 63.5};
		Console.WriteLine("Score of student with ID {0} is {1}", d.Id, d.Score);
	}
}
