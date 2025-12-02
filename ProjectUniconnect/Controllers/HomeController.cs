using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Store session ID (example from slides)
            SetSession("id", HttpContext.Session.Id);

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                // User is logged in
                var name = User.Identity.Name ?? "user";

                // Save username in cookies + session
                SetCookies("userName", name);
                SetSession("username", name);
            }
            else
            {
                // Guest user
                SetCookies("userName", "guest");
                SetSession("username", "guest");
            }

            // Save browser name (User-Agent)
            SetCookies("browserName", Request.Headers["User-Agent"].ToString());

            return View(); // Return Index view
        }

        public void SetSession(string key, string value)
        {
            // Write a value into session
            HttpContext.Session.SetString(key, value);
        }

        public IActionResult About()
        {
            return View(); // Return About page
        }

        public IActionResult Privacy()
        {
            return View(); // Return Privacy page
        }

        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            // Cookie configuration
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(15), // Cookie expiration
                HttpOnly = true,                    // Block JS access
                Secure = true,                      // Works only with HTTPS
                SameSite = SameSiteMode.Strict      // Protect from CSRF
            };

            // Save cookie
            Response.Cookies.Append(cookieName, cookieValue, options);
            return Ok("Cookies has been set."); // Confirmation response
        }
    }
}
