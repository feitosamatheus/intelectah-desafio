using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario
{
    public sealed class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioCommand, ResultadoOperacao>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly IHashingService _hashingService;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarUsuarioHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IHashingService hashingService, IAutenticacaoService autenticacaoService)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _hashingService = hashingService;
            _autenticacaoService = autenticacaoService;
        }

        public async Task<ResultadoOperacao> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuarioPorEmailAsync(request.Email);
                if (usuario is not null)
                   return ResultadoOperacao.Falha("O e-mail fornecido já está cadastrado. Por favor, use um e-mail diferente.");

                var hashSenha = _hashingService.GerarHash(request.Senha);
                var novoUsuario = Usuario.Criar(request.Nome, request.Sobrenome, hashSenha, request.Email, ENivelAcesso.Vendedor);

                _usuarioRepository.Add(novoUsuario);
                await _unitOfWork.CommitAsync(cancellationToken);

                var usuarioAutenticacao = await _autenticacaoService.AutenticarUsuario(novoUsuario);

                return ResultadoOperacao.OK("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return ResultadoOperacao.Falha(ex.Message);
            }
        }
    }
}
