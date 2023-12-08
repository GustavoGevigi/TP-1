using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.ProdutosCrud
{
    public class IndexModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public IndexModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        public IList<ProdutosData> ProdutosData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProdutosData != null)
            {
                ProdutosData = await _context.ProdutosData.ToListAsync();
            }
        }
    }
}
