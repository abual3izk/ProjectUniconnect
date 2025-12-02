using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers  
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            // Read session values (id, username)
            ViewBag.SessionId = HttpContext.Session.GetString("id");
            ViewBag.SessionUserName = HttpContext.Session.GetString("username");

            return View(); // Return the Index view
        }
    }
}

