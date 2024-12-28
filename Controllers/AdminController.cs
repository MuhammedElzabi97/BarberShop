using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;

        public AdminController(UserManager<Kullanici> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string email, string sifre)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return RedirectToAction("Index");
            }

            // Remove existing roles
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);

            // Assign role based on email pattern
            if (email == "muhammed.elzabi@ogr.sakarya.edu.tr" && sifre == "sau")
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else if (email.EndsWith("@barber.com"))
            {
                await _userManager.AddToRoleAsync(user, "Calisan");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Kullanici");
            }

            TempData["SuccessMessage"] = "Rol başarıyla atandı.";
            return RedirectToAction("Index");
        }
    }
}
