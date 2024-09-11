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
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ContextApp context) : base(context)
        {
        }

        public async Task<IEnumerable<Veiculo>> BucarVeiculoPorFabricante(int fabricanteId)
        {
            return await context.Veiculos.Include(f => f.Fabricante).Where(v => v.FabricanteId == fabricanteId).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> BucarVeiculoPorModelo(string modelo)
        {
            return await context.Veiculos.Include(f => f.Fabricante).Where(v => v.Modelo == modelo).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> BucarVeiculoPorFabricanteModelo(string modelo, int fabricanteId)
        {
            return await context.Veiculos.Include(f=> f.Fabricante).Where(v => v.Modelo == modelo && v.FabricanteId == fabricanteId).ToListAsync();
        }
    }
}
