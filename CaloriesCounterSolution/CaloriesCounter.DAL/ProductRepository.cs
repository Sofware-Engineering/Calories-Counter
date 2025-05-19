using System.Collections.Generic;
using System.Data;
using Npgsql;
using CaloriesCounter.Entities;

namespace CaloriesCounter.DAL
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Products", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Calories = (int)reader["Calories"]
                        });
                    }
                }
            }

            return products;
        }

        public void Add(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO Products (Name, Calories) VALUES (@name, @calories)", connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@calories", product.Calories);
                command.ExecuteNonQuery();
            }
        }
    }
}
