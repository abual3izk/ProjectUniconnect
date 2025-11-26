using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class UniversityController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();   // Views/University/Login.cshtml
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();   // Views/University/Signup.cshtml
        }
    }
}
