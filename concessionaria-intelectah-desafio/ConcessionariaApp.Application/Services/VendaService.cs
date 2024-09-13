using AutoMapper;
using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda;
using ConcessionariaApp.Application.UseCases.Vendas.Queries.BuscarVeiculoPorFiltroVenda;
using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public VendaService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao> RegistrarVenda(RegistrarVendaDTO dto)
        {
            return _mediator.Send(_mapper.Map<RegistrarVendaCommand>(dto));
        }
    }
}
