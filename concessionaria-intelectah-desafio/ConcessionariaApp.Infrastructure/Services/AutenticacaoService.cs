using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Services
{
    public  class AutenticacaoService : IAutenticacaoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AutenticacaoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AutenticarUsuario(Usuario usuarioAutenticado)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarioAutenticado.NomeUsuario),
                new Claim(ClaimTypes.Email, usuarioAutenticado.Email.EnderecoEmail),
                new Claim(ClaimTypes.Role, usuarioAutenticado.NivelAcesso.ToString())
            };

            var claimsIdentity = new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
            );

            await _httpContextAccessor.HttpContext.SignInAsync(claimsIdentity);
            return true;
        }

        public async Task EncerrarSessao()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
