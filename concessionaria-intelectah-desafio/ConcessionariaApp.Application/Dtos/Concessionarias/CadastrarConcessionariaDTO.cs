using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Concessionarias
{
    public class CadastrarConcessionariaDTO
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string EnderecoCompleto { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Estado { get; set; }
        
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CEP { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "Capacidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]

        public string CapacidadeMaxima { get; set; }

    }
}
