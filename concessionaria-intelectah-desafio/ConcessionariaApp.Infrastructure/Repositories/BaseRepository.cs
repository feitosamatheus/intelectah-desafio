using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ContextApp context;

        public BaseRepository(ContextApp context)
        {
            this.context = context;
        }

        public void Add(T value)
        {
            context.Add(value);
        }

        public void Delete(T value)
        {
            context.Remove(value);
        }

        public void Update(T value)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }


        
    }
}
