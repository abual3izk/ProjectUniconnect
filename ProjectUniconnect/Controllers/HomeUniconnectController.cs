using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class HomeUniconnectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
