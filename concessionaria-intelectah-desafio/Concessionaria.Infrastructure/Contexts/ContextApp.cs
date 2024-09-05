using ConcessionariaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Contexts
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options){ }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Concessionaria> Concessionarias { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ContextApp).Assembly);
        }
    }
}
