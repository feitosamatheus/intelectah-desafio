using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace ConcessionariaApp.MVC.Controllers
{
    [Route("Veiculo")]
    [Authorize]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IFabricanteService _fabricanteService;

        public VeiculoController(IVeiculoService veiculoService, IFabricanteService fabricanteService)
        {
            _veiculoService = veiculoService;
            _fabricanteService = fabricanteService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Gerente")]
        public async Task<IActionResult> Cadastrar()
        {
            var fabricantes = await _fabricanteService.ObterTodosParticipantes();
            ViewBag.Fabricantes = new SelectList(fabricantes, "Id", "Nome");

            var AnosFabricao = new List<SelectListItem>();
            for (int i = 1920; i <= DateTime.Now.Year   ; i++)
            {
                AnosFabricao.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            ViewBag.AnosFabricao = AnosFabricao;

            var tiposVeiculos = Enum.GetValues(typeof(ETipoVeiculo))
                         .Cast<ETipoVeiculo>()
                         .Select(veiculoEnum => new SelectListItem{Value = ((int)veiculoEnum).ToString(), Text = veiculoEnum.ToString()})
                         .ToList();
            ViewBag.TipoVeiculos = tiposVeiculos;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Gerente")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarVeiculoDTO dto)
        {
            if (!ModelState.IsValid)
                return Json(new { sucesso = false, menssagem = "Verifique se todos os campos foram preenchidos." });

            var resultadoCriacao = await _veiculoService.CadastrarVeiculo(dto);
            return Json(resultadoCriacao);
        }

    }
}
