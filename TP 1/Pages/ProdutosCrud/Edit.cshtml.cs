using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.ProdutosCrud
{
    public class EditModel : PageModel
    {
        private readonly TP_1Context _context;

        public EditModel(TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutosData Produto { get; set; } = default!;
        public List<MarcasData> Marcas { get; set; } = new List<MarcasData>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.ProdutosData
                .Include(p => p.Marca)  // Carregar a marca associada
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Produto == null)
            {
                return NotFound();
            }

            // Carregar lista de marcas
            Marcas = await _context.MarcasData.ToListAsync();

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

            _context.Attach(Produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.Id))
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

        private bool ProdutoExists(int id)
        {
            return _context.ProdutosData.Any(e => e.Id == id);
        }
    }
}
