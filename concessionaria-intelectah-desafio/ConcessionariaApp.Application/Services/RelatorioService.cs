using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConcessionariaApp.Application.Dtos.Relatorios;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.BuscarRelatorioVendaPorAnoMes;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarPdfRelatorioVenda;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarRelatorioVendaExcel;
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

        public async Task<RelatorioVendaDTO> BuscarRelatorioVendaPorAnoMes(FiltroRelatorioVendaDTO dto)
        {
            return  await _mediator.Send(_mapper.Map<BuscarRelatorioVendaPorAnoMesQuery>(dto));
        }

        public async Task<byte[]> GerarExcelRelatorioVenda(FiltroRelatorioVendaDTO dto)
        {
            return await _mediator.Send(_mapper.Map<GerarRelatorioVendaExcelQuery>(dto));
        }

        public async Task<byte[]> GerarPdfRelatorioVenda(GerarRelatorioVendaPdfDTO pdfRelatorio)
        {
            return await _mediator.Send(_mapper.Map<GerarRelatorioVendaPdfQuery>(pdfRelatorio));
        }
    }
}
