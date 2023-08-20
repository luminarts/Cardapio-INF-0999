using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Printing;
using System.Security.Cryptography;
using FastFoodly.Model;

namespace FastFoodly
{
    public class DatabaseService
    {
        private string _connectionString;
        
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public List<Produto> ListAllMenu()
        {
            try
            {
                var conn = OpenConnection();
                List<Produto> cardapio = new List<Produto>();
                SqlCommand command = new SqlCommand("SELECT * FROM Cardapio", conn);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva as variaveis name, price e description
                        var produto = new Produto()
                        {
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Ingredients = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        //salva valor do Id do produto
                        object value = reader.GetValue(0);
                        if (value is decimal decimalValue)
                        {
                            int numericValue = (int)decimalValue; // Convert decimal to int
                            produto.ProductId = numericValue;
                        }

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for(int i = 0; i < rawList.Length; i++)
                        {
                            produto.Ingredients?.Add(rawList[i]);
                        }
                        cardapio.Add(produto);
                    }
                }
                return cardapio;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public List<Produto> ListMenuCategory(string categoria)
        {

            try
            {
                List<Produto> menuByCategory = new List<Produto>();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE categoria='{categoria}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva as variaveis name, price, description e category
                        var produto = new Produto()
                        {
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Ingredients = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        //salva valor do Id do produto
                        object value = reader.GetValue(0);
                        if (value is decimal decimalValue)
                        {
                            int numericValue = (int)decimalValue; // Convert decimal to int
                            produto.ProductId = numericValue;
                        }

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
                        {
                            produto.Ingredients?.Add(rawList[i]);
                        }
                        menuByCategory.Add(produto);
                    }
                }
                return menuByCategory;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}