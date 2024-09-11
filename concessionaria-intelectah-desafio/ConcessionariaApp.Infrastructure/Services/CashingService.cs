using ConcessionariaApp.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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

        public async Task AtualizarListaCacheAynsc<T>(string chave, IEnumerable<T> lista)
        {
            var json = JsonConvert.SerializeObject(lista);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };
            await _distributedCache.SetStringAsync(chave, json, options);
        }

        public async Task<T> BuscarCacheAsync<T>(string chave)
        {
            var json = await _distributedCache.GetStringAsync(chave);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<IEnumerable<T>> BuscarCacheListAsync<T>(string chave)
        {
            var json = await _distributedCache.GetStringAsync(chave);
            if (string.IsNullOrEmpty(json))
            {
                return new List<T>();
            }

            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}
