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
        public async Task<IEnumerable<Venda>> BucarRelatorioVendaPorAnoMes(int mes, int ano)
        {
            return await context.Vendas.Include(c => c.Concessionaria).Include(v => v.Veiculo).ThenInclude(f => f.Fabricante).Where(v => v.DataVenda.Month == mes && v.DataVenda.Year == ano ).ToListAsync();
        }
    }
}
