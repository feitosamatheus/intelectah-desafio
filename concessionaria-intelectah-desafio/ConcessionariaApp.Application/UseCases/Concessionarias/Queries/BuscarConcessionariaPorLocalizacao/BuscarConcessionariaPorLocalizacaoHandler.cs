using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorLocalizacao
{
    public sealed class BuscarConcessionariaPorLocalizacaoHandler : IRequestHandler<BuscarConcessionariaPorLocalizacaoQuery, IEnumerable<Concessionaria>>
    {
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly ICashingService _cashingService;

        public BuscarConcessionariaPorLocalizacaoHandler(IConcessionariaRepository concessionariaRepository, ICashingService cashingService)
        {
            _concessionariaRepository = concessionariaRepository;
            _cashingService = cashingService;
        }

        public async Task<IEnumerable<Concessionaria>> Handle(BuscarConcessionariaPorLocalizacaoQuery request, CancellationToken cancellationToken)
        {
            //var concessionariaCash = await _cashingService.BuscarCacheListAsync<Concessionaria>("Concessionarias");

            //if (concessionariaCash.Count() > 0)
            //{
            //    var filtrarConcessionariaCash = concessionariaCash.Where(c => c.Endereco.EnderecoCompleto.Contains(request.Localizacao));
            //    return filtrarConcessionariaCash;
            //}

            var concessionariaDb = await _concessionariaRepository.GetAllAsync(cancellationToken);
            var filtroConcessionariaDb = concessionariaDb.Where(c => c.Endereco.EnderecoCompleto.ToUpper().Contains(request.Localizacao.ToUpper()));
            //await _cashingService.AtualizarListaCacheAynsc("Concessionarias", concessionariaDb);

            return filtroConcessionariaDb;
        }
    }
}
