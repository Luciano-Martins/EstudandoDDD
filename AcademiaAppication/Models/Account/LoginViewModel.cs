using System.ComponentModel.DataAnnotations;

namespace AcademiaAppication.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Usuário é Obrigatório")]
        public string? UserName { get; set; }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha é Obrigatório")]
        public string? Password { get; set; }
    }
}
