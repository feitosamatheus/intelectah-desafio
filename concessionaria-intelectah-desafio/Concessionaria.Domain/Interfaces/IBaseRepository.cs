using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T value);
        void Delete(T value);
        void Update(T value);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
