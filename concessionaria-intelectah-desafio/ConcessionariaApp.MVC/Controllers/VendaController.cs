using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcessionariaApp.MVC.Controllers
{
    [Route("Venda")]
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IFabricanteService _fabricanteService;


        public VendaController(IVendaService vendaService, IFabricanteService fabricanteService)
        {
            _vendaService = vendaService;
            _fabricanteService = fabricanteService;
        }

        [HttpGet("Registrar")]
        public async Task<IActionResult> Registrar()
        {
            var fabricantes = await _fabricanteService.ObterTodosParticipantes();
            ViewBag.Fabricantes = new SelectList(fabricantes, "Id", "Nome");

            return View();
        }
        
        [HttpPost("BuscarVeiculoPorModeloFabricante")]
        public IActionResult BuscarVeiculoPorModeloFabricante([FromBody] FiltroVendaDTO dto)
        {
            var resultado = _vendaService.BuscarVeiculoPorFiltro(dto);
            return PartialView("Partial/_RelatorioVeiculo.cshtml", resultado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarVendaDTO dto)
        {
            if (!ModelState.IsValid)
                return Json(new
                {
                    sucesso = false,
                    menssagem = "Verifique se todos os campos foram preenchidos."
                });

            var resultadoRegistro = await _vendaService.RegistrarVenda(dto);

            return Json(resultadoRegistro);
        }
    }
}
