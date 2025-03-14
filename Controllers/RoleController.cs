using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TeamTasker.Models;
using TeamTasker.ViewModels;

namespace TeamTasker.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var viewmodel = new RoleViewModel
            {
                Role = new AppRole(),
                RoleList = roles
            };
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            AppRole appRole = new() { Name = roleName };
            IdentityResult result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(roleName);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return BadRequest("Role ID cannot be null or empty.");
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> UpdateRole(string id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound(); // Eğer rol bulunamazsa hata döndür
            }

            if (ModelState.IsValid)
            {
                role.Name = roleName; // Rol adını güncelle
                var result = await _roleManager.UpdateAsync(role); // Güncelleme yap

                if (result.Succeeded)
                {
                    return RedirectToAction("Index"); // Güncelleme başarılıysa listeye geri dön
                }

                // Güncelleme başarısızsa hata mesajı göster
                ModelState.AddModelError("", "Güncelleme başarısız!");
            }

            return View(role);
        }

    }
}

