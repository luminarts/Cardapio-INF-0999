using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Printing;
using System.Security.Cryptography;
using FastFoodly.Model;

namespace FastFoodly
{
	public class DbCartService
	{
		private string _connectionString;

		public DbCartService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public SqlConnection OpenConnection()
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			return connection;
		}

		public string InsertItem(CartItem item)
		{
			try
			{
				var conn = OpenConnection();
				SqlCommand command = new SqlCommand($"INSERT INTO carrinho VALUES({item.ProductId}, {item.Name}, {item.Price}, {item.Quantity}, {item.Observations})", conn);

				SqlDataReader reader = command.ExecuteReader();
				if (reader = 1)
				{
					return "success";
				}
				return "Failed to add product to cart";
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
				throw;
			}
		}
	}
}