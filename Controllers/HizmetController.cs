using Microsoft.AspNetCore.Mvc;
using WebProjesi.Data;
using WebProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebProjesi.Controllers
{
    public class HizmetController : Controller
    {

        private readonly AppDbContext _context;

        public HizmetController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Hizmet> hizmetler = _context.Hizmetler.ToList();
            return View(hizmetler);
        }

        //Get
        public IActionResult YeniHizmetEkle()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult YeniHizmetEkle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmetler.Add(hizmet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(hizmet);
            }
        }

        //GET
        public IActionResult Duzeltir(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }

            var hizmet = _context.Hizmetler.Find(Id);

            if (hizmet == null)
            {
                return NotFound();
            }
            return View(hizmet);
        }

        // POST
        [HttpPost]
        public IActionResult Duzeltir(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Update(hizmet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(hizmet);
            }
        }

        //GET
        public IActionResult Sil(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var hizmet = _context.Hizmetler.Find(Id);

            if (hizmet == null)
            {
                return NotFound();
            }
            return View(hizmet);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int Id)
        {
            var hizmet = _context.Hizmetler.Find(Id);

            if (hizmet == null)
            {
                return NotFound();
            }

            _context.Hizmetler.Remove(hizmet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
