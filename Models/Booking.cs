using System.ComponentModel.DataAnnotations;

namespace Berber_Salonu.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int  UserId {get; set;}

        [Required]
        public int EmployeeId { get; set;}

        [Required]
        public int ServecId { get; set;}

        [Required]
        public DateTime Date { get; set;}

        [Required]
        [StringLength(20)]
        public string Time { get; set;}= string.Empty;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Bekleyen"; //(Bekleyen, Onaylanan, İptal Edilen)

        // Navigation Properties
        public User ?User {  get; set;}
        public Employee? Employee { get; set; }
        public Service? Service { get; set; }
    }
}