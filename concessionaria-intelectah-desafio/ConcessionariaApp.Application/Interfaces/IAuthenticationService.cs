using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResultadoOperacao> CriarUsuarioAsync(Usuario usuario);
        Task<ResultadoOperacao> LoginUsuarioAsync(Usuario usuario);
        Task LogoutUsuarioAsync();
        Task<Usuario> BuscarUsuarioPorEmailAsync(string email);
    }
}
