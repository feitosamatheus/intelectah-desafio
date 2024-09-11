using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda
{
    public sealed record RegistrarVendaCommand() : IRequest<ResultadoOperacao>;
}
