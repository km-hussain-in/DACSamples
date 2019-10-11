using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Visitor
    {
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string Name { get; set; }

        public int Frequency { get; set; } = 1;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Recent { get; set; } = DateTime.Now;

        public void Revisit()
        {
            Frequency += 1;
            Recent = DateTime.Now;
        }

    }

    public class VisitorModel
    {
        private Document<Visitor> doc = Document.Open<Visitor>("visitors.xml");

        public Visitor[] ReadVisitors()
        {
            return doc.ToArray();
        }

        public void WriteVisitor(string id)
        {
            Visitor visitor = doc.Find(v => v.Name == id);

            if (visitor == null)
                doc.Add(new Visitor { Name = id });
            else
                visitor.Revisit();

            doc.Save();
        }
    }
}
