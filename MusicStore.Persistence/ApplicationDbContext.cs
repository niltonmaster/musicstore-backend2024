using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Fluent API: es una serie de pasos en el cual mi modelo de datos codigo va ser transformado a objetos en una BD. Por tanto crearmos sobreescritura

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);

            //custom of the db objects
            ////Code first approach
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(50);


        }

        //Entities -> tables 
        public DbSet<Genre> Genres { get; set; }


    }
}
