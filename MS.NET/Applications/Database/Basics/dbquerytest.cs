using System;
using System.Data.Common;
using System.Configuration;

static class Program
{
	public static void Main()
	{
		ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDB"];
		DbProviderFactory provider = DbProviderFactories.GetFactory(settings.ProviderName);

		DbConnection connection = provider.CreateConnection();
		connection.ConnectionString = settings.ConnectionString;
		connection.Open();

		DbCommand command = connection.CreateCommand();
		command.CommandText = "SELECT ProductNo, Price, Stock FROM Product";

		DbDataReader reader = command.ExecuteReader();
		while(reader.Read())
			Console.WriteLine("{0, -6}{1, 12:0.00}{2, 8}", reader.GetInt32(0), reader[1], reader["Stock"]);
		reader.Close();

		connection.Close();	
	}
}
