using System.Collections.Generic;
using CaloriesCounter.DAL;
using CaloriesCounter.Entities;
using Npgsql;

namespace CaloriesCounter.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private readonly string _connectionString;

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
            _repository = new ProductRepository(connectionString);
        }

        public List<Product> GetAllProducts() => _repository.GetAll();

        public void AddProduct(Product product) => _repository.Add(product);

        public void DeleteProduct(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var command = new NpgsqlCommand("DELETE FROM Products WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
