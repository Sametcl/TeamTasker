using Microsoft.AspNetCore.Mvc;

namespace TeamTasker.Controllers
{
    public class WorkerSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
