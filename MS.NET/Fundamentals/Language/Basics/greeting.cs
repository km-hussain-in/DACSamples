namespace Greeting
{
	public class Greeter
	{
		private bool formal;

		public Greeter(bool polite)
		{
			formal = polite;
		}	

		public string Greet(string person)
		{
			if(formal)
				return $"Hello {person}";
			return $"Hi {person}";
		}
	}
}

