using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarPdfRelatorioVenda
{
    public sealed record GerarRelatorioVendaPdfQuery(string GraficoVeiculoImagem,
                                                     string GraficoFabricanteImagem,
                                                     string HtmlPage) : IRequest<byte[]>;
}
