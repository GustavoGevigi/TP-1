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
    public class DeleteModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public DeleteModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Produtos Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }
            else 
            {
                Produtos = produtos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos != null)
            {
                Produtos = produtos;
                _context.Produtos.Remove(Produtos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
