using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Relatorios
{
    public class RelatorioVendaDTO
    {
        public decimal TotalVendas { get; set; }
        public int QtdVendas { get; set; }
        public List<RelatorioVeiculosVendaDTO> RelatorioVeiculos { get; set; }
        public List<RelatorioFabricantesVendaDTO> RelatorioFabricantes { get; set; }
        public List<RelatorioConcessionariaVendaDTO> RelatorioConcessionarias { get; set; }
    }
}
