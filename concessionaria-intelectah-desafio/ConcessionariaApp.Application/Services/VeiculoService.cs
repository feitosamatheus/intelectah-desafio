using AutoMapper;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Veiculos.Commands.CadastrarVeiculo;
using ConcessionariaApp.Application.UseCases.Veiculos.Queries.BuscarVeiculoPorFabricante;
using ConcessionariaApp.Application.UseCases.Veiculos.Queries.BuscarVeiculoPorModelo;
using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public VeiculoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<VeiculoFiltroDTO>> BuscarVeiculoPorModelo(string modelo)
        {
            var resultado = await _mediator.Send(new BuscarVeiculoPorModeloQuery(modelo));
            return _mapper.Map<IEnumerable<VeiculoFiltroDTO>>(resultado);

        }

        public async Task<IEnumerable<VeiculoFiltroDTO>> BuscarVeiculoPorFabricante(int fabricanteId)
        {
            var resultado = await _mediator.Send(new BuscarVeiculoPorFabricanteQuery(fabricanteId));
            return _mapper.Map<IEnumerable<VeiculoFiltroDTO>>(resultado);

        }

        public async  Task<ResultadoOperacao> CadastrarVeiculo(CadastrarVeiculoDTO dto)
        {
            return await _mediator.Send(_mapper.Map<CadastrarVeiculoCommand>(dto));
        }
    }
}
