using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda
{
    public sealed class RegistrarVendaHandler : IRequestHandler<RegistrarVendaCommand, ResultadoOperacao>
    {
        private readonly IVendaRepository _vendaRepository;

        public RegistrarVendaHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Task<ResultadoOperacao> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
