using System.ComponentModel.DataAnnotations;

namespace AcademiaAppication.Models.Account
{
    public class UserViewModel
    {
        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O primeiro nome é Obrigatótio")]
        public string? FirstName { get; set; }


        [Display(Name = "último Nome")]
        [Required(ErrorMessage = "Último nome é obrigatório")]
        public string? LastName { get; set; }


        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "email Invalido")]
        [Required(ErrorMessage = "e-mail é obrigatório")]
        public string? Email { get; set; }


        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Usuário é Obrigatório")]
        public string? UserName { get; set; }


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
