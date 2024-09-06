using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextApp _context;

        public UnitOfWork(ContextApp context)
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
