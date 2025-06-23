using System.ComponentModel.DataAnnotations;

namespace AquiTourism.Application.ViewModel
{
    public class OperatorLoginViewModel
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Password { get; set; }
    }
}