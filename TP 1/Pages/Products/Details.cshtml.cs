using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public DetailsModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

      public Produtos Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, string slug)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id && m.Slug == slug);

            if (produto == null)
            {
                return NotFound();
            }

            Produtos = produto;
            return Page();
        }
    }
}
