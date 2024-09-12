using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Controllers
{
    [Authorize]
    [Route("Fabricante")]
    public class FabricanteController : Controller
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("CadastrarFabricante")]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarFabricante([FromBody] CadastrarFabricanteDTO dto)
        {
            if (!ModelState.IsValid)
                return Json(new
                {
                    sucesso = false,
                    menssagem = "Verifique se todos os campos foram preenchidos. Lembrando ano tem que ser maior que 1855."
                });

            var resultadoCriacao = await _fabricanteService.CadastrarFabricante(dto);

            return Json(resultadoCriacao);
        }
    }
}
