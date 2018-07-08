using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICotacoes.Models;

namespace APICotacoes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cotacao> Cotacoes { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>()
                .HasKey(c => c.NomeMoeda);
        }
    }
}