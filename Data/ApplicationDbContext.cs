using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica2.Models;
using Microsoft.EntityFrameworkCore;

namespace practica2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        
        public DbSet<Mascota> Mascotas {get; set;}
        public DbSet<Adoptante> Adoptantes {get; set;}
        public DbSet<Adopcion> Adopciones { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mascota>()
            .HasOne(m => m.Adopcion)
            .WithOne(a => a.Mascota)
            .HasForeignKey<Adopcion>(a => a.MascotaId);
        }
    }
}