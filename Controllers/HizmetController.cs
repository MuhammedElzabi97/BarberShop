using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Data;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HizmetController : Controller
    {
        private readonly IHizmetServices _service;

        public HizmetController(IHizmetServices service)
        {
            _service = service;
        }

        // GET: Hizmet
        public IActionResult Index()
        {
            var hizmetler = _service.GetAll();
            return View(hizmetler);
        }

        // GET: Hizmet/Ekle
        public IActionResult Ekle()
        {
            return View();
        }

        // POST: Hizmet/Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _service.YeniHizmetEkle(hizmet);
                return RedirectToAction(nameof(Index));
            }
            return View(hizmet);
        }

        // GET: Hizmet/Guncelle/5
        public IActionResult Guncelle(int id)
        {
            var hizmet = _service.GetById(id);
            if (hizmet == null)
            {
                return NotFound();
            }
            return View(hizmet);
        }

        // POST: Hizmet/Guncelle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(int id, Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _service.HizmetGuncelle(id, hizmet);
                return RedirectToAction(nameof(Index));
            }
            return View(hizmet);
        }

        // GET: Hizmet/Sil/5
        public IActionResult Sil(int id)
        {
            var hizmet = _service.GetById(id);
            if (hizmet == null)
            {
                return NotFound();
            }
            return View(hizmet);
        }

        // POST: Hizmet/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            _service.HizmetSil(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
