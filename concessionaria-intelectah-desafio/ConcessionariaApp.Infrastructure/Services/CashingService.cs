using ConcessionariaApp.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Services
{
    public class CashingService : ICashingService
    {
        private readonly IDistributedCache _distributedCache;

        public CashingService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task AtualizarCacheAynsc(string chave , string valor)
        {
            var options = new DistributedCacheEntryOptions() {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            await _distributedCache.SetStringAsync(chave, valor, options);
        }

        public async Task<string> BuscarCacheAsync(string chave)
        {
            return await _distributedCache.GetStringAsync(chave);
        }
    }
}
