using ConcessionariaApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Login.Command.EncerrarSessao
{
    public sealed class EncerrarSessaoHandler : IRequestHandler<EncerrarSessaoCommand, Unit>
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public EncerrarSessaoHandler(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        public async Task<Unit> Handle(EncerrarSessaoCommand request, CancellationToken cancellationToken)
        {
            await _autenticacaoService.EncerrarSessao();
            return Unit.Value;
        }
    }
}
