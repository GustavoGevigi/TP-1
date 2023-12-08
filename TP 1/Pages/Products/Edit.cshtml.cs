using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public EditModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Produtos Produtos { get; set; } = default!;
        public List<Branding> Marcas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.Include(p => p.Marcas).FirstOrDefaultAsync(m => m.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }

            Produtos = produtos;
            Marcas = _context.Branding.ToList();
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

            // Obtém a Marca selecionada a partir do ID
            var marcaSelecionada = await _context.Branding.FindAsync(Produtos.MarcaId);

            if (marcaSelecionada == null)
            {
                // Se a marca não for encontrada, retorne à página com erro
                ModelState.AddModelError("Produtos.MarcaId", "Marca inválida.");
                Marcas = _context.Branding.ToList();
                return Page();
            }

            // Atribui a marca ao produto
            Produtos.Marcas = marcaSelecionada;

            // Atualiza o estado do produto como modificado e salva as mudanças
            _context.Attach(Produtos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool ProdutosExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
