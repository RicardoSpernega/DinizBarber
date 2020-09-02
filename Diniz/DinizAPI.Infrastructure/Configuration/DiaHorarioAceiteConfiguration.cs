using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Infrastructure.Configuration
{
    public class DiaHorarioAceiteConfiguration : IEntityTypeConfiguration<DiaHorarioAceite>
    {
        public void Configure(EntityTypeBuilder<DiaHorarioAceite> builder)
        {
            builder
                .ToTable("DiaHorarioAceite");

            builder
                 .Property(l => l.DiaHorarioAceiteId)
                 .HasColumnName("DiaHorarioAceiteId");

            builder
                .Property(l => l.HorarioFim)
                .HasColumnName("HorarioFim");

            builder
                .Property(l => l.HorarioInicio)
                .HasColumnName("HorarioInicio");

            builder
                .Property(l => l.TipoStatusHorarioId)
                .HasColumnName("TipoStatusHorarioId ");

            builder
                .Property(l => l.DtInclusao)
                .HasColumnName("DtInclusao");

            builder
                .Property(l => l.DtAceite)
                .HasColumnName("DtAceite");

            builder
                .Property(l => l.LoginId)
                .HasColumnName("LoginId");

            builder
                .Property(l => l.DiaId)
                .HasColumnName("DiaId");

            builder
                .HasOne(l => l.Login)
                .WithMany()
                .HasForeignKey("LoginId");

            builder
                .HasOne(l => l.Dia)
                .WithMany()
                .HasForeignKey("DiaId");

        }

    }
}
