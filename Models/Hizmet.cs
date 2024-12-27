using System.ComponentModel.DataAnnotations;
using WebProjesi.Data;

namespace WebProjesi.Models
{
    public class Hizmet
    {
        public int HizmetID { get; set; } 

        [Required]
        [StringLength(100)]
        public string HizmetAdi { get; set; } 

        public string? Aciklama { get; set; } 

        [Required]
        [Range(5, 240, ErrorMessage = "Lütfen geçerli bir süre giriniz.")]
        public int Sure { get; set; } 

        [Required]
        [Range(1, 1000, ErrorMessage = "Lütfen geçerli bir ücret giriniz.")]
        public decimal Ucret { get; set; }

        public string ?ImageURL { get; set; } 

        public List<CalisanHizmet> CalisanHizmetler { get; set; } = new List<CalisanHizmet>();
    }

}

