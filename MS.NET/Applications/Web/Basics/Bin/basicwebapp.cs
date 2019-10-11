using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
	public class HtmxToHtmlModule : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.BeginRequest += delegate(object sender, EventArgs e)
			{
				string path = app.Context.Request.Path;
				if(path.EndsWith(".htmx"))
					app.Context.RewritePath(path.Replace(".htmx", ".html"));
			};
		}

		public void Dispose() {}
	}

	public class GreetingHandler : IHttpHandler
	{
		private int count = 0;

		public bool IsReusable => true;

		public void ProcessRequest(HttpContext context)
		{
			var writer = context.Response.Output;
			writer.WriteLine("<html>");
			writer.WriteLine($"<head><title>{context.Request.Path} - BasicWebApp</title></head>");
			writer.WriteLine("<body>");
			writer.WriteLine($"<h1>Welcome Visitor {++count}</h1>");
			writer.WriteLine($"<b>Time on server: </b>{DateTime.Now}");
			writer.WriteLine("</body>");
			writer.WriteLine("</html>");
		}
	}

	public class StateHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{
		private static int count = 0;

		public bool IsReusable => false;

		public void ProcessRequest(HttpContext context)
		{
			string name = context.Request.Form["visitor"];
			if(name?.Length == 0)
			{
				context.Response.Redirect("welcome.gwh");
				return;
			}

			int n = (int?)context.Session[name] ?? 1;
			context.Session[name] = n + 1;	
								
			var writer = context.Response.Output;
			writer.WriteLine("<html>");
			writer.WriteLine("<head><title>BasicWebApp</title></head>");
			writer.WriteLine("<body>");
			writer.WriteLine($"<h1>Hello {name}</h1>");
			writer.WriteLine($"<b>Number of greetings: </b>{n} / {++count}");
			writer.WriteLine("</body>");
			writer.WriteLine("</html>");
		}
	}

	public class Greeter : WebControl
	{
		public string Person {get; set;}

		protected override void Render(HtmlTextWriter output)
		{
			string[] intervals = {"Night", "Morning", "Afternoon", "Evening"};
			int i = DateTime.Now.Hour / 6;

			output.RenderBeginTag(HtmlTextWriterTag.Span);
			output.Write("Good {0} {1}", intervals[i], Person);
			output.RenderEndTag();	
		}
	}

}
