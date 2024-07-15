using System.ComponentModel.DataAnnotations;

namespace AcademiaAppication.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = " E-mail é Obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string? Email { get; set; }
    }
}
