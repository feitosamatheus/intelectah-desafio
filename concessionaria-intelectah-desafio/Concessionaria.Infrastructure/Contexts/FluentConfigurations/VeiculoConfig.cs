using ConcessionariaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Contexts.FluentConfigurations
{
    public class VeiculoConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.VeiculoId);
            builder.Property(v => v.Modelo).HasMaxLength(100).IsRequired();
            builder.HasIndex(v => v.Modelo).HasDatabaseName("IX_Veiculo_Nome").IsUnique();
            builder.Property(v => v.AnoFabricacao).IsRequired();
            builder.Property(v => v.Preco).HasPrecision(10,2).IsRequired();
            builder.HasOne(f => f.Fabricante).WithMany(m => m.Veiculos).HasForeignKey(fk => fk.FabricanteId);
            builder.Property(v => v.TipoVeiculo).IsRequired();
            builder.Property(v => v.Descricao);
        }
    }
}
