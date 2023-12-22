using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_1.Data;
using TP_1.Models;

namespace TP_1.Pages.MarcasCrud
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TP_1.Data.TP_1Context _context;

        public DetailsModel(TP_1.Data.TP_1Context context)
        {
            _context = context;
        }

      public MarcasData MarcasData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MarcasData == null)
            {
                return NotFound();
            }

            var marcasdata = await _context.MarcasData.FirstOrDefaultAsync(m => m.MarcasDataId == id);
            if (marcasdata == null)
            {
                return NotFound();
            }
            else 
            {
                MarcasData = marcasdata;
            }
            return Page();
        }
    }
}
