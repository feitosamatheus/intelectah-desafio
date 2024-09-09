using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ConcessionariaApp.Application.Dtos.Login;

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

            if(usuarioResultado.Sucesso)
                return RedirectToAction("Index", "Home");

            return View(dto);
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

        public async Task<IActionResult> Logout()
        {
            await _loginService.EncerrarSessao();

            return RedirectToAction("Index", "Login");
        }
    }
}
