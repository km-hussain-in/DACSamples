using HR;
using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Department));
		if(args.Length > 0)
		{
			Department dept = new Department();
			dept.Title = args[0];
			dept.AddEmployee(4, 45000);
			dept.AddEmployee(5, 54000);
			dept.AddEmployee(7, 76000);
			dept.AddEmployee(2, 23000);
			dept.AddEmployee(6, 67000);
			var fs = new FileStream("dept.xml", FileMode.Create);
			serializer.Serialize(fs, dept);	
			fs.Close();
		}
		else
		{
			var fs = new FileStream("dept.xml", FileMode.Open);
			Department dept = (Department)serializer.Deserialize(fs);
			fs.Close();
			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}

