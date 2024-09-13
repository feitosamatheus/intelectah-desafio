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

        [HttpPost]
        public async Task<IActionResult> RelatorioVenda(FiltroRelatorioVendaDTO dto)
        {
            
            return View();
        }
    }
}
