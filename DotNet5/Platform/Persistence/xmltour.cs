using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using static System.Text.Encoding;
using static System.Linq.Enumerable;

namespace Tourism
{
	public class Visitor
	{
		[XmlAttribute("Id")]
		public string Name { get; set; }

		[XmlIgnore]
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

	public class SiteModel
	{
		private static XmlSerializer serializer = new (typeof(List<Site>));

		public List<Site> Sites { get; set; }

		public SiteModel()
		{
			if(File.Exists("sites.xml"))
			{
				using var reader = File.OpenText("sites.xml");
				Sites = (List<Site>) serializer.Deserialize(reader);
			}
			else
				Sites = new ();
		}

		public void SaveChanges()
		{
			using var writer = File.CreateText("sites.xml");
			serializer.Serialize(writer, Sites);			
		}
	}		
}
