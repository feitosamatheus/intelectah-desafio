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
        Task<ResultadoOperacao> CadastrarVeiculo(CadastrarVeiculoDTO dto);
    }
}
