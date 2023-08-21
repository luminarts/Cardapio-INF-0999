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
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Produto()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Ingredients = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
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

        public List<Produto> ListByCategory(string categoria)
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
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Produto()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Ingredients = new List<string>(),
                            Category = reader.GetString(5)
                        };

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

        public List<Produto> ListBySearch(string searchString)
        {
            try
            {
                List<Produto> menuBySearch = new List<Produto>();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE descricao LIKE '%{searchString}%' OR nome LIKE '%{searchString}%'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Produto()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Ingredients = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
                        {
                            produto.Ingredients?.Add(rawList[i]);
                        }
                        menuBySearch.Add(produto);
                    }
                }
                return menuBySearch;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public Produto GetProductById(int id)
        {
            try
            {
                // Cria o objeto Produto
                Produto menuBySearch = new Produto();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE idProduto={id}", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Salva as variaveis name, price, description e category
                    menuBySearch.ProductId = (int)reader.GetDecimal(0);
                    menuBySearch.Name = reader.GetString(1);
                    menuBySearch.Price = reader.GetDecimal(2);
                    menuBySearch.Description = reader.GetString(3);
                    menuBySearch.Ingredients = new List<string>();
                    menuBySearch.Category = reader.GetString(5);

                    //salva valor do Id do produto
                    object value = reader.GetValue(0);
                    if (value is decimal decimalValue)
                    {
                        int numericValue = (int)decimalValue; // Convert decimal to int
                        menuBySearch.ProductId = numericValue;
                    }

                    // salva elementos na lista de ingredientes
                    var rawList = reader.GetString(4).Split(',');
                    for (int i = 0; i < rawList.Length; i++)
                    {
                        menuBySearch.Ingredients?.Add(rawList[i]);
                    }
                }
                return menuBySearch;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}