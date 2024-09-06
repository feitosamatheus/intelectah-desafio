using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Infrastructure.Contexts;
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
    }
}
