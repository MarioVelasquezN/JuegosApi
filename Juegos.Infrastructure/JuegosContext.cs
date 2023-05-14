using Juegos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Juegos.Infrastructure
{
    public class JuegosContext : DbContext
    {
        public JuegosContext(DbContextOptions<JuegosContext> options) : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Videojuego> VideoJuegos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Categoria>().Property(x => x.Codigo).ValueGeneratedOnAdd();
            modelBuilder.Entity<Categoria>().Property(x=>x.Nombrecategoria).IsRequired();

            //modelBuilder.Entity<Categoria>().HasMany(x=>x.Juegos).WithOne(x=>x.Categoria).HasForeignKey(x=>x.CategoriaId);

            modelBuilder.Entity<Videojuego>().HasKey(c => c.Id);
            modelBuilder.Entity<Videojuego>().HasMany(x => x.Clientes).WithMany(x => x.videojuegos);
            modelBuilder.Entity<Videojuego>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Videojuego>().Property(x=>x.ModoJuego).IsRequired();
            modelBuilder.Entity<Videojuego>().Property(x => x.Nombrejuego).IsRequired();
            modelBuilder.Entity<Videojuego>().Property(x => x.FechaPublicacion).IsRequired();
            modelBuilder.Entity<Videojuego>().Property(x => x.Autor).IsRequired();
            modelBuilder.Entity<Videojuego>().Property(x => x.CopiasDisponibles).IsRequired();
            modelBuilder.Entity<Videojuego>().HasMany(x=>x.Clientes).WithMany(x=>x.videojuegos);
            modelBuilder.Entity<Videojuego>().HasOne(x => x.Categoria).WithMany(x => x.Juegos).HasForeignKey(x=>x.CategoriaId);


            modelBuilder.Entity<Cliente>().HasKey(x => x.Id);
            modelBuilder.Entity<Cliente>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Cliente>().Property(x => x.Nombre).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Renta).IsRequired();
            modelBuilder.Entity<Cliente>().HasMany(x=>x.videojuegos).WithMany(x=>x.Clientes);


        }
    }
}
