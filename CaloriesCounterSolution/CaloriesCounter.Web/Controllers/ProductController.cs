
using Microsoft.AspNetCore.Mvc;
using CaloriesCounter.BLL;
using CaloriesCounter.Entities;

namespace CaloriesCounter.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(IConfiguration config)
        {
            var connStr = config.GetConnectionString("DefaultConnection");
            _service = new ProductService(connStr);
        }

        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _service.AddProduct(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}
