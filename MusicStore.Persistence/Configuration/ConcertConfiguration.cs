﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Persistence.Configuration
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {

            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Place).HasMaxLength(100);

            builder.Property(x => x.DateEvent).HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ImageUrl).HasMaxLength(200)
                .IsUnicode(false);//eliminar caracterses extraños
            builder.HasIndex(x => x.Title);

            builder.ToTable(nameof(Concert), "Musicales");//personalizar nombre de la tabla 

        }
    }
}
