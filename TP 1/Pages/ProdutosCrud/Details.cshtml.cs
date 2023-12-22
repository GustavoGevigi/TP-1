using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.ProdutosCrud
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public DetailsModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

      public ProdutosData ProdutosData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProdutosData == null)
            {
                return NotFound();
            }

            var produtosdata = await _context.ProdutosData.FirstOrDefaultAsync(m => m.Id == id);
            if (produtosdata == null)
            {
                return NotFound();
            }
            else 
            {
                ProdutosData = produtosdata;
            }
            return Page();
        }
    }
}
