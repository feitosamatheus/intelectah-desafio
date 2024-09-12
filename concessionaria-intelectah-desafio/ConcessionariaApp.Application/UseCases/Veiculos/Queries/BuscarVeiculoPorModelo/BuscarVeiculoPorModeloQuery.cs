using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Veiculos.Queries.BuscarVeiculoPorModelo
{
    public sealed record BuscarVeiculoPorModeloQuery(string modelo) : IRequest<IEnumerable<Veiculo>>;
}
