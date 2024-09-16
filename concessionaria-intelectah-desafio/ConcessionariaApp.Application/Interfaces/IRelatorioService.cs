using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;
using ConcessionariaApp.Application.Dtos.Relatorios;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<RelatorioVendaDTO> BuscarRelatorioVendaPorAnoMes(FiltroRelatorioVendaDTO dto);
        Task<byte[]> GerarExcelRelatorioVenda(FiltroRelatorioVendaDTO dto);
        Task<byte[]> GerarPdfRelatorioVenda(GerarRelatorioVendaPdfDTO pdfRelatorio);
    }
}
