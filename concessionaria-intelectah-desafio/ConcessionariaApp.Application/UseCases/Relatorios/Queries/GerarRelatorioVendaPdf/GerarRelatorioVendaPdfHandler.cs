using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarPdfRelatorioVenda;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarRelatorioVendaPdf
{
    public sealed class GerarRelatorioVendaPdfHandler : IRequestHandler<GerarRelatorioVendaPdfQuery, byte[]>
    {
        private readonly IGeradorPdfService geradorPdf;

        public GerarRelatorioVendaPdfHandler(IGeradorPdfService geradorPdf)
        {
            this.geradorPdf = geradorPdf;
        }

        public async Task<byte[]> Handle(GerarRelatorioVendaPdfQuery request, CancellationToken cancellationToken)
        {
            var bytepdf = geradorPdf.CreatePdfFromHtml(request.HtmlPage);
            return bytepdf;
        }
    }
}
