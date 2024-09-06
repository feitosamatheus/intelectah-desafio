using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public async Task<ResultadoOperacao> CriarUsuarioAsync(Usuario usuario)
        {
           var resultado = await _userManager.CreateAsync(usuario);
            if (resultado.Succeeded)
                return ResultadoOperacao.OK();

            return ResultadoOperacao.Falha();
        }

        public async Task<ResultadoOperacao> LoginUsuarioAsync(Usuario usuario)
        {
            var resultado = await _signInManager.PasswordSignInAsync(usuario, usuario.Senha, false, false);
            if (resultado.Succeeded)
                return ResultadoOperacao.OK();

            return ResultadoOperacao.Falha();
        }

        public async Task LogoutUsuarioAsync()
        {
             await _signInManager.SignOutAsync(); 
        }

        public async Task<Usuario> BuscarUsuarioPorEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

    }
}
