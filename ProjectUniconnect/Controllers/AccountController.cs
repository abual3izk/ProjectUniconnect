using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers  
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            // 🔹 قراءة قيم السيشن مثل السلايد 36
            ViewBag.SessionId = HttpContext.Session.GetString("id");
            ViewBag.SessionUserName = HttpContext.Session.GetString("username");

            return View();
        }
    }
}
