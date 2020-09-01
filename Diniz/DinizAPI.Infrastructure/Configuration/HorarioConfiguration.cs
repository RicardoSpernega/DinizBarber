using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Infrastructure.Configuration
{
    class HorarioConfiguration : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder
                .ToTable("Horario");

            builder
                 .Property(l => l.HorarioId)
                 .HasColumnName("HorarioId");

            builder
                .Property(l => l.Dia)
                .HasColumnName("Dia");

            builder
                .Property(l => l.HorarioInicio)
                .HasColumnName("HorarioInicio");

            builder
                .Property(l => l.HorarioFim)
                .HasColumnName("HorarioFim");

        }
    }
}
