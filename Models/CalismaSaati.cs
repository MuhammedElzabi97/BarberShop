namespace Barber_Shop.Models
{
    public class CalismaSaati
    {
        public int CalismaSaatiId { get; set; }
        public int CalisanId { get; set; }
        public Calisan? Calisan { get; set; }
        public DateTime Baslangic { get; set; } 
        public DateTime Bitis { get; set; }
    }
}
