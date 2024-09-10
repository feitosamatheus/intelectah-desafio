using AutoMapper;
using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Fabricantes.Commands.CriarFabricante;
using ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario;
using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Services
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FabricanteService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ResultadoOperacao> CriarFabricante(CriarFabricanteDTO dto)
        {
            return await _mediator.Send(_mapper.Map<CriarFabricanteCommand>(dto));

        }
    }
}
