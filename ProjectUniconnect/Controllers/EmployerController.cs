using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers   // لو اسم مشروعك مختلف عدّله
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
            return View();   // يفتح Views/Employer/Signup.cshtml لو موجود
        }
    }
}
