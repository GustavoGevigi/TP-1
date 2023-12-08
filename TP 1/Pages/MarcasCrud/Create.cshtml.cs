using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.MarcasCrud
{
    public class CreateModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public CreateModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MarcasData MarcasData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MarcasData == null || MarcasData == null)
            {
                return Page();
            }

            _context.MarcasData.Add(MarcasData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
