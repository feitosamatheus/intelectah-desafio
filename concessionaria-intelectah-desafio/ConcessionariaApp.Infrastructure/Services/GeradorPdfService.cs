using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Interfaces;
using iText.Html2pdf;
using iText.Kernel.Pdf;

namespace ConcessionariaApp.Infrastructure.Services
{
    public class GeradorPdfService : IGeradorPdfService
    {
        public byte[] CreatePdfFromHtml(string htmlContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Crie um PdfWriter a partir do MemoryStream
                var pdfWriter = new PdfWriter(memoryStream);

                // Crie um PdfDocument com o PdfWriter
                var pdfDocument = new PdfDocument(pdfWriter);

                // Crie um documento PDF usando o HtmlConverter
                var converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlContent, pdfDocument, converterProperties);

                // Retorne o conteúdo do PDF como um array de bytes
                return memoryStream.ToArray();
            }
        }
    }
}
