namespace Barber_Shop.Models
{
    public class Calisan
    {

        public int CalisanId { get; set; }
        public string Ad { get; set; } = string.Empty; 
        public string Uzmanlik { get; set; } = string.Empty; 
        public ICollection<CalismaSaati>? CalismaSaatleri { get; set; } 
        public ICollection<Randevu>? Randevular { get; set; } 
    }
}
