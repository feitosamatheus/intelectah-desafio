using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface ILoginService 
    {
        Task<ResultadoOperacao> Login(AutenticarUsuarioDTO dto);
        Task<ResultadoOperacao> Registrar(RegistrarUsuarioDTO dto);
        Task EncerrarSessao();
    }
}
