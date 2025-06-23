using System.ComponentModel.DataAnnotations;

namespace AquiTourism.Application.ViewModel
{
    public class OperatorResetPasswordViewModel
    {
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Nova Senha é obrigatório.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha.")]
        [Compare("NewPassword", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}