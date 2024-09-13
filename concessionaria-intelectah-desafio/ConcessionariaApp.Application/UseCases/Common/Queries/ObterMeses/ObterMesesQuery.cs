using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Common.Queries.ObterMeses
{
    public sealed record ObterMesesQuery : IRequest<IEnumerable<MesDTO>>;
}
