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

        public async Task<List<Produto>> ListMenuCategory(string category)
        {
            // List<Produto> cardapio = new List<Produto>();
            var query = "SELECT * FROM cardapio WHERE categoria=@category";

            var parameters = new DynamicParameters();
            parameters.Add("category", category);

            try
            {
                using var conn = new SqlConnection(_connectionString);

                return (await conn.QueryAsync<Produto>(query)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao comunicar com banco. \n\nMessage: {ex.Message} \n\nTarget Site: {ex.TargetSite} \n\nStack Trace: {ex.StackTrace}");
                throw;
            }
            // SqlDataReader reader = command.ExecuteReader();
            // if (reader.HasRows)
            // {
            //     while (reader.Read())
            //     {
            //         // Cria o objeto Produto e salva as variaveis name, price e description
            //         var produto = new Produto()
            //         {
            //             Name = reader.GetString(1),
            //             Price = reader.GetDecimal(2),
            //             Description = reader.GetString(3),
            //             Ingredients = new List<string>(),
            //             Category = reader.GetString(5)
            //         };

            //         //salva valor do Id do produto
            //         object value = reader.GetValue(0);
            //         if (value is decimal decimalValue)
            //         {
            //             int numericValue = (int)decimalValue; // Convert decimal to int
            //             produto.ProductId = numericValue;
            //         }

            //         // salva elementos na lista de ingredientes
            //         var rawList = reader.GetString(4).Split(',');
            //         for(int i = 0; i < rawList.Length; i++)
            //         {
            //             produto.Ingredients?.Add(rawList[i]);
            //         }
            //         cardapio.Add(produto);
            //     }
            // }
            // return cardapio;
        }
    }
}