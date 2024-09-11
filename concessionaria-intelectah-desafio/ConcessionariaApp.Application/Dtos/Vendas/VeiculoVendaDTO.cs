using ConcessionariaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Vendas
{
    public class VeiculoVendaDTO
    {
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Modelo { get; set; }

        [Display(Name = "Ano de fabricação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int AnoFabricacao { get; set; }

        [Display(Name = "Preço")]
        public string Preco { get; set; }

        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }

        [Display(Name = "Tipo de Veículo")]
        public string TipoVeiculo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string FabricanteNome { get; set; }
    }
}
