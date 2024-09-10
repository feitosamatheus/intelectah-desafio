using ConcessionariaApp.Application.Attributes;
using ConcessionariaApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Fabricantes
{
    public class CriarFabricanteDTO
    {
        [Display(Name ="Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Pais de origem")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string PaisOrigem { get; set; }

        [Display(Name = "Ano de Fundação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [AnoFundacaoValidation]
        public int AnoFundacao { get; set; }

        [Display(Name = "Site")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Url(ErrorMessage ="A URL fornecida não é valida")]
        public string WebSite { get; set; }
    }
}
