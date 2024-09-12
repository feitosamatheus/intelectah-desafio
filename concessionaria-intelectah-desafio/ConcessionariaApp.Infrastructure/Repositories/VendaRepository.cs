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
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(ContextApp context) : base(context)
        {
        }

        public async Task<int> BuscarQuantidadeVendaPorConcessionaria(int concessionariaId)
        {
            return await context.Vendas.CountAsync(v => v.ConcessionariaId == concessionariaId);
        }
    }
}
