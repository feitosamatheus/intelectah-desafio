using ConcessionariaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Configurations.EntityConfig
{
    public class FabricanteConfig : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(f => f.Id).HasName("FabricanteId");
            builder.Property(f => f.Nome).HasMaxLength(100).IsRequired();
            builder.Property(f => f.PaisOrigem).HasMaxLength(50).IsRequired();
            builder.Property(f => f.AnoFundacao).IsRequired();
            builder.Property(f => f.WebSite).HasMaxLength(255).IsRequired();
        }
    }
}
