using System;
using System.Data.SqlClient;
using Dapper;
using DbConnector.Models;

namespace DbConnector
{
    public class MsSqlConnector
    {
        public string ConnectionString { get; set; }

        public async void Connect()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync().ContinueWith(task => Console.WriteLine("Success"));

                    var databases = await connection.QueryAsync<Database>("SELECT database_id AS id, name FROM sys.databases;");
                    var tables = await connection.QueryAsync<Table>("SELECT TABLE_NAME AS 'name', TABLE_SCHEMA AS 'schema', TABLE_TYPE as 'type' FROM Northwind.INFORMATION_SCHEMA.TABLES");

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
