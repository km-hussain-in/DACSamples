using System;

namespace BasicWebApp
{
	public partial class WebCtrlTestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			TimeLabel.Text = DateTime.Now.ToString();
		}
	}
}
