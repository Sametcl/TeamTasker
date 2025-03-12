using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamTasker.Models;

namespace TeamTasker.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public TaskController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
