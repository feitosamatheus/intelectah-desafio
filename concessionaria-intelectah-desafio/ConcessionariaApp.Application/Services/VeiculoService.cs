using AutoMapper;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Veiculos.Commands;
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

        public async  Task<ResultadoOperacao> CadastrarVeiculo(CadastrarVeiculoDTO dto)
        {
            return await _mediator.Send(_mapper.Map<CadastrarVeiculoCommand>(dto));
        }
    }
}
