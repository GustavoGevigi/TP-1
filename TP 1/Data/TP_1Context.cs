using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_1.Models;

namespace TP_1.Data
{
    public class TP_1Context : DbContext
    {
        public TP_1Context(DbContextOptions<TP_1Context> options)
            : base(options)
        {
        }

        public DbSet<TP_1.Models.Produtos> Produtos { get; set; } = default!;
        public DbSet<TP_1.Models.Branding> Branding { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produtos>()
                .HasOne(p => p.Marcas)
                .WithMany()
                .HasForeignKey(p => p.MarcaId)
                .OnDelete(DeleteBehavior.Restrict); // ou .OnDelete(DeleteBehavior.Cascade) dependendo do comportamento desejado
        }
    }
}
