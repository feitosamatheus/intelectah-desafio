using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Repositories
{
    public class ConcessionariaRepository : BaseRepository<Concessionaria>, IConcessionariaRepository
    {
        public ConcessionariaRepository(ContextApp context) : base(context)
        {
        }

        public async Task<Concessionaria> BuscarConcessionariaPorNome(string nome)
        {
            return await context.Concessionarias.FirstOrDefaultAsync(f => f.Nome.Equals(nome));
        }
    }
}
