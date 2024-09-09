using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.EncerrarSessao
{
    public sealed record EncerrarSessaoCommand() : IRequest<Unit>;
}
