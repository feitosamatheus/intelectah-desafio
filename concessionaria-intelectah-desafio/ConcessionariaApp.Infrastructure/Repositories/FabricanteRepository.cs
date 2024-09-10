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
    public class FabricanteRepository : BaseRepository<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(ContextApp context) : base(context)
        {
        }

        public async Task<Fabricante> BuscarFabricantePorNomeAsync(string nome, CancellationToken cancellationToken)
        {
            return await context.Fabricantes.FirstOrDefaultAsync(f => f.Nome.Equals(nome));
        }
    }
}
