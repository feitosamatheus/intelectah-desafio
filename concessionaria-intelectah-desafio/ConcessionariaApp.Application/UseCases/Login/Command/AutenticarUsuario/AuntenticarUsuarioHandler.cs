using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario
{
    public sealed class AuntenticarUsuarioHandler : IRequestHandler<AutenticarUsuarioCommand, ResultadoOperacao>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuntenticarUsuarioHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<ResultadoOperacao> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authenticationService.BuscarUsuarioPorEmailAsync(request.Email);

            if (usuario is null)
                return ResultadoOperacao.Falha("Usuário não encontrado.");

            var usuarioResultado = await _authenticationService.LoginUsuarioAsync(usuario);

            return usuarioResultado;
        }
    }
}
