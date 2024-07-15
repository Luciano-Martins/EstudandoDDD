using System.ComponentModel.DataAnnotations;

namespace AcademiaAppication.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string? Token { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string? Password { get; set; }


        [Display(Name = "Confirma Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        [Required(ErrorMessage = "Confirme a senha , é obrigatorio")]
        public string? PasswordConfirmed { get; set; }
    }
}
