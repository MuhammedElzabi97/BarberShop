using System.ComponentModel.DataAnnotations;

namespace Berber_Salonu.Models
{
    public class Salon
    {
        [Key]
        public int SalonId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }= string.Empty;
        [Required]
        [StringLength(50)]
        public string WorkingHours { get; set; } = string.Empty;

        public ICollection<Service> ?Services { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
