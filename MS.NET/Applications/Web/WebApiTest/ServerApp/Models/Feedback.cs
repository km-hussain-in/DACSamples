using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApp.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Feedback
    {
        [DataMember(Name = "from")]
        public string Name { get; set; }

        [DataMember(Name = "comment")]
        public string Text { get; set; }

        [DataMember(Name = "rating")]
        public int Rank { get; set; }
    }
}
