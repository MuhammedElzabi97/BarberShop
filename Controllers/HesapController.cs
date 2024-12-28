using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebProjesi.Models;
using WebProjesi.LoginModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace WebProjesi.Controllers
{
    public class HesapController : Controller
    {

        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        // Constructor
        public HesapController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(WebProjesi.LoginModels.Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new Kullanici
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Ad = model.Ad,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Kayıt başarılı! Lütfen giriş yapınız.";
                    return RedirectToAction("Login", "Hesap");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        // GET: Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(WebProjesi.LoginModels.Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        // Get user roles
                        var roles = await _userManager.GetRolesAsync(user);

                        // Check for Admin role
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        // Check if the email ends with @barber.com and assign Calisan role if needed
                        if (model.Email.EndsWith("@barber.com"))
                        {
                            if (!roles.Contains("Calisan"))
                            {
                                await _userManager.AddToRoleAsync(user, "Calisan");
                            }
                            return RedirectToAction("Index", "Calisan");
                        }

                        // Default case: assign Kullanici role if not already assigned
                        if (!roles.Contains("Kullanici"))
                        {
                            await _userManager.AddToRoleAsync(user, "Kullanici");
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }


        // POST: Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Hesap");
        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }

        // POST: VerifyEmail
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Email zorunludur.");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu email adresiyle kayıtlı bir kullanıcı bulunamadı.");
                return View();
            }

            // Generate email verification token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Build verification link
            var verificationLink = Url.Action("ConfirmEmail", "Hesap", new { userId = user.Id, token = token }, Request.Scheme);

            // Simulate sending email (replace this with actual email sending logic)
            Console.WriteLine($"Email verification link: {verificationLink}");

            ViewBag.Message = "Email doğrulama linki gönderildi.";
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

     




    }
}
