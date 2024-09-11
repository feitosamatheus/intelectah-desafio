using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Queries.BuscarVeiculoPorFiltroVenda
{
    public sealed class BuscarVeiculoPorFiltroVendaHandler : IRequestHandler<BuscarVeiculoPorFiltroVendaQuery, IEnumerable<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public BuscarVeiculoPorFiltroVendaHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<Veiculo>> Handle(BuscarVeiculoPorFiltroVendaQuery request, CancellationToken cancellationToken)
        {
            if (request.Modelo is not null && request.FabricanteId != 0)
                return await _veiculoRepository.BucarVeiculoPorFabricanteModelo(request.Modelo, request.FabricanteId);

            if (request.Modelo is not null)
                return await _veiculoRepository.BucarVeiculoPorModelo(request.Modelo);

            
            return await _veiculoRepository.BucarVeiculoPorFabricante(request.FabricanteId);
        }
    }
}
