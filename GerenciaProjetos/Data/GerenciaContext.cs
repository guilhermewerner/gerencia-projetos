using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaProjetos.Models;

namespace GerenciaProjetos.Data
{
    public class GerenciaContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Requisito> Requisitos { get; set; }

        public DbSet<DesenvolvedorProjeto> DesenvolvedorProjeto { get; set; }
        public DbSet<DesenvolvedorRequisito> DesenvolvedorRequisito { get; set; }

        public GerenciaContext(DbContextOptions o) : base(o)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bug>()
                .HasKey(b => new { b.DesenvolvedorId, b.RequisitoId });
            modelBuilder.Entity<DesenvolvedorProjeto>()
                .HasKey(p => new { p.DesenvolvedorId, p.ProjetoId });
            modelBuilder.Entity<DesenvolvedorRequisito>()
                .HasKey(r => new { r.DesenvolvedorId, r.RequisitoId });
        }
    }
}
