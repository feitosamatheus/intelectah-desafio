using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Veiculos.Queries.BuscarVeiculoPorFabricante
{
    public sealed record BuscarVeiculoPorFabricanteQuery(int fabricanteId) : IRequest<IEnumerable<Veiculo>>;
    
}
