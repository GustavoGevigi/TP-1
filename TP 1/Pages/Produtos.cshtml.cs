using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages
{
    public class ProdutosModel : PageModel
    {
        private readonly TP_1Context _context;

        public ProdutosModel(TP_1Context context)
        {
            _context = context;
        }

        public IList<ProdutosData> ProdutosData { get; set; }

        public void OnGet()
        {
            ProdutosData = _context.ProdutosData.ToList();
        }
    }
}
