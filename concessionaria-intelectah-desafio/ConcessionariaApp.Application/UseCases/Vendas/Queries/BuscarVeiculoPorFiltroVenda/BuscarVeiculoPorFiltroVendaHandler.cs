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
            return await _veiculoRepository.BucarVeiculoPorProdutoModelo(request.Modelo, request.FabricanteId);
        }
    }
}
