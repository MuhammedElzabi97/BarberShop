using Microsoft.AspNetCore.Identity;

namespace WebProjesi.Models
{
    public class Kullanici : IdentityUser 
    {
        public string Ad { get; set; }
    }
}
