using System.ComponentModel.DataAnnotations;

namespace Berber_Salonu.Models
{
    public class Service
    {
        [Key]
        public int ServiceId {  get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 200)]
        public int Duration {  get; set; }//Süre

        [Range(0,double.MaxValue)]
        public decimal Price {  get; set; }

        // Foreign key
        [Required]
        public int SalonId { get; set; }
        public Salon? Salon { get; set; }
    }
}
