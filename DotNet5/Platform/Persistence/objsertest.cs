using Tourism;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		var model = new SiteModel();
		Site zoo = model.Sites.Find(s => s.Title == "CityZoo");
		if(zoo == null)
		{
			zoo = new Site {Title = "CityZoo"};
			model.Sites.Add(zoo);
		}


		if(args.Length > 0)
		{
			zoo.RegisterVisit(args[0]);
			model.SaveChanges();
		}
		else
		{			
			Console.WriteLine("Visitors of {0}", zoo.Title);
			foreach(var entry in zoo.Visitors)
				Console.WriteLine(entry);
		}
	}
}
