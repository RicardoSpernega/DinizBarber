using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Infrastructure.Configuration
{
    public class DiaConfiguration : IEntityTypeConfiguration<Dia>
    {
        public void Configure(EntityTypeBuilder<Dia> builder)
        {
            builder
                .ToTable("Dia");

            builder
                 .Property(l => l.DiaId)
                 .HasColumnName("DiaId");

            builder
                .Property(l => l.DtDia)
                .HasColumnName("DtDia");


        }

    }
}
