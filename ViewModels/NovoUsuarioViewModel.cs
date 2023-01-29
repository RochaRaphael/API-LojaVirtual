using System.ComponentModel.DataAnnotations;

namespace API_LojaVirtual.ViewModels
{
    public class NovoUsuarioViewModel
    {
        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira a senha")]
        public string Senha { get; set; }
    }
}
