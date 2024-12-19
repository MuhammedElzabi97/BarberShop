using Microsoft.AspNetCore.Mvc;
using WebProjesi.Data;
using WebProjesi.Models;
using System.Linq;

namespace WebProjesi.Controllers
{
    public class HizmetController  Controller
    {

        private readonly AppDbContext _context;

        public HizmetController(AppDbContext context)
        {
            _context = context;
        }

         GET HizmetIndex
        [HttpGet]
        public IActionResult Index()
        {
            var hizmetler = _context.Hizmetler.ToList(); 
            return View(hizmetler);
        }


         GET HizmetCreate
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Hizmetler = _context.Hizmetler.ToList();
            return View();
        }

         POST HizmetCreate
        [HttpPost]
        public IActionResult Create(Hizmet model)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmetler.Add(model);
                _context.SaveChanges();
                return RedirectToAction(Index);
            }
            return View(model);
        }

         GET HizmetEdit{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _context.Hizmetler.FirstOrDefault(s = s.HizmetId == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

         POST HizmetEdit{id}
        [HttpPost]
        public IActionResult Edit(Hizmet model)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmetler.Update(model);
                _context.SaveChanges();
                return RedirectToAction(Index);
            }
            return View(model);
        }

         GET HizmetDelete{id}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = _context.Hizmetler.FirstOrDefault(s = s.HizmetId == id);
            if (service != null)
            {
                _context.Hizmetler.Remove(Hizmet);
                _context.SaveChanges();
            }
            return RedirectToAction(Index);
        }
    }
}
