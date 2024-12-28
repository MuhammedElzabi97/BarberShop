using Microsoft.AspNetCore.Mvc;

namespace WebProjesi.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
