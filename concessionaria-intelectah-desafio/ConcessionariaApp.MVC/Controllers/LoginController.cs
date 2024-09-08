using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AutenticarUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            
            var usuarioResultado = await _loginService.Login(dto);

            return usuarioResultado.Sucesso ? 
                        RedirectToAction("Index", "Home") : View(usuarioResultado);
        }
        
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var usuarioResultado = await _loginService.Registrar(dto);

            return usuarioResultado.Sucesso ?
                        RedirectToAction("Index", "Home") : View(usuarioResultado);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
