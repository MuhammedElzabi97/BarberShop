using WebProjesi.Models;

namespace WebProjesi.Data.Services
{
    public interface IHizmetServices
    {
        IEnumerable<Hizmet> GetAll();
        Hizmet GetById(int id);
        void YeniHizmetEkle(Hizmet hizmet);
        Hizmet HizmetGuncelle(int id, Hizmet guncelHizmet);
        void HizmetSil(int id);
    }
}
