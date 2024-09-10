using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Fabricantes.Commands.CriarFabricante
{
    public sealed record CriarFabricanteCommand(string Nome, string PaisOrigem, int AnoFundacao, string WebSite): IRequest<ResultadoOperacao>;
}
