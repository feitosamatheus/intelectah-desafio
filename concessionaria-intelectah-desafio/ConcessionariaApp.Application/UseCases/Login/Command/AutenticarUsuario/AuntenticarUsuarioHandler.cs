using AutoMapper;
using ConcessionariaApp.Application.Dtos.Login;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario
{
    public sealed class AuntenticarUsuarioHandler : IRequestHandler<AutenticarUsuarioCommand, ResultadoOperacao>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly IHashingService _hashingService;
        private readonly IMapper _mapper;


        public AuntenticarUsuarioHandler(IUsuarioRepository usuarioRepository, IHashingService hashingService, IMapper mapper, IAutenticacaoService autenticacaoService)
        {
            _usuarioRepository = usuarioRepository;
            _hashingService = hashingService;
            _mapper = mapper;
            _autenticacaoService = autenticacaoService;
        }

        public async Task<ResultadoOperacao> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorEmailAsync(request.Email);
            if (usuario is null)
                return ResultadoOperacao.Falha("Usuário ou/e senha inválido.");

            var validacaoResultado = _hashingService.ValidarHash(request.Senha, usuario.Senha);
            if (!validacaoResultado)
                return ResultadoOperacao.Falha("Usuário ou/e senha inválido.");

            var usuarioAutenticacao = await _autenticacaoService.AutenticarUsuario(usuario);

            if(!usuarioAutenticacao)
                return ResultadoOperacao.Falha("Usuário ou/e senha inválido.");

            return ResultadoOperacao.OK("Usuário autenticado com sucesso.");
        }
    }
}
