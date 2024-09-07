using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface ICashingService
    {
        Task AtualizarCacheAynsc(string chave, string valor);
        Task<string> BuscarCacheAsync(string chave);
    }
}
