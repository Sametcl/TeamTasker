using Microsoft.AspNetCore.Mvc;

namespace TeamTasker.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
