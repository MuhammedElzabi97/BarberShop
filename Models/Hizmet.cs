namespace Barber_Shop.Models
{
    public class Hizmet
    {
        public int HizmetId { get; set; }
        public string Ad { get; set; } = string.Empty; 
        public int Sure { get; set; } 
        public decimal Fiyat { get; set; } 
        public ICollection<Randevu>? Randevular { get; set; }
    }
}
