using System.Collections.Generic;
using CaloriesCounter.DAL;
using CaloriesCounter.Entities;

namespace CaloriesCounter.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(string connectionString)
        {
            _repository = new ProductRepository(connectionString);
        }

        public List<Product> GetAllProducts() => _repository.GetAll();

        public void AddProduct(Product product) => _repository.Add(product);
    }
}
