using ConcessionariaApp.Application.Dtos.Relatorios;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaApp.MVC.Controllers
{
    [Authorize]
    [Route("Relatorio")]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioService _relatorioService;
        private readonly ICommonService _commonService;

        public RelatorioController(IRelatorioService relatorioService, ICommonService commonService)
        {
            _relatorioService = relatorioService;
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<IActionResult> RelatorioVenda()
        {
            var AnosLista = await _commonService.ObterIntervaloAno(2000, DateTime.Now.Year);
            ViewBag.AnosLista = new SelectList(AnosLista, "Ano", "Ano");

            var MesesLista = await _commonService.ObterMeses();
            ViewBag.MesesLista = new SelectList(MesesLista, "Valor", "Nome");

            return View();
        }

        [HttpPost("BuscarRelatorioVenda")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscarRelatorioVenda([FromBody] FiltroRelatorioVendaDTO dto)
        {
            var relatorio = await _relatorioService.BuscarRelatorioVendaPorAnoMes(dto);

            return PartialView("Partial/_RelatorioVenda", relatorio);
        }

        [HttpPost("GerarPdfRelatorioVenda")]
        public async Task<IActionResult> GerarPdfRelatorioVenda([FromBody] GerarRelatorioVendaPdfDTO pdfRelatorio)
        {
            var corpoHtmlInicio = "<!DOCTYPE html><html><head><style>h5{font-size: 28px;text-align: center;margin: 20px;padding: 10px;}ul{text-align: center;list-style: none;padding: 0;}ul li{display: inline-block;margin-right: 30px;}h6{text-decoration:underline;text-align: center;margin-top:60px; font-size: 16px;}table{width: 80%; margin: 0 auto;text-align: center;}#myChart{display: none;}#myCharts{display: none;}.table-responsive-custom{display: flex;justify-content: center;margin-bottom: 50px;}</style></head><body>";
            var corpoHtmlFim = "</body></html>";

            pdfRelatorio.HtmlPage = corpoHtmlInicio + pdfRelatorio.HtmlPage + corpoHtmlFim;

            //pdfRelatorio.HtmlPage = style + pdfRelatorio.HtmlPage;
            byte[] file = await _relatorioService.GerarPdfRelatorioVenda(pdfRelatorio);
            return File(file, "application/pdf", "document.pdf");
        }
    }
}
