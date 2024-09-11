using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Fabricantes.Querys.BuscarFabricante
{
    public sealed record ObterTodosFabricantesQuery : IRequest<IEnumerable<Fabricante>>;
}
