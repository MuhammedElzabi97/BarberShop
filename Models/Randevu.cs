using System.ComponentModel.DataAnnotations;
using WebProjesi.Models;

namespace WebProjesi.Models
{

    public class Randevu
    {
        public int RandevuID { get; set; }
        public int CalisanID { get; set; }
        public Calisan Calisan { get; set; }

        public int HizmetID { get; set; }

        public Hizmet Hizmet { get; set; }

        [Required]
        [StringLength(100)]
        public string MusteriAdi { get; set; }

        [Required]
        public DateTime RandevuTarihi { get; set; }

        [StringLength(50)]
        public string Durum { get; set; } = "Beklemede";

        public string Notlar { get; set; }

        public decimal Ucret { get; set; }
    }
}