using WebProjesi.Models;

namespace WebProjesi.Data.Services
{
    public class HizmetService : IHizmetServices
    {
        private readonly AppDbContext _context;

        public HizmetService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hizmet> GetAll()
        {
            return _context.Hizmetler.ToList();
        }

        public Hizmet GetById(int id)
        {
            return _context.Hizmetler.FirstOrDefault(h => h.HizmetID == id);
        }

        public void YeniHizmetEkle(Hizmet hizmet)
        {
            _context.Hizmetler.Add(hizmet);
            _context.SaveChanges();
        }

        public Hizmet HizmetGuncelle(int id, Hizmet guncelHizmet)
        {
            _context.Update(guncelHizmet);
            _context.SaveChanges();
            return guncelHizmet;
        }

        public void HizmetSil(int id)
        {
            var hizmet = GetById(id);
            if (hizmet != null)
            {
                _context.Hizmetler.Remove(hizmet);
                _context.SaveChanges();
            }
        }
    }
}
