using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.CriarUsuario
{
    public sealed class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioCommand, ResultadoOperacao>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegistrarUsuarioHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<ResultadoOperacao> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _authenticationService.BuscarUsuarioPorEmailAsync(request.Email);
                if (usuario is not null)
                    return ResultadoOperacao.Falha("O e-mail fornecido já está cadastrado. Por favor, use um e-mail diferente.");

                var novoUsuario = Usuario.Criar(request.Nome, request.Sobrenome, request.Senha, request.Email, ENivelAcesso.Vendedor);
                var resultado = await _authenticationService.CriarUsuarioAsync(novoUsuario);

                return resultado;
            }
            catch
            {
                return ResultadoOperacao.Falha("Não foi possível completar a solicitação.");
            }
        }
    }
}
