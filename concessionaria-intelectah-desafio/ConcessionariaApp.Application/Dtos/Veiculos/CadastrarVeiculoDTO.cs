using ConcessionariaApp.Application.Attributes;
using ConcessionariaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Veiculos
{
    public class CadastrarVeiculoDTO
    {
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Modelo { get; set; }

        [AnoNoFuturoValidation]
        [Display(Name = "Ano de fabricação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int AnoFabricacao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public decimal Preco { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int FabricanteId { get; set; }

        
        [Display(Name = "Tipo de Veículo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string TipoVeiculo {get; set;}

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
