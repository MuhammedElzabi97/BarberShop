using Microsoft.AspNetCore.Identity;

namespace WebProjesi.Models
{
    public class Kullanici : IdentityUser 
    {
        public string Ad { get; set; }

        public List<Randevu> Randevular { get; set; } = new List<Randevu>();


    }
}
