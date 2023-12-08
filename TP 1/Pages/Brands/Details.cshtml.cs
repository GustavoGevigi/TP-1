using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.Brands
{
    public class DetailsModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public DetailsModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

      public Branding Branding { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Branding == null)
            {
                return NotFound();
            }

            var branding = await _context.Branding.FirstOrDefaultAsync(m => m.BrandingId == id);
            if (branding == null)
            {
                return NotFound();
            }
            else 
            {
                Branding = branding;
            }
            return Page();
        }
    }
}
