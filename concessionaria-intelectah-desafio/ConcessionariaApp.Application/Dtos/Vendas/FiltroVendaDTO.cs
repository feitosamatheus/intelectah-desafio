using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Vendas
{
    public class FiltroVendaDTO
    {
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres.")]
        public string Modelo { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int FabricanteId { get; set; }
    }
}
