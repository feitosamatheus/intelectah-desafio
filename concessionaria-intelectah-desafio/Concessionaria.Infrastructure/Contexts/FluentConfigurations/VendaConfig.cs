using ConcessionariaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Contexts.FluentConfigurations
{
    public class VendaConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.VendaId);
            builder.HasOne(v => v.Veiculo).WithMany(ve => ve.Vendas).HasForeignKey(v => v.VeiculoId);
            builder.HasOne(v => v.Concessionaria).WithMany(c => c.Vendas).HasForeignKey(v => v.ConcessionariaId);
            builder.HasOne(v => v.Cliente).WithMany(cl => cl.Vendas).HasForeignKey(v => v.ClienteId);
            builder.Property(v => v.DataVenda).IsRequired();
            builder.Property(v => v.PrecoVenda).HasPrecision(10, 2).IsRequired();
            builder.Property(v => v.ProtocoloVenda).HasMaxLength(20).IsRequired();
        }
    }
}
