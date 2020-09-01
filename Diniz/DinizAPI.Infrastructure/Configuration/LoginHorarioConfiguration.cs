using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Infrastructure.Configuration
{
    public class LoginHorarioConfiguration : IEntityTypeConfiguration<LoginHorario>
    {
        public void Configure(EntityTypeBuilder<LoginHorario> builder)
        {
            builder
                .ToTable("LoginHorario");



            builder
                .Property(l => l.LoginHorarioId)
                .HasColumnName("LoginHorario");

            builder
                 .Property<int>("LoginId");

            builder
                .Property<int>("HorarioId");

            builder
                .HasKey("LoginId", "HorarioId");

            builder
                .HasOne(l => l.Login);

            builder
                .HasOne(l => l.Horario);


        }
    }
}
