using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuServices _service;
        private readonly ICalisanServices _calisanService;
        private readonly IHizmetServices _hizmetService;
        public RandevuController(IRandevuServices service, ICalisanServices calisanService, IHizmetServices hizmetService)
        {
            _service = service;
            _calisanService = calisanService;
            _hizmetService = hizmetService;
        }

        // GET: Randevu/Index
        public IActionResult Index()
        {
            var randevular = _service.GetAll();
            return View(randevular);
        }

        // GET: Randevu/Ekle
        public IActionResult Ekle()
        {
            // اختيار التاريخ (اختياري - يمكن تغييره بناءً على المدخلات)
            var today = DateTime.Now.Date;

            // الحصول على العمال المحجوزين في هذا اليوم
            var reservedCalisanIds = _service.GetAllRandevular()
                .Where(r => r.RandevuTarihi.Date == today)
                .Select(r => r.CalisanID)
                .ToList();

            // جلب جميع العمال مع استبعاد المحجوزين
            ViewBag.Calisanlar = _calisanService.GetAll()
                .Where(c => !reservedCalisanIds.Contains(c.CalisanID))
                .ToList();

            // جلب جميع الخدمات
            ViewBag.Hizmetler = _hizmetService.GetAll();

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _service.YeniRandevuEkle(randevu);
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }
        /*
         
        // GET: Randevu/Detay/5
        public IActionResult Detay(int id)
        {
            var randevu = _service.GetById(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // GET: Randevu/Ekle
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Randevu randevu)
        {
            // التحقق من صحة البيانات
            if (ModelState.IsValid)
            {
                // التحقق من صحة الموظف
                var calisan = _context.Calisanlar.FirstOrDefault(c => c.CalisanID == randevu.CalisanID);
                if (calisan == null)
                {
                    ModelState.AddModelError("CalisanID", "Geçerli bir çalışan seçiniz.");
                    return View(randevu);
                }

                // التحقق من صحة الخدمة
                var hizmet = _context.Hizmetler.FirstOrDefault(h => h.HizmetID == randevu.HizmetID);
                if (hizmet == null)
                {
                    ModelState.AddModelError("HizmetID", "Geçerli bir hizmet seçiniz.");
                    return View(randevu);
                }

                // التحقق من التاريخ
                if (randevu.RandevuTarihi < DateTime.Now)
                {
                    ModelState.AddModelError("RandevuTarihi", "Geçmiş bir tarih seçilemez.");
                    return View(randevu);
                }

                // إذا كانت جميع البيانات صحيحة، أضف الموعد
                _service.YeniRandevuEkle(randevu);
                return RedirectToAction(nameof(Index));
            }

            // إذا كانت هناك أخطاء في البيانات، عرض النموذج مع الأخطاء
            return View(randevu);
        }

        // GET: Randevu/Guncelle/5
        public IActionResult Guncelle(int id)
        {
            var randevu = _service.GetById(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(Randevu randevu)
        {
            // التحقق من صحة البيانات
            if (ModelState.IsValid)
            {
                // التحقق من صحة الموظف
                var calisan = _context.Calisanlar.FirstOrDefault(c => c.CalisanID == randevu.CalisanID);
                if (calisan == null)
                {
                    ModelState.AddModelError("CalisanID", "Geçerli bir çalışan seçiniz.");
                    return View(randevu);
                }

                // التحقق من صحة الخدمة
                var hizmet = _context.Hizmetler.FirstOrDefault(h => h.HizmetID == randevu.HizmetID);
                if (hizmet == null)
                {
                    ModelState.AddModelError("HizmetID", "Geçerli bir hizmet seçiniz.");
                    return View(randevu);
                }

                // التحقق من التاريخ
                if (randevu.RandevuTarihi < DateTime.Now)
                {
                    ModelState.AddModelError("RandevuTarihi", "Geçmiş bir tarih seçilemez.");
                    return View(randevu);
                }

                // إذا كانت جميع البيانات صحيحة، قم بالتحديث
                _service.RandevuGuncelle(randevu);
                return RedirectToAction(nameof(Index));
            }

            // إذا كانت هناك أخطاء في البيانات، عرض النموذج مع الأخطاء
            return View(randevu);
        }

        // GET: Randevu/Sil/5
        public IActionResult Sil(int id)
        {
            var randevu = _service.GetById(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // POST: Randevu/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            _service.RandevuSil(id);
            return RedirectToAction(nameof(Index));
        }
        */
    }
}
