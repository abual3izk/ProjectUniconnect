using Microsoft.AspNetCore.Mvc;
using ProjectUniconnect.Models;

namespace ProjectUniconnect.Controllers
{
    public class EmployerController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();   // يفتح Views/Employer/Login.cshtml
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Employer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // معالجة البيانات (عرضها مؤقتًا)
            ViewBag.Message =
                $"Received Employer: {model.CompanyName}, {model.Email}, {model.Password}";

            return View();
        }
    }
}