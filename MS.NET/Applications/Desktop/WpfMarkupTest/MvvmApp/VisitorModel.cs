using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp
{
    public class Visitor
    {
        public string Name { get; set; }

        public int Frequency { get; set; } = 1;

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
