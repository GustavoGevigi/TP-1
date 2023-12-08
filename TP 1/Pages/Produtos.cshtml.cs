using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages
{
    public class ProdutosModel : PageModel
    {
        private readonly TP_1Context _context;

        public ProdutosModel(TP_1Context context)
        {
            _context = context;
        }

        public IList<Produtos> Produtos { get; set; } = new List<Produtos>();

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produtos.ToListAsync();
        }
    }
}
