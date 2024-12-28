using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
  //  [Authorize(Roles = "Kullanici")]
    public class RandevuController : Controller
    {
        private readonly IRandevuServices _randevuService;
        private readonly ICalisanServices _calisanService;
        private readonly IHizmetServices _hizmetService;

        public RandevuController(IRandevuServices randevuService, ICalisanServices calisanService, IHizmetServices hizmetService)
        {
            _randevuService = randevuService;
            _calisanService = calisanService;
            _hizmetService = hizmetService;
        }

        // قائمة جميع المواعيد
        public IActionResult Index()
        {
            var randevular = _randevuService.GetAll();
            return View(randevular);
        }

        // قائمة مواعيد المستخدم الحالي
        public IActionResult Randevularim()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = _randevuService.GetAllRandevular()
                .Where(r => r.UserID == userId); // Filter by logged-in user's ID

            return View(appointments);
        }

        // صفحة حجز موعد جديد
        public IActionResult Ekle()
        {
            ViewBag.Calisanlar = _calisanService.GetAll(); // Get all employees
            ViewBag.Hizmetler = _hizmetService.GetAll();   // Get all services
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Randevu randevu)
        {
            var calisan = _calisanService.GetById(randevu.CalisanID);
            var hizmet = _hizmetService.GetById(randevu.HizmetID);

            if (calisan == null || hizmet == null)
            {
                ModelState.AddModelError("", "Geçersiz Çalışan veya Hizmet seçildi.");
                ViewBag.Calisanlar = _calisanService.GetAll();
                ViewBag.Hizmetler = _hizmetService.GetAll();
                return View(randevu);
            }

            if (randevu.RandevuTarihi < DateTime.Now)
            {
                ModelState.AddModelError("RandevuTarihi", "Geçmiş bir tarih seçilemez.");
                ViewBag.Calisanlar = _calisanService.GetAll();
                ViewBag.Hizmetler = _hizmetService.GetAll();
                return View(randevu);
            }

            // تعيين UserID للمستخدم الحالي
            randevu.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // إضافة الموعد
            _randevuService.YeniRandevuEkle(randevu);

            TempData["SuccessMessage"] = "Randevu başarıyla alındı!";
            return RedirectToAction("Randevularim");
        }

        // حذف موعد
        public IActionResult Sil(int? id)
        {
            if (id == null)
                return NotFound();

            var randevu = _randevuService.GetById(id.Value);
            if (randevu == null)
                return NotFound();

            return View(randevu);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            var randevu = _randevuService.GetById(id); 
            if (randevu != null)
            {
                _randevuService.RandevuSil(id); 
            }

            TempData["SuccessMessage"] = "Randevu başarıyla iptal edildi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetHizmetlerForCalisan(int calisanId)
        {
            var hizmetler = _calisanService.GetHizmetlerByCalisan(calisanId);
            return Json(hizmetler.Select(h => new { h.HizmetID, h.HizmetAdi }));
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(int calisanId, int hizmetId, DateTime date)
        {
            var hizmet = _hizmetService.GetById(hizmetId);
            var appointments = _randevuService.GetAllRandevular()
                .Where(r => r.CalisanID == calisanId && r.RandevuTarihi.Date == date.Date);

            var availableSlots = _calisanService.GetAvailableTimeSlots(calisanId, date, appointments, hizmet.Sure);

            return Json(availableSlots);
        }


    }
}
