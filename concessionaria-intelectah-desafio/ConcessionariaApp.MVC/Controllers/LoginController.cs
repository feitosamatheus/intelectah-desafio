using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ConcessionariaApp.Application.Dtos.Login;
using Microsoft.AspNetCore.Authorization;

namespace ConcessionariaApp.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View(new AutenticarUsuarioDTO());
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

            ViewBag.Error = "Usuario e/ou senha estão incorretos.";
            return View(dto);
        }

        public IActionResult Registrar()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View(new RegistrarUsuarioDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var usuarioResultado = await _loginService.Registrar(dto);

            if (usuarioResultado.Sucesso)
            {
                RedirectToAction("Index", "Home");
            }

            ViewBag.Error = usuarioResultado.Menssagem;

            return View(usuarioResultado);
        
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _loginService.EncerrarSessao();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult AcessoNegado()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
