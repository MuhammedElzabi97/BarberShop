using System.ComponentModel.DataAnnotations;

namespace Berber_Salonu.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Specialization { get; set; } = string.Empty;// Uzmanlasma التخصص

        [Required]
        [StringLength(50)]
        public string Availability { get; set; } = string.Empty;

        // Foreign Key

        [Required]
        public int SalonId { get; set; }
        public Salon? Salon { get; set; } // لما تجيب بيانات موظف، هاي الخاصية  بتعطيك معلومات الصالون اللي هو تابع له.
        
        //Navigation properties
        public ICollection<Booking>? Bookings { get; set; }//rezervasoyn

    }
}