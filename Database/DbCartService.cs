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
						// Cria o objeto cartItem e salva as variaveis name, price e description
						var cartItem = new CartItem()
						{
							Name = reader.GetString(2),
							Price = reader.GetDecimal(3),
							Quantity = (int)reader.GetDecimal(4),
							Observations = new List<string>(),
						};

						//salva valor do Id do cartItem
						object value = reader.GetValue(0);
						if (value is decimal decimalValue)
						{
							int numericValue = (int)decimalValue; // Convert decimal to int
							cartItem.ItemId = numericValue;
						}

						value = reader.GetValue(1);
						if (value is decimal decimalValue)
						{
							int numericValue = (int)decimalValue; // Convert decimal to int
							cartItem.ProductId = numericValue;
						}

						// salva elementos na lista de observações
						var rawList = reader.GetString(5).Split(',');
						for (int i = 0; i < rawList.Length; i++)
						{
							cartItem.Observations?.Add(rawList[i]);
						}
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
	}
}