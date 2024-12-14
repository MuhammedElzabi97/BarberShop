namespace Barber_Shop.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici? Kullanici { get; set; }
        public int CalisanId { get; set; }
        public Calisan? Calisan { get; set; }
        public int HizmetId { get; set; }
        public Hizmet? Hizmet { get; set; }
        public DateTime Tarih { get; set; } 
        public TimeSpan Saat { get; set; } 
        public string Durum { get; set; } = "Beklemede";
    }
}
