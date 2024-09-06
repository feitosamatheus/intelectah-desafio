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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextApp context) : base(context)
        {
        }
    }
}
