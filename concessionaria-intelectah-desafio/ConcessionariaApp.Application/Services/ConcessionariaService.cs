using AutoMapper;
using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias;
using ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorLocalizacao;
using ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorNome;
using ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarEnderecoPorCep;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.ValueObjects;
using MediatR;
using System.Runtime.ConstrainedExecution;

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

        public async Task<IEnumerable<ConcessionariaFiltroDTO>> BuscarConcessionariaPorLocalizacao(string localizacao)
        {
            var resultado =  await _mediator.Send(new BuscarConcessionariaPorLocalizacaoQuery(localizacao));
            return _mapper.Map<IEnumerable<ConcessionariaFiltroDTO>>(resultado);
        }

        public async Task<IEnumerable<ConcessionariaFiltroDTO>> BuscarConcessionariaPorNome(string nome)
        {
            var resultado = await _mediator.Send(new BuscarConcessionariaPorNomeQuery(nome));
            return _mapper.Map<IEnumerable<ConcessionariaFiltroDTO>>(resultado);
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
