using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;

namespace MusicStore.Persistence.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            
            builder.ToTable(nameof(Genre), "Musicales");//personalizar nombre de la tabla 


            builder.HasQueryFilter(x => x.Status);
        }

        //public DbSet<Genre> Genres { get; set; }



    }
}
