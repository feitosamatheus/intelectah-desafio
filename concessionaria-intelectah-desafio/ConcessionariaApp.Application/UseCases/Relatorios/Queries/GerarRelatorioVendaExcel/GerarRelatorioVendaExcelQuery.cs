using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarRelatorioVendaExcel
{
    public sealed record GerarRelatorioVendaExcelQuery(int Ano, int Mes) : IRequest<byte[]>;
}
