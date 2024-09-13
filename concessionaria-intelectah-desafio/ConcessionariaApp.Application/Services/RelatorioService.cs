using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConcessionariaApp.Application.Interfaces;
using MediatR;

namespace ConcessionariaApp.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RelatorioService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
