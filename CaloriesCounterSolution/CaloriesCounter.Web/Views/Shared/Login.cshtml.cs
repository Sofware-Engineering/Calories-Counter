using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using CaloriesCounter.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CaloriesCounter.Web.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Електронна пошта обов'язкова")]
            [EmailAddress(ErrorMessage = "Невірний формат електронної пошти")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Пароль обов'язковий")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Запам'ятати мене")]
            public bool RememberMe { get; set; } // Added RememberMe property
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Невірна спроба входу.");
            }
            return Page();
        }
    }
}