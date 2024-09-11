using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Fabricantes.Querys.BuscarFabricante
{
    public sealed class ObterTodosFabricantesHandler : IRequestHandler<ObterTodosFabricantesQuery, IEnumerable<Fabricante>>
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly ICashingService _cashingService;

        public ObterTodosFabricantesHandler(IFabricanteRepository fabricanteRepository, ICashingService cashingService)
        {
            _fabricanteRepository = fabricanteRepository;
            _cashingService = cashingService;
        }

        public async Task<IEnumerable<Fabricante>> Handle(ObterTodosFabricantesQuery request, CancellationToken cancellationToken)
        {
            //var fabricantesCash = await _cashingService.BuscarCacheListAsync<Fabricante>("Fabricantes");

            //if (fabricantesCash.Count() > 0)
            //{
            //    return fabricantesCash;
            //}

            var fabricanteDb = await _fabricanteRepository.GetAllAsync(cancellationToken);
            //await _cashingService.AtualizarListaCacheAynsc("Fabricantes", fabricanteDb);
            return fabricanteDb;
        }
    }
}
