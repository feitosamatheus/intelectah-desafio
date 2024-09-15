using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Relatorios;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.BuscarRelatorioVendaPorAnoMes
{
    public sealed class BuscarRelatorioVendaPorAnoMesHandler : IRequestHandler<BuscarRelatorioVendaPorAnoMesQuery, RelatorioVendaDTO>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IConcessionariaRepository _concessionariaRepository;
        public BuscarRelatorioVendaPorAnoMesHandler(IVendaRepository vendaRepository, IFabricanteRepository fabricanteRepository, IConcessionariaRepository concessionariaRepository)
        {
            _vendaRepository = vendaRepository;
            _fabricanteRepository = fabricanteRepository;
            _concessionariaRepository = concessionariaRepository;
        }

        public async Task<RelatorioVendaDTO> Handle(BuscarRelatorioVendaPorAnoMesQuery request, CancellationToken cancellationToken)
        {
            var relatorioVenda = new RelatorioVendaDTO();
            
            var vendasFiltro = await _vendaRepository.BucarRelatorioVendaPorAnoMes(request.Mes, request.Ano);

            var vendasPorFabricante = vendasFiltro
                .GroupBy(v => v.Veiculo.Fabricante.Nome)
                .Select(group => new RelatorioFabricantesVendaDTO
                {
                    Nome = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda)
                })
                .ToList();

            var vendasPorVeiculo = vendasFiltro
                .GroupBy(v => v.Veiculo.Modelo)
                .Select(group => new RelatorioVeiculosVendaDTO
                {
                    Modelo = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda)
                })
                .ToList();

            var vendasPorConcessionaria = vendasFiltro
                .GroupBy(v => v.Concessionaria.Nome)
                .Select(group => new RelatorioConcessionariaVendaDTO
                {
                    Nome = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda),
                    VeiculoMaisVendido = group
                        .GroupBy(v => v.Veiculo.Modelo) 
                        .Select(veiculoGroup => new RelatorioVeiculosVendaDTO
                        {
                            Modelo = veiculoGroup.Key,
                            QtdVendas = veiculoGroup.Count(),
                            TotalVenda = veiculoGroup.Sum(v => v.PrecoVenda)
                        })
                        .OrderByDescending(v => v.QtdVendas)
                        .FirstOrDefault() 
                }).ToList();

            relatorioVenda.TotalVendas = vendasFiltro.Sum(v => v.PrecoVenda);
            relatorioVenda.QtdVendas = vendasFiltro.Count();
            relatorioVenda.RelatorioVeiculos = vendasPorVeiculo;
            relatorioVenda.RelatorioFabricantes = vendasPorFabricante;
            relatorioVenda.RelatorioConcessionarias = vendasPorConcessionaria;

            return relatorioVenda; 
        }
    }
}
