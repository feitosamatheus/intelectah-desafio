using ConcessionariaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Autenticacao
{
    public class RegistrarUsuarioDTO
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sobrenome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não coincidem.")]
        public string SenhaConfirmacao { get; set; }

    }
}
