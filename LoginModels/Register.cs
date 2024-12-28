using System.ComponentModel.DataAnnotations;

namespace WebProjesi.LoginModels
{
    public class Register
    {
        [Required(ErrorMessage ="Ad zorunludur.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password zorunludur.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Şifre en az 3 karakter olmalıdır.", MinimumLength = 3)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreler uyuşmuyor.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
