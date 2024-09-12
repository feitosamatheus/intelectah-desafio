using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorNome
{
    public sealed record BuscarConcessionariaPorNomeQuery(string Nome) : IRequest<IEnumerable<Concessionaria>>;
}
