using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Data;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CalisanController : Controller
    {
        private readonly ICalisanServices _service;

        public CalisanController(ICalisanServices service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Calisanlar()
        {
            var data = _service.GetAll();
            return View(data);
        }

        // GET: Calisan/Ekle
        public IActionResult Ekle()
        {
            ViewBag.Hizmetler = _service.GetAllHizmetler();
            return View();
        }

        // POST: Calisan/Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Calisan yeniCalisan, List<int> HizmetlerIds)
        {
            if (ModelState.IsValid)
            {
                // Save the new Calisan
                _service.YeniCalisanEkle(yeniCalisan);

                // Associate the selected Hizmetler with the Calisan
                foreach (var hizmetId in HizmetlerIds)
                {
                    var calisanHizmet = new CalisanHizmet
                    {
                        CalisanID = yeniCalisan.CalisanID,
                        HizmetID = hizmetId
                    };
                    _service.AddCalisanHizmet(calisanHizmet);
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Hizmetler = _service.GetAllHizmetler();
            return View(yeniCalisan);
        }


        // GET: Calisan/Guncelle/5
        public IActionResult Guncelle(int id)
        {
            var calisan = _service.GetById(id);
            if (calisan == null)
            {
                return NotFound();
            }

            ViewBag.Hizmetler = _service.GetAllHizmetler(); // Pass all available Hizmetler
            return View(calisan);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(int id, Calisan guncelCalisan, List<int> HizmetlerIds)
        {
            if (id != guncelCalisan.CalisanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.CalisanGuncelle(id, guncelCalisan);

                // Update Hizmetler associations
                _service.UpdateCalisanHizmetler(id, HizmetlerIds);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Hizmetler = _service.GetAllHizmetler(); // Reload Hizmetler for validation errors
            return View(guncelCalisan);
        }


        // GET: Calisan/Sil/5
        public IActionResult Sil(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = _service.GetById(id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // POST: Calisan/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            _service.CalisanSil(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
