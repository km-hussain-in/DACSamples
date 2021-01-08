using System;
using System.IO;
using System.Collections.Generic;
using static System.Text.Encoding;
using static System.Linq.Enumerable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tourism
{
	public class Visitor
	{
		public string Name { get; set; }

		[JsonIgnore]
		public string Password { get; set; }

		public int VisitCount { get; set; }

		public DateTime LastVisit { get; set; }

		public byte[] Secret
		{
			get => Transform(UTF8.GetBytes(Password));
			set => Password = UTF8.GetString(Transform(value));
		}			

		public override string ToString() => $"{Name}({Password})\t{VisitCount}\t{LastVisit}";

		private static byte[] Transform(byte[] data)
		{
			var selection = from b in data select (byte)(b ^ '#');
			return selection.ToArray();
		}

	}

	public class Site
	{
		public string Title { get; set; }

		public List<Visitor> Visitors { get; set; } = new ();

		public void RegisterVisit(string person)
		{
			var entry = Visitors.FirstOrDefault(v => v.Name == person);
			
			if(entry == null)
			{
				entry = new Visitor {Name = person, Password = person.ToLower() + "123"};
				Visitors.Add(entry);
			}	

			entry.VisitCount += 1;
			entry.LastVisit = DateTime.Now;
		}
	}

	public class SiteStore
	{
		public List<Site> Sites { get; set; }

		public SiteStore()
		{
			if(File.Exists("sites.json"))
			{
				string text = File.ReadAllText("sites.json");
				Sites = JsonSerializer.Deserialize<List<Site>>(text);
			}
			else
				Sites = new ();
		}

		public void SaveChanges()
		{
			string text = JsonSerializer.Serialize(Sites, new (){WriteIndented = true});
			File.WriteAllText("sites.json", text);			
		}
	}		

}
