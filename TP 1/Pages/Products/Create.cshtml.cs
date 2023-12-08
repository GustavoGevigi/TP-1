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
    public class CreateModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public CreateModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Produtos Produtos { get; set; } = default!;
        public List<Branding> Marcas { get; set; }

        public IActionResult OnGet()
        {
            Marcas = _context.Branding.ToList();

            if (Marcas == null || !Marcas.Any())
            {
                // A lista está vazia ou é nula, você pode tomar alguma ação, como lançar uma exceção ou logar uma mensagem
                // Aqui, por exemplo, redirecionamos para uma página de erro
                return RedirectToPage("/Error");
            }

            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Produtos == null || Produtos == null)
            {
                // Recarregue as marcas para a página
                Marcas = _context.Branding.ToList();
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

            // Adiciona o produto ao contexto e salva as mudanças
            _context.Produtos.Add(Produtos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
