using System;
using System.Collections.Generic;
using CaloriesCounter.DAL;
using CaloriesCounter.Entities;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace CaloriesCounter.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private readonly string _connectionString;
        private readonly ILogger<ProductService> _logger;

        public ProductService(string connectionString, ILogger<ProductService> logger = null)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _repository = new ProductRepository(connectionString);
            _logger = logger; // Логер може бути null, якщо сервіс створюється без DI
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                _logger?.LogDebug("Отримання всіх продуктів з бази даних");
                var products = _repository.GetAll();
                _logger?.LogDebug("Отримано {Count} продуктів", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Помилка при отриманні списку продуктів");
                throw;
            }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                _logger?.LogWarning("Спроба додати null продукт");
                throw new ArgumentNullException(nameof(product));
            }

            try
            {
                _logger?.LogInformation("Додавання продукту: {ProductName}", product.Name);
                _repository.Add(product);
                _logger?.LogInformation("Продукт успішно додано: {ProductId} {ProductName}", product.Id, product.Name);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Помилка при додаванні продукту {ProductName}", product.Name);
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _logger?.LogInformation("Видалення продукту з ID: {ProductId}", id);

                using var connection = new NpgsqlConnection(_connectionString);
                var command = new NpgsqlCommand("DELETE FROM Products WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();

                _logger?.LogInformation("Видалено рядків: {RowsAffected} для продукту з ID: {ProductId}", rowsAffected, id);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Помилка при видаленні продукту з ID: {ProductId}", id);
                throw;
            }
        }
    }
}