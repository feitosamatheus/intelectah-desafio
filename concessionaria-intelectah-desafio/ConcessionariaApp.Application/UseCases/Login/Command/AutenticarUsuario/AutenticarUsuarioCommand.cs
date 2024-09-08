using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario
{
    public sealed record AutenticarUsuarioCommand(string Email, string Senha) : IRequest<ResultadoOperacao>;
}
