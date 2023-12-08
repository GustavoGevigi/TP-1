using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.ProdutosCrud
{
    public class CreateModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public CreateModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutosData Produto { get; set; }

        public List<MarcasData> Marcas { get; set; }

        public void OnGet()
        {
            // Carregar lista de marcas
            Marcas = _context.MarcasData.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Se o modelo não for válido, retorne à página com erros
                Marcas = _context.MarcasData.ToList();
                return Page();
            }

            // Carregue a marca associada
            Produto.Marca = _context.MarcasData.Find(Produto.MarcaId);

            // Salve o produto no banco de dados
            _context.ProdutosData.Add(Produto);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
