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

namespace TP_1.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public EditModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Branding Branding { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Branding == null)
            {
                return NotFound();
            }

            var branding =  await _context.Branding.FirstOrDefaultAsync(m => m.BrandingId == id);
            if (branding == null)
            {
                return NotFound();
            }
            Branding = branding;
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

            _context.Attach(Branding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandingExists(Branding.BrandingId))
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

        private bool BrandingExists(int id)
        {
          return (_context.Branding?.Any(e => e.BrandingId == id)).GetValueOrDefault();
        }
    }
}
