using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Domain.ValueObjects;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextApp context) : base(context){}

        public async Task<Cliente> BuscarClientePorCpf(string CPF)
        {
            var resultado = await context.Clientes.ToListAsync();
            return resultado.FirstOrDefault(c => c.Cpf.Numero == CPF);
        }
    }
}
