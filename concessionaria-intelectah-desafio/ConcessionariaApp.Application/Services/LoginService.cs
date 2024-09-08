using AutoMapper;
using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario;
using ConcessionariaApp.Application.UseCases.Login.Command.CriarUsuario;
using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoginService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ResultadoOperacao> Login(AutenticarUsuarioDTO dto)
        {
            return await _mediator.Send(_mapper.Map<AutenticarUsuarioCommand>(dto));
        }

        public async Task<ResultadoOperacao> Registrar(RegistrarUsuarioDTO dto)
        {
            return await _mediator.Send(_mapper.Map<RegistrarUsuarioCommand>(dto));
        }
    }
}
