using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProjesi.Models;

namespace WebProjesi.Models
{

    public class Randevu
    {
        public int RandevuID { get; set; }
        public int CalisanID { get; set; }
        [ForeignKey("CalisanID")]
        public Calisan Calisan { get; set; }
        public int HizmetID { get; set; }
        [ForeignKey("HizmetID")]
        public Hizmet Hizmet { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public Kullanici Kullanici { get; set; }

        [Required]
        [StringLength(100)]
        public string MusteriAdi { get; set; }

        [Required]
        public DateTime RandevuTarihi { get; set; }

        [StringLength(50)]
        public string Durum { get; set; } = "Beklemede";

        public string? Notlar { get; set; }

    }
}