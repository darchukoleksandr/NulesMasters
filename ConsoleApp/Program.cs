using System;
using DbConnector;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
//            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
            string connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=True";
            new MsSqlConnector
            {
                ConnectionString = connectionString
            }.Connect();

            Console.ReadLine();
        }
    }
}
