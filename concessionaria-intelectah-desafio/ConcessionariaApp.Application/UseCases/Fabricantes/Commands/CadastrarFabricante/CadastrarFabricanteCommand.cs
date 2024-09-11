using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Fabricantes.Commands.CadastrarFabricante
{
    public sealed record CadastrarFabricanteCommand(string Nome, string PaisOrigem, int AnoFundacao, string WebSite): IRequest<ResultadoOperacao>;
}
