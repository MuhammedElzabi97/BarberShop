using Microsoft.AspNetCore.Mvc;
using Berber_Salonu.Data;
using Berber_Salonu.Models;
using Microsoft.EntityFrameworkCore;
using Barber_Shop.Models;
using System;

namespace Berber_Salonu.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // 1. ÇALIŞANLAR
        public IActionResult Calisanlar()
        {
            var calisanlar = _context.Calisanlar.ToList();
            return View(calisanlar);
        }

        public IActionResult YeniCalisan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniCalisan(Calisan yeniCalisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlar.Add(yeniCalisan);
                _context.SaveChanges();
                return RedirectToAction("Calisanlar");
            }
            return View(yeniCalisan);
        }

        public IActionResult CalisanDetay(int id)
        {
            var calisan = _context.Calisanlar.FirstOrDefault(c => c.CalisanId == id);
            if (calisan == null) return NotFound();
            return View(calisan);
        }

        public IActionResult GuncelleCalisan(int id)
        {
            var calisan = _context.Calisanlar.FirstOrDefault(c => c.CalisanId == id);
            if (calisan == null) return NotFound();
            return View(calisan);
        }

        [HttpPost]
        public IActionResult GuncelleCalisan(Calisan guncellenmisCalisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlar.Update(guncellenmisCalisan);
                _context.SaveChanges();
                return RedirectToAction("Calisanlar");
            }
            return View(guncellenmisCalisan);
        }

        public IActionResult SilCalisan(int id)
        {
            var calisan = _context.Calisanlar.FirstOrDefault(c => c.CalisanId == id);
            if (calisan != null)
            {
                _context.Calisanlar.Remove(calisan);
                _context.SaveChanges();
            }
            return RedirectToAction("Calisanlar");
        }

        // 2. HİZMETLER
        public IActionResult Hizmetler()
        {
            var hizmetler = _context.Hizmetler.ToList();
            return View(hizmetler);
        }

        public IActionResult YeniHizmet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniHizmet(Hizmet yeniHizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmetler.Add(yeniHizmet);
                _context.SaveChanges();
                return RedirectToAction("Hizmetler");
            }
            return View(yeniHizmet);
        }

        public IActionResult GuncelleHizmet(int id)
        {
            var hizmet = _context.Hizmetler.FirstOrDefault(h => h.HizmetId == id);
            if (hizmet == null) return NotFound();
            return View(hizmet);
        }

        [HttpPost]
        public IActionResult GuncelleHizmet(Hizmet guncellenmisHizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmetler.Update(guncellenmisHizmet);
                _context.SaveChanges();
                return RedirectToAction("Hizmetler");
            }
            return View(guncellenmisHizmet);
        }

        public IActionResult SilHizmet(int id)
        {
            var hizmet = _context.Hizmetler.FirstOrDefault(h => h.HizmetId == id);
            if (hizmet != null)
            {
                _context.Hizmetler.Remove(hizmet);
                _context.SaveChanges();
            }
            return RedirectToAction("Hizmetler");
        }

        // 3. RANDEVULAR
        public IActionResult Randevular()
        {
            var randevular = _context.Randevular
                .Include(r => r.Calisan)
                .Include(r => r.Hizmet)
                .Include(r => r.Kullanici)
                .ToList();
            return View(randevular);
        }

        public IActionResult YeniRandevu()
        {
            ViewBag.Calisanlar = _context.Calisanlar.ToList();
            ViewBag.Hizmetler = _context.Hizmetler.ToList();
            ViewBag.Kullanicilar = _context.Kullanicilar.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult YeniRandevu(Randevu yeniRandevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Add(yeniRandevu);
                _context.SaveChanges();
                return RedirectToAction("Randevular");
            }

            ViewBag.Calisanlar = _context.Calisanlar.ToList();
            ViewBag.Hizmetler = _context.Hizmetler.ToList();
            ViewBag.Kullanicilar = _context.Kullanicilar.ToList();
            return View(yeniRandevu);
        }

        public IActionResult SilRandevu(int id)
        {
            var randevu = _context.Randevular.FirstOrDefault(r => r.RandevuId == id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("Randevular");
        }
    }
}
