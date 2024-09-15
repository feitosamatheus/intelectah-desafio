using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Relatorios
{
    public class GerarRelatorioVendaPdfDTO
    {
        public string GraficoVeiculoImagem { get; set; }
        public string GraficoFabricanteImagem { get; set; }
        public string HtmlPage { get; set; }
    }
}
