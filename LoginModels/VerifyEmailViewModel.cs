using System.ComponentModel.DataAnnotations;

namespace WebProjesi.LoginModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
