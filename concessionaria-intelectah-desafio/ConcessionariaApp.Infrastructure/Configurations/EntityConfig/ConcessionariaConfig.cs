﻿using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Configurations.EntityConfig
{
    public class ConcessionariaConfig : IEntityTypeConfiguration<Concessionaria>
    {
        public void Configure(EntityTypeBuilder<Concessionaria> builder)
        {
            builder.HasKey(c => c.Id).HasName("ConcessionariaId");
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Nome).HasDatabaseName("IX_Concessionaria_Nome").IsUnique();
            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.EnderecoCompleto).HasColumnName("Endereco").HasMaxLength(255).IsRequired();
                endereco.Property(e => e.Cidade).HasColumnName("Cidade").HasMaxLength(50).IsRequired();
                endereco.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(50).IsRequired();
                endereco.Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(10).IsRequired();
            });
            builder.OwnsOne(c => c.Telefone, telefone =>
            {
                telefone.Property(t => t.Numero).HasColumnName("Telefone").HasMaxLength(15).IsRequired();
            });
            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(t => t.EnderecoEmail).HasColumnName("Email").HasMaxLength(100).IsRequired();
            });
            builder.Property(c => c.CapacidadeMaximaVeiculos).IsRequired();
        }
    }
}
