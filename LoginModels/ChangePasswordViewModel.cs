using System.ComponentModel.DataAnnotations;

namespace WebProjesi.LoginModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password zorunludur.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Şifre en az 8 karakter olmalıdır.", MinimumLength = 8)]
        [Compare("ConfirmNewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "conrirm password is requird.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
