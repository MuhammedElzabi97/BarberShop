using Microsoft.EntityFrameworkCore;
using WebProjesi.Models;

namespace WebProjesi.Data.Services
{
    public class CalisanService : ICalisanServices
    {
        private readonly AppDbContext _context;

        public CalisanService(AppDbContext context)
        {
            _context = context;
        }
        public Calisan CalisanGuncelle(int CalisanID, Calisan guncelCalisan)
        {
            _context.Update( guncelCalisan);
            _context.SaveChanges();
            return guncelCalisan;
        }

        public void CalisanSil(int CalisanID)
        {
            var calisan = _context.Calisanlar.FirstOrDefault(x => x.CalisanID == CalisanID);
            if (calisan != null)
            {
                _context.Calisanlar.Remove(calisan);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Calisan >GetAll()
        {
            var calisanlar = _context.Calisanlar.ToList();
            return calisanlar;
        }

        public Calisan GetById(int id)
        {
            var calisan = _context.Calisanlar.FirstOrDefault(x => x.CalisanID == id);
            return calisan;
        }

        public void YeniCalisanEkle( Calisan yeniCalisan)
        {
            _context.Calisanlar.Add(yeniCalisan);
            _context.SaveChanges();
        }
        public void AddCalisanHizmet(CalisanHizmet calisanHizmet)
        {
            _context.CalisanHizmetler.Add(calisanHizmet);
            _context.SaveChanges();
        }

    }
}
