using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Printing;
using System.Security.Cryptography;
using FastFoodly.Models;

namespace FastFoodly
{
    public class DatabaseService
    {
        private string _connectionString;

        public DatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public List<Product> ListAllMenu()
        {
            try
            {
                var conn = OpenConnection();
                List<Product> cardapio = new List<Product>();
                SqlCommand command = new SqlCommand("SELECT * FROM Cardapio", conn);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Product()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2) / 100,
                            Description = reader.GetString(3),
                            Extras = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
                        {
                            produto.Extras?.Add(rawList[i]);
                        }
                        // string ImagePath = reader.GetString(6) != null ? reader.GetString(6) : "Assets/Images/no-image.jpg";
                        string ImagePath = "Assets/Images/no-image.jpg";
                        produto.ImagePath = new Uri(Path.GetFullPath(@ImagePath));
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

        public List<Product> ListByCategory(string categoria)
        {
            try
            {
                List<Product> menuByCategory = new List<Product>();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE categoria='{categoria}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Product()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2) / 100,
                            Description = reader.GetString(3),
                            Extras = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
                        {
                            produto.Extras?.Add(rawList[i]);
                        }
                        // var ImagePath = reader.GetString(6) ?? "Assets/Images/no-image.jpg";
                        string ImagePath = "Assets/Images/no-image.jpg";
                        produto.ImagePath = new Uri(Path.GetFullPath(@ImagePath));
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

        public List<Product> ListBySearch(string searchString)
        {
            try
            {
                List<Product> menuBySearch = new List<Product>();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE descricao LIKE '%{searchString}%' OR nome LIKE '%{searchString}%'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Cria o objeto Produto e salva suas variaveis
                        var produto = new Product()
                        {
                            ProductId = (int)reader.GetDecimal(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2) / 100,
                            Description = reader.GetString(3),
                            Extras = new List<string>(),
                            Category = reader.GetString(5)
                        };

                        // salva elementos na lista de ingredientes
                        var rawList = reader.GetString(4).Split(',');
                        for (int i = 0; i < rawList.Length; i++)
                        {
                            produto.Extras?.Add(rawList[i]);
                        }

                        // var ImagePath = reader.GetString(6) ?? "Assets/Images/no-image.jpg";
                        string ImagePath = "Assets/Images/no-image.jpg";
                        produto.ImagePath = new Uri(Path.GetFullPath(@ImagePath));
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

        public Product GetProductById(int id)
        {
            try
            {
                // Cria o objeto Produto
                Product menuBySearch = new Product();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE idProduto={id}", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Salva as variaveis name, price, description e category
                    menuBySearch.ProductId = (int)reader.GetDecimal(0);
                    menuBySearch.Name = reader.GetString(1);
                    menuBySearch.Price = reader.GetDecimal(2) / 100;
                    menuBySearch.Description = reader.GetString(3);
                    menuBySearch.Extras = new List<string>();
                    menuBySearch.Category = reader.GetString(5);

                    // var ImagePath = reader.GetString(6) ?? "Assets/Images/no-image.jpg";
                    string ImagePath = "Assets/Images/no-image.jpg";
                    menuBySearch.ImagePath = new Uri(Path.GetFullPath(@ImagePath));

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
                        menuBySearch.Extras?.Add(rawList[i]);
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

        public Product GetProductByName(string name)
        {
            try
            {
                // Cria o objeto Produto
                Product menuBySearch = new Product();
                var conn = OpenConnection();
                SqlCommand command = new SqlCommand($"SELECT * FROM cardapio WHERE nome='{name}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        menuBySearch.ProductId = (int)reader.GetDecimal(0);
                        menuBySearch.Name = reader.GetString(1);
                        menuBySearch.Price = reader.GetDecimal(2) / 100;
                        menuBySearch.Description = reader.GetString(3);
                        menuBySearch.Extras = new List<string>();
                        menuBySearch.Category = reader.GetString(5);
                       
                        // var ImagePath = reader.GetString(6) ?? "Assets/Images/no-image.jpg";
                        string ImagePath = "Assets/Images/no-image.jpg";
                        menuBySearch.ImagePath = new Uri(Path.GetFullPath(@ImagePath));


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
                            menuBySearch.Extras?.Add(rawList[i]);
                        }
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