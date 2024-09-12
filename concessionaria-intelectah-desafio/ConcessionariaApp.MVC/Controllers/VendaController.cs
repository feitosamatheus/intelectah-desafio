using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcessionariaApp.MVC.Controllers
{
    [Route("Venda")]
    [Authorize]
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IVeiculoService _veiculoService;
        private readonly IConcessionariaService _concessionariaService;
        private readonly IFabricanteService _fabricanteService;


        public VendaController(IVendaService vendaService, IFabricanteService fabricanteService, IVeiculoService veiculoService, IConcessionariaService concessionariaService)
        {
            _vendaService = vendaService;
            _fabricanteService = fabricanteService;
            _veiculoService = veiculoService;
            _concessionariaService = concessionariaService;
        }

        [HttpGet("Registrar")]
        public async Task<IActionResult> Registrar()
        {
            ViewBag.FiltroVeiculo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Modelo", Value = "Modelo" },
                new SelectListItem { Text = "Fabricante", Value = "Fabricante" },
            };

            ViewBag.FiltroConcessionaria = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nome", Value = "Nome" },
                new SelectListItem { Text = "Localização", Value = "Localizacao" },
            };

            var fabricantes = await _fabricanteService.ObterTodosParticipantes();
            ViewBag.Fabricantes = new SelectList(fabricantes, "Id", "Nome");

            return View();
        }
       
        [HttpPost("RegistrarVenda")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([FromBody] RegistrarVendaDTO dto)
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

        [HttpPost("BuscarVeiculoPorModeloFabricante")]
        public async Task<IActionResult> BuscarVeiculoPorModeloFabricante([FromBody] FiltroVendaDTO dto)
        {
            var resultado = await _vendaService.BuscarVeiculoPorFiltro(dto);
            return PartialView("Partial/_RelatorioVeiculo", resultado);
        }

        [HttpGet("BuscarVeiculoPorModelo")]
        public async Task<IActionResult> BuscarVeiculoPorModelo([FromQuery] string modelo)
        {
            var resultado = await _veiculoService.BuscarVeiculoPorModelo(modelo);
            return Json(resultado);
        }

        [HttpGet("BuscarVeiculoPoFabricante")]
        public async Task<IActionResult> BuscarVeiculoPoFabricante([FromQuery] int fabricanteId)
        {
            var resultado = await _veiculoService.BuscarVeiculoPorFabricante(fabricanteId);
            return Json(resultado);
        }
        
        [HttpGet("BuscarConcessionariaPorLocalizacao")]
        public async Task<IActionResult> BuscarConcessionariaPorLocalizacao([FromQuery] string localizacao)
        {
            IEnumerable<ConcessionariaFiltroDTO> resultado = await _concessionariaService.BuscarConcessionariaPorLocalizacao(localizacao);
            return Json(resultado);
        }

        [HttpGet("BuscarConcessionariaPorNome")]
        public async Task<IActionResult> BuscarConcessionariaPorNome([FromQuery] string nome)
        {
            IEnumerable<ConcessionariaFiltroDTO> resultado = await _concessionariaService.BuscarConcessionariaPorNome(nome);
            return Json(resultado);
        }

    }
}
