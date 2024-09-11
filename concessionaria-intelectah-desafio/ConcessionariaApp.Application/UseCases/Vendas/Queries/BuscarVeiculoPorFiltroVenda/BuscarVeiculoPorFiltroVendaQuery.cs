using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Queries.BuscarVeiculoPorFiltroVenda
{
    public sealed record BuscarVeiculoPorFiltroVendaQuery(string Modelo, int FabricanteId) : IRequest<IEnumerable<Veiculo>>;
}
