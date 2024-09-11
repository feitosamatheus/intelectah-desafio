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
        Task AtualizarListaCacheAynsc<T>(string chave, IEnumerable<T> lista);
        Task<T> BuscarCacheAsync<T>(string chave);
        Task<IEnumerable<T>> BuscarCacheListAsync<T>(string chave);
    }
}
