using WebProjesi.Models;

namespace WebProjesi.Data.Services
{
    public interface ICalisanServices
    {
        IEnumerable<Calisan> GetAll();
        Calisan GetById(int id);
        Calisan CalisanGuncelle(int CalisanID, Calisan guncelCalisan);
        void CalisanSil(int CalisanID);
        void YeniCalisanEkle(Calisan yeniCalisan);
        void AddCalisanHizmet(CalisanHizmet calisanHizmet);
    }
}
