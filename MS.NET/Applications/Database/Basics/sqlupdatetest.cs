using System;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		string sql = $"UPDATE Product SET Stock=Stock+5 WHERE ProductNo={int.Parse(args[0])}";
		
		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();

		SqlCommand cmd = new SqlCommand(sql, con);
		int n = cmd.ExecuteNonQuery();
		if(n == 0)
			Console.WriteLine("No such product!");

		con.Close();		

	}
}