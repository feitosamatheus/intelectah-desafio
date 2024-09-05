﻿using ConcessionariaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Contexts.FluentConfigurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.Id).HasName("UsuarioId");
            builder.Property(p => p.NomeUsuario).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Senha).HasMaxLength(255).IsRequired();
            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(t => t.EnderecoEmail).HasColumnName("Email").HasMaxLength(100).IsRequired();
            });
            builder.Property(p => p.NivelAcesso).IsRequired();
        }
    }
}
