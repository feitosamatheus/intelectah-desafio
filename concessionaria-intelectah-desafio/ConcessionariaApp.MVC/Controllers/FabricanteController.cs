using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Controllers
{
    [Route("Fabricante")]
    public class FabricanteController : Controller
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Criar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarFabricante([FromBody] CriarFabricanteDTO dto)
        {
            if (!ModelState.IsValid)
                return Json(new
                {
                    sucesso = false,
                    menssagem = "Verifique se todos os campos foram preenchidos."
                });

            var resultadoCriacao = await _fabricanteService.CriarFabricante(dto);

            return Json(resultadoCriacao);
        }
    }
}
