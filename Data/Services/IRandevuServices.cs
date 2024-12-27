using WebProjesi.Models;

namespace WebProjesi.Data.Services
{
    public interface IRandevuServices
    {
        IEnumerable<Randevu> GetAll();
        IEnumerable<Randevu> GetAllRandevular();

        Randevu GetById(int id);
        Randevu RandevuGuncelle(Randevu randevu);
        void YeniRandevuEkle(Randevu randevu);
        
        void RandevuSil(int id);
    }
}
