using System.ComponentModel.DataAnnotations;

namespace TeamTasker.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string? SurName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
