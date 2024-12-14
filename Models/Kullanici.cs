namespace Barber_Shop.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; } = string.Empty; 
        public string Eposta { get; set; } = string.Empty; 
        public string Sifre { get; set; } = string.Empty; 
        public string Rol { get; set; } = "Kullanici"; 
        public ICollection<Randevu>? Randevular { get; set; }
    }
}
