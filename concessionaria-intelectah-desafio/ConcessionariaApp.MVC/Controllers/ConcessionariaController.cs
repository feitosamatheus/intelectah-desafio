using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Controllers
{
    [Authorize]
    [Route("Concessionaria")]
    public class ConcessionariaController : Controller
    {
        private readonly IConcessionariaService _concessionariaService;

        public ConcessionariaController(IConcessionariaService concessionariaService)
        {
            _concessionariaService = concessionariaService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarConcessionariaDTO dto)
        {
            if (!ModelState.IsValid)
                return Json(new { sucesso = false, menssagem = "Verifique se todos os campos foram preenchidos." });

            var resultadoCriacao = await _concessionariaService.CadastrarConcessionaria(dto);
            return Json(resultadoCriacao);
        }

        [HttpGet("BuscarEnderecoPorCep")]
        public async Task<IActionResult> BuscarEnderecoPorCep([FromQuery] string cep)
        {
            var endereco = await _concessionariaService.BuscarEnderecoPorCep(cep);
            if(endereco is null)
                return Json(new { sucesso = false, menssagem = "CEP inválido." });
                
            return Json(new { sucesso = true, obj = endereco });

        }
    }
}
