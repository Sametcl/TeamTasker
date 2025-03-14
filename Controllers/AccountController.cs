using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeamTasker.Models;
using TeamTasker.ViewModels;

namespace TeamTasker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated == true) // Kullanıcı zaten giriş yapmışsa
            {
                return RedirectToAction("Index", "Task"); // Direkt anasayfaya yönlendir
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "bu alanlare bos birakilamaz");
                return View(model);
            }

            AppUser? user = await _userManager.FindByEmailAsync(model.Email ?? string.Empty);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, model.Password ?? string.Empty, true, true);
                if (result.Succeeded)
                {
                    ViewData["FullName"] = user?.FullName;
                    return RedirectToAction("Index","Task");
                }
            }
            ModelState.AddModelError(string.Empty, "Gecersiz sifre");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
