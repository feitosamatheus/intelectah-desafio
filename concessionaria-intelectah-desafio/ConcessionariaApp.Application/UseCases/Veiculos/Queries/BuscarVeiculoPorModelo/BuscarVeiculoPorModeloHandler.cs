using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Veiculos.Queries.BuscarVeiculoPorModelo
{
    public sealed class BuscarVeiculoPorModeloHandler : IRequestHandler<BuscarVeiculoPorModeloQuery, IEnumerable<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ICashingService _cashingService;

        public BuscarVeiculoPorModeloHandler(IVeiculoRepository veiculoRepository, ICashingService cashingService)
        {
            _veiculoRepository = veiculoRepository;
            _cashingService = cashingService;
        }

        public async Task<IEnumerable<Veiculo>> Handle(BuscarVeiculoPorModeloQuery request, CancellationToken cancellationToken)
        {
            //var veiculosCash = await _cashingService.BuscarCacheListAsync<Veiculo>("Veiculos");

            //if (veiculosCash.Count() > 0)
            //{
            //    var filtrarVeiculoCash = veiculosCash.Where(v => v.Modelo.Equals(request.modelo));
            //    return filtrarVeiculoCash;
            //}

            var veiculosDb = await _veiculoRepository.GetAllAsync(cancellationToken);
            var filtroVeiculoDb = veiculosDb.Where(v => v.Modelo.Contains(request.modelo));
            //await _cashingService.AtualizarListaCacheAynsc("Veiculos", veiculosDb);
           
            return filtroVeiculoDb;
        }
    }
}
