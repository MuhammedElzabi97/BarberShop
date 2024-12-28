using System.ComponentModel.DataAnnotations;

namespace WebProjesi.Models
{
    public class Calisan
    {
        
        public int CalisanID { get; set; }



        [Required(ErrorMessage = "Adi ve Soyadi giriniz")]
        [StringLength(30)]
        public string Ad_Soyad { get; set; }

       

        [Required(ErrorMessage = "Baslangic Saati giriniz")]
        [DataType(DataType.Time)]
        public TimeSpan BaslangicSaati { get; set; }

        [Required(ErrorMessage = "Bitis Saati giriniz")]
        [DataType(DataType.Time)]
        public TimeSpan BitisSaati { get; set; }
        [Required(ErrorMessage = "Calisan Resmini giriniz")]
        public string? Calisan_Resmi { get; set; }

        public List<CalisanHizmet> CalisanHizmetler { get; set; } = new List<CalisanHizmet>();
        public List<Randevu> Randevular { get; set; } = new List<Randevu>();

    }
} 