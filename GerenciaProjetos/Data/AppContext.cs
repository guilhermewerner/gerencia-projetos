using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaProjetos.Models;

namespace GerenciaProjetos.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Requisito> Requisitos { get; set; }

        public DbSet<DesenvolvedorProjeto> DesenvolvedorProjeto { get; set; }
        public DbSet<DesenvolvedorRequisito> DesenvolvedorRequisito { get; set; }

        public AppContext(DbContextOptions o) : base(o)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bug>()
                .HasKey(c => new { c.DesenvolvedorId, c.RequisitoId });
            modelBuilder.Entity<DesenvolvedorProjeto>()
                .HasKey(c => new { c.DesenvolvedorId, c.ProjetoId });
            modelBuilder.Entity<DesenvolvedorRequisito>()
                .HasKey(c => new { c.DesenvolvedorId, c.RequisitoId });
        }
    }
}
