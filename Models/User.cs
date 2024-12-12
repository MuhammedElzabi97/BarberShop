using System.ComponentModel.DataAnnotations;

namespace Berber_Salonu.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name {  get; set; }= string .Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Customer";


        // Navigation Properties
        public ICollection<Booking>? Bookings { get; set; }
    }
}