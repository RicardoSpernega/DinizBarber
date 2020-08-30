using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Infrastructure.Configuration
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder
                .ToTable("Login");

            builder
                 .Property(l => l.LoginId)
                 .HasColumnName("LoginId");

            builder
                .Property(l => l.Nome)
                .HasColumnName("Nome");

            builder
                .Property(l => l.Senha)
                .HasColumnName("Senha");

            builder
                .Property(l => l.Cpf)
                .HasColumnName("Cpf");

            builder
                .Property(l => l.DataNascimento)
                .HasColumnName("DataNascimento");

            builder
                .Property(l => l.Admin)
                .HasColumnName("Admin");

            builder
                .Property(l => l.Email)
                .HasColumnName("Email");

            builder
                .Property(l => l.DataInclusao)
                .HasColumnName("DataInclusao");

            builder
                .Property(l => l.Ativo)
                .HasColumnName("Ativo");
        }
    }
}
