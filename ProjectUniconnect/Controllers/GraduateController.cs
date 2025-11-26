using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class GraduateController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();   // Views/Graduate/Login.cshtml
        }
    }
}
