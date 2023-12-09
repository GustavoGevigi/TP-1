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
        public DbSet<TP_1.Models.ProdutosData>? ProdutosData { get; set; }
        public DbSet<TP_1.Models.MarcasData>? MarcasData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var produto1 = new ProdutosData { 
                Id = 1, 
                Nome = "Air Jordan 1", 
                Descricao = "Um clássico do basquete", 
                Preco = 1999.99, DataLancamento = new DateTime (1985, 04, 01), 
                ImagemPath = "airjordan1.jpg" 
            };

            var marca1 = new MarcasData
            {
                MarcasDataId = 1,
                MarcasDataNome = "Nike"
            };

            var marca2 = new MarcasData
            {
                MarcasDataId = 2,
                MarcasDataNome = "Adidas"
            };

            var marca3 = new MarcasData
            {
                MarcasDataId = 3,
                MarcasDataNome = "Puma"
            };

            modelBuilder.Entity<ProdutosData>().HasData(produto1);
            modelBuilder.Entity<MarcasData>().HasData(marca1, marca2, marca3);

            base.OnModelCreating(modelBuilder);
        }
    }
}
