using Microsoft.AspNetCore.Mvc;

namespace TeamTasker.Controllers
{
    public class UserSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
