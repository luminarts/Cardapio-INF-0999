using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Printing;
using System.Security.Cryptography;
using FastFoodly.Models;

namespace FastFoodly
{
	public class DbCartService
	{
		private string _connectionString;

		public DbCartService()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
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
				SqlCommand command = new SqlCommand($"INSERT INTO carrinho VALUES({item.ProductId}, '{item.Name}', {item.Price}, {item.Quantity}, '{item.Observations}')", conn);

				command.ExecuteReader();
				return "Success";
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
				return "Failed to add item to cart";
			}
		}

		public List<CartItem> ListAllItems()
		{
			try
			{
				var conn = OpenConnection();
				List<CartItem> cart = new List<CartItem>();
				SqlCommand command = new SqlCommand("SELECT * FROM Carrinho", conn);

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						// Cria o objeto cartItem e salva suas variaveis
						var cartItem = new CartItem()
						{
							ItemId = (int)reader.GetDecimal(0),
							ProductId = (int)reader.GetDecimal(1),
							Name = reader.GetString(2),
							Price = reader.GetDecimal(3),
							Quantity = (int)reader.GetDecimal(4),
							Observations = reader.GetString(5)
						};
						cart.Add(cartItem);
					}
				}
				return cart;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
				throw;
			}
		}

		public string DeleteItem(int itemId)
		{
			try
			{
				var conn = OpenConnection();
				List<CartItem> cart = new List<CartItem>();
				SqlCommand command = new SqlCommand($"DELETE FROM carrinho WHERE idItem={itemId}", conn);

				command.ExecuteReader();
				return "Success";
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
				return $"Failed to delete item {itemId} from cart";
			}
		}

		public string DeleteAllItems()
		{
			try
			{
				var conn = OpenConnection();
				List<CartItem> cart = new List<CartItem>();
				SqlCommand command = new SqlCommand("DELETE FROM carrinho", conn);

				command.ExecuteReader();
				return "Success";
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
				return "Failed to delete items from cart";
			}
		}
	}
}