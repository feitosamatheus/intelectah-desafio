using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarEnderecoPorCep
{
    public sealed class BuscarEnderecoPorCepHandler : IRequestHandler<BuscarEnderecoPorCepQuery, Endereco>
    {
        private readonly ICepService _cepService;

        public BuscarEnderecoPorCepHandler(ICepService cepService)
        {
            _cepService = cepService;
        }

        public async Task<Endereco> Handle(BuscarEnderecoPorCepQuery request, CancellationToken cancellationToken)
        {
            return await _cepService.BuscarEnderecoPorCep(request.cep);
        }
    }
}
