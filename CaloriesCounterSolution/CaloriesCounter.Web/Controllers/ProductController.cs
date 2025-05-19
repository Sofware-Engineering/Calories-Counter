using Microsoft.AspNetCore.Mvc;
using CaloriesCounter.BLL;
using CaloriesCounter.Entities;
using Microsoft.Extensions.Logging;

namespace CaloriesCounter.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService service, ILogger<ProductController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Запит списку всіх продуктів");
            try
            {
                var products = _service.GetAllProducts();
                _logger.LogDebug("Отримано {ProductCount} продуктів", products.Count);
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Помилка при отриманні списку продуктів");
                throw;
            }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product == null)
            {
                _logger.LogWarning("Спроба додати null продукт");
                return BadRequest("Product cannot be null");
            }

            _logger.LogInformation("Додавання нового продукту: {ProductName}", product.Name);
            try
            {
                _service.AddProduct(product);
                _logger.LogInformation("Продукт успішно додано: {ProductId}", product.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Помилка при додаванні продукту {ProductName}", product.Name);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Видалення продукту з ID: {ProductId}", id);
            try
            {
                _service.DeleteProduct(id);
                _logger.LogInformation("Продукт успішно видалено: {ProductId}", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Помилка при видаленні продукту з ID: {ProductId}", id);
                throw;
            }
        }
    }
}