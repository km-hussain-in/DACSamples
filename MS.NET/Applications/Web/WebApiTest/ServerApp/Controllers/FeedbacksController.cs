using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerApp.Controllers
{
    using Models;

    public class FeedbacksController : ApiController
    {
        private Document<Feedback> model = Document.Open<Feedback>("survey.xml");

        public IEnumerable<Feedback> Get()
        {
            return model.ToList();
        }

        public IHttpActionResult Get(string id)
        {
            Feedback output = model.Find(e => e.Name == id);

            if (output != null)
                return Ok(output);

            return NotFound();
        }

        public string Post(Feedback input)
        {
            string result;

            Feedback feedback = model.Find(e => e.Name == input.Name);
            if(feedback == null)
            {
                model.Add(input);
                result = "Accepted";
            }
            else
            {
                feedback.Text = input.Text;
                feedback.Rank = input.Rank;
                result = "Revised";
            }

            model.Save();

            return result;
        }
    }
}
