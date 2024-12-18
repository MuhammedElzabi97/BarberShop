using System.ComponentModel.DataAnnotations;

namespace WebProjesi.Models
{
    public class Calisan
    {
        [Key]
        public int CalisanId { get; set; }

        [Required]
        [StringLength(30)]
        public string Ad { get; set; }


        [Required]
        [StringLength(30)]
        public string Soyad { get; set; }

        [Required]
        public TimeSpan BaslangicSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }

        public ICollection<Calisan_Hizmet> Calisan_Hizmetler { get; set; }
    }

 } 
