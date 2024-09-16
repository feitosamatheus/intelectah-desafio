using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConcessionariaApp.Application.Dtos.Relatorios;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.BuscarRelatorioVendaPorAnoMes;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarPdfRelatorioVenda;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarRelatorioVendaExcel;

namespace ConcessionariaApp.Application.Mapping
{
    public class DtoForQuery : Profile
    {
        public DtoForQuery() {
            CreateMap<FiltroRelatorioVendaDTO,BuscarRelatorioVendaPorAnoMesQuery>();       
            CreateMap<FiltroRelatorioVendaDTO, GerarRelatorioVendaExcelQuery>();       
            CreateMap<GerarRelatorioVendaPdfDTO, GerarRelatorioVendaPdfQuery>(); 
        }    
    }
}
