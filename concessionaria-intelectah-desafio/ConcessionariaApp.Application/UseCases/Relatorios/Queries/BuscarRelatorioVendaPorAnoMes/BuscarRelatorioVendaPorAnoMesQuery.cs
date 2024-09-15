using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Relatorios;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.BuscarRelatorioVendaPorAnoMes
{
    public sealed record BuscarRelatorioVendaPorAnoMesQuery(int Mes, int Ano) : IRequest<RelatorioVendaDTO>;
}
