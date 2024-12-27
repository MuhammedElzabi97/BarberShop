using WebProjesi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebProjesi.Data.Services
{
    public class RandevuService : IRandevuServices
    {
        private readonly AppDbContext _context;

        public RandevuService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Randevu> GetAll()
        {
            return _context.Randevular.Include(r => r.Hizmet).Include(r => r.Calisan).ToList();
        }

        public Randevu GetById(int id)
        {
            return _context.Randevular.Include(r => r.Hizmet).Include(r => r.Calisan).FirstOrDefault(r => r.RandevuID == id);
        }

        public void YeniRandevuEkle(Randevu randevu)
        {
            _context.Randevular.Add(randevu);
            _context.SaveChanges();
        }

        public Randevu RandevuGuncelle(Randevu randevu)
        {
            _context.Randevular.Update(randevu);
            _context.SaveChanges();
            return randevu;
        }

        public void RandevuSil(int id)
        {
            var randevu = GetById(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Randevu> GetAllRandevular()
        {
            return _context.Randevular.Include(r => r.Calisan).Include(r => r.Hizmet).ToList();
        }
  
      
    }
}
