using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario
{
    public sealed record RegistrarUsuarioCommand(
        string Nome, 
        string Sobrenome, 
        string Email, 
        string Senha): IRequest<ResultadoOperacao>;
}
