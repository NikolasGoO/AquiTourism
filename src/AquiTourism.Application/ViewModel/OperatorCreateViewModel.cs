using System.ComponentModel.DataAnnotations;

namespace AquiTourism.Application.ViewModel
{
    public class OperatorCreateViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha.")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}