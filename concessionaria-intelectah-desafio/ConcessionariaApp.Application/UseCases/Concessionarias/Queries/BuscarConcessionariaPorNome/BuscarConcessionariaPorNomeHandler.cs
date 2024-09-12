using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorNome
{
    public sealed class BuscarConcessionariaPorNomeHandler : IRequestHandler<BuscarConcessionariaPorNomeQuery, IEnumerable<Concessionaria>>
    {
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly ICashingService _cashingService;

        public BuscarConcessionariaPorNomeHandler(IConcessionariaRepository concessionariaRepository, ICashingService cashingService)
        {
            _concessionariaRepository = concessionariaRepository;
            _cashingService = cashingService;
        }

        public async Task<IEnumerable<Concessionaria>> Handle(BuscarConcessionariaPorNomeQuery request, CancellationToken cancellationToken)
        {
            //var concessionariaCash = await _cashingService.BuscarCacheListAsync<Concessionaria>("Concessionarias");

            //if (concessionariaCash.Count() > 0)
            //{
            //    var filtrarConcessionariaCash = concessionariaCash.Where(c => c.Nome.Contains(request.Nome));
            //    return filtrarConcessionariaCash;
            //}

            var concessionariaDb = await _concessionariaRepository.GetAllAsync(cancellationToken);
            var filtroConcessionariaDb = concessionariaDb.Where(c => c.Nome.Contains(request.Nome));
            //await _cashingService.AtualizarListaCacheAynsc("Concessionarias", concessionariaDb);

            return filtroConcessionariaDb;
        }
    }
}
