using ConcessionariaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Dtos.Vendas
{
    public class VeiculoVendaDTO
    {
        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public decimal Preco { get; private set; }
        public int FabricanteId { get; private set; }
        public ETipoVeiculo TipoVeiculo { get; private set; }
        public string Descricao { get; set; }
    }
}
