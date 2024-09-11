using AutoMapper;
using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias;
using ConcessionariaApp.Application.UseCases.Concessionarias.Querys;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Services
{
    public class ConcessionariaService : IConcessionariaService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ConcessionariaService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async  Task<Endereco> BuscarEnderecoPorCep(string cep)
        {
           return await _mediator.Send(new BuscarEnderecoPorCepQuery(cep));
        }

        public async Task<ResultadoOperacao> CadastrarConcessionaria(CadastrarConcessionariaDTO dto)
        {
           return await _mediator.Send(_mapper.Map<CadastrarConcessionariaCommand>(dto));
        }
    }
}
