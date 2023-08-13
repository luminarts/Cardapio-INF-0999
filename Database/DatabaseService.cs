using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

    public List<string> ConsultaCardapio()
    {
        var conn = OpenConnection();
        var rows = new List<string>();
        SqlCommand command = new SqlCommand("SELECT * FROM Cardapio", conn);

        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                rows.Add($"{reader.GetString(1)}");
            }
        }
        return rows;
    }
}