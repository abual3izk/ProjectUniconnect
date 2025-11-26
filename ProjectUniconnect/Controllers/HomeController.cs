using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();   // Views/Home/Index.cshtml
        }

        public IActionResult About()
        {
            return View();   // Views/Home/About.cshtml
        }

        public IActionResult Privacy()
        {
            return View();   // Views/Home/Privacy.cshtml
        }
    }
}
