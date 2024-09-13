using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConcessionariaApp.Application.Dtos.Common;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Common.Queries.ObterIntevaloAno;
using ConcessionariaApp.Application.UseCases.Common.Queries.ObterMeses;
using MediatR;

namespace ConcessionariaApp.Application.Services
{
    public class CommonService : ICommonService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CommonService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<AnoDTO>> ObterIntervaloAno(int anoInicial, int anoFinal)
        {
            return await _mediator.Send(new ObterIntervaloAnoQuery(anoInicial, anoFinal));
        }

        public async Task<IEnumerable<MesDTO>> ObterMeses()
        {
            return await _mediator.Send(new ObterMesesQuery());
        }
    }
}
