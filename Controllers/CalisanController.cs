using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Data;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    public class CalisanController : Controller
    {
        private readonly ICalisanServices _service;

        public CalisanController(ICalisanServices service)
        {
            _service = service;
        }

        public  IActionResult Index()
        {
            var data =  _service.GetAll();
            return View(data);
        }

        // GET: Calisan/Ekle
        public IActionResult Ekle()
        {
            ViewBag.Hizmetler = _service.GetAll();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Calisan yeniCalisan)
        {
            if (ModelState.IsValid)
            {
                _service.YeniCalisanEkle( yeniCalisan);
                return RedirectToAction(nameof(Index));
            }
            return View(yeniCalisan);
        }

        // GET: Calisan/Guncelle/5
        public IActionResult Guncelle(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var calisan = _service.GetById(id);

            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

                 
     
        // POST: Calisan/Guncelle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(int id, Calisan guncelCalisan)
        {
            if (id != guncelCalisan.CalisanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.CalisanGuncelle(guncelCalisan.CalisanID, guncelCalisan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.GetAll().Any(c => c.CalisanID == guncelCalisan.CalisanID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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
