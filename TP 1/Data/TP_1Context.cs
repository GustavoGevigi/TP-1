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
    }
}
