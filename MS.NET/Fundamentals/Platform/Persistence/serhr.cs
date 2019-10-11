using System;
using System.Collections.Generic;

namespace HR
{
	[Serializable]
	public class Employee
	{

		public string Code {get; set;}

		public int Experience {get; set;}

		public double Salary {get; set;}

		[field:NonSerialized]
		public string Password  {get; set;}		

		public override string ToString() => $"{Code}\t{Password}\t{Experience}\t{Salary}";
	}

	[Serializable]
	public class Department
	{
		public string Title {get; set;}

		public List<Employee> Employees {get; set;} = new List<Employee>();

		public Employee AddEmployee(int exp, double sal){
			Employee emp = new Employee();
			int i = 501 + Employees.Count;
			emp.Code = Title.Substring(0, 3).ToUpper() + i;
			emp.Password = "PWD" + i;
			emp.Experience = exp;
			emp.Salary = sal;
			Employees.Add(emp);
			return emp;
		}

	}

}
