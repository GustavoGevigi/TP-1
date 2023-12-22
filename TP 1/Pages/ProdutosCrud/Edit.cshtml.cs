using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.ProdutosCrud
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public EditModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
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
            ProdutosData = produtosdata;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdutosData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosDataExists(ProdutosData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdutosDataExists(int id)
        {
            return (_context.ProdutosData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}