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

namespace TP_1.Pages.MarcasCrud
{
    public class EditModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public EditModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MarcasData MarcasData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MarcasData == null)
            {
                return NotFound();
            }

            var marcasdata =  await _context.MarcasData.FirstOrDefaultAsync(m => m.MarcasDataId == id);
            if (marcasdata == null)
            {
                return NotFound();
            }
            MarcasData = marcasdata;
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

            _context.Attach(MarcasData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasDataExists(MarcasData.MarcasDataId))
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

        private bool MarcasDataExists(int id)
        {
          return (_context.MarcasData?.Any(e => e.MarcasDataId == id)).GetValueOrDefault();
        }
    }
}
