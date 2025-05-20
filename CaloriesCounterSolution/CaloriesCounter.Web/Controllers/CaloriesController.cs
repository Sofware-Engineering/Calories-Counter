using CaloriesCounter.Core.Models;
using CaloriesCounter.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesCounter.Web.Controllers
{
    public class CalorieController : Controller
    {
        private readonly CalorieService _calorieService;

        public CalorieController(CalorieService calorieService)
        {
            _calorieService = calorieService;
        }

        public IActionResult Index()
        {
            return View(new UserProfile());
        }

        [HttpPost]
        public IActionResult Calculate(UserProfile profile)
        {
            if (!ModelState.IsValid)
                return View("Index", profile);

            var result = _calorieService.CalculateCalories(profile);
            return View("Result", result);
        }
    }
}
