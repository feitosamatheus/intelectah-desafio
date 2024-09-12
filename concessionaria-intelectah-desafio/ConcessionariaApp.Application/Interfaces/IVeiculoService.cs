using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoFiltroDTO>> BuscarVeiculoPorFabricante(int fabricanteId);
        Task<IEnumerable<VeiculoFiltroDTO>> BuscarVeiculoPorModelo(string modelo);
        Task<ResultadoOperacao> CadastrarVeiculo(CadastrarVeiculoDTO dto);
    }
}
