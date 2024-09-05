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
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.HasIndex(c => c.Numero).HasDatabaseName("IX_Cliente_CPF").IsUnique();
                cpf.Property(c => c.Numero).HasColumnName("CPF").HasMaxLength(11).IsRequired();
            });
            builder.OwnsOne(c => c.Telefone, telefone =>
            {
                telefone.Property(c => c.Numero).HasColumnName("Telefone").HasMaxLength(15).IsRequired();
            });
        }
    }
}
