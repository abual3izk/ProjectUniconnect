using Microsoft.AspNetCore.Mvc;

namespace ProjectUniconnect.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // 🔹 نخزن رقم (id) للجلسة – في السلايد يستخدم أي قيمة، هنا نستخدم Id الحالي
            SetSession("id", HttpContext.Session.Id);

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                // مستخدم مسجّل دخول (لو فعّلتِ Identity لاحقًا)
                var name = User.Identity.Name ?? "user";

                // كوكي + سيشن للاسم
                SetCookies("userName", name);
                SetSession("username", name);
            }
            else
            {
                // زائر
                SetCookies("userName", "guest");
                SetSession("username", "guest");
            }

            // كوكي لنوع المتصفح – نفس الفكرة في السلايد
            SetCookies("browserName", Request.Headers["User-Agent"].ToString());

            return View();
        }

        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }



        public IActionResult About()
        {
            return View();   // Views/Home/About.cshtml
        }

        public IActionResult Privacy()
        {
            return View();   // Views/Home/Privacy.cshtml
        }
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(15),   // مدة الكوكي
                HttpOnly = true,                      // يمنع JS
                Secure = true,                        // مع https
                SameSite = SameSiteMode.Strict        // يحمي من CSRF
            };

            Response.Cookies.Append(cookieName, cookieValue, options);
            return Ok("Cookies has been set.");

        }

    }
}
