using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Heros.Star
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

      public Stars Stars { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stars == null)
            {
                return NotFound();
            }

            var stars = await _context.Stars.FirstOrDefaultAsync(m => m.Id == id);
            if (stars == null)
            {
                return NotFound();
            }
            else 
            {
                Stars = stars;
            }
            return Page();
        }
    }
}
