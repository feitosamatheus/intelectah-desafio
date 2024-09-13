using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;

namespace ConcessionariaApp.Application.Dtos.Relatorios
{
    public class FiltroRelatorioVendaDTO
    {
        [Display(Name = "Mês")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Mes { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "O campo {0} Ano é obrigatório.")]
        public int Ano { get; set; }
    }
}
