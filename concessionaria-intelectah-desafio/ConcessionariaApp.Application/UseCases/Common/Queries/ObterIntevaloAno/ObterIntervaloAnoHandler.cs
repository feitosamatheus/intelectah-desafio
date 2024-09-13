using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Common.Queries.ObterIntevaloAno
{
    public sealed class ObterIntervaloAnoHandler : IRequestHandler<ObterIntervaloAnoQuery, IEnumerable<AnoDTO>>
    {
        public Task<IEnumerable<AnoDTO>> Handle(ObterIntervaloAnoQuery request, CancellationToken cancellationToken)
        {
            var anos = Enumerable.Range(request.anoInicial, request.anoFinal - request.anoInicial + 1)
                             .Select(a => new AnoDTO { Ano = a });

            return Task.FromResult(anos);
        }
    }
}
