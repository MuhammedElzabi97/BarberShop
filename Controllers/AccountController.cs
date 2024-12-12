using Berber_Salonu.Data;
using Microsoft.AspNetCore.Mvc;

namespace Berber_Salonu.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // البحث عن المستخدم بناءً على البريد الإلكتروني وكلمة المرور
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // إذا كان المستخدم موجود، نحدد الجلسة بناءً على دوره
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserRole", user.Role);

                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // إذا كانت البيانات خاطئة
            ViewBag.Error = "E-posta veya şifre hatalı.";
            return View();
        }

        // GET: /Account/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            // إنهاء الجلسة
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
