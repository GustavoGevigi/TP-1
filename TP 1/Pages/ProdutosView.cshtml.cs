using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP_1.Models;
using TP_1.Data;
using Microsoft.EntityFrameworkCore;

namespace TP_1.Pages
{
    [Authorize]
    public class ProdutosView : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public ProdutosView(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        public ProdutosData Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProdutosData == null)
            {
                return NotFound();
            }

            var produto = await _context.ProdutosData.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                Produto = produto;
            }
            return Page();
        }
    }
}
