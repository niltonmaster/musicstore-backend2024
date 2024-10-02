using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            //modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(50);


            //Ahora debemos importaer los entityconfigyuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//de esta forma se aplica todas las configuraciones que EF encuentre en el proyecto
            
            //modelBuilder.Entity<ConcertInfo>().HasNoKey();//PARA QUE NO CONSIDERE EN MIGRACIUON
            //modelBuilder.Ignore<ConcertInfo>();//.Ignore();

        }

        //Entities -> tables 
        //public DbSet<Genre> Genres { get; set; }




        /// <summary>
        /// USAR LAZU LOADING
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) { 
            optionsBuilder.UseLazyLoadingProxies();//havbbilita proxies para usar Lazy Loading
            }
        }

    }
}
