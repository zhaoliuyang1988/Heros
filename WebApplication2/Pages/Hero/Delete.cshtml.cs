using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Hero
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Heros Heros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Heros == null)
            {
                return NotFound();
            }

            var heros = await _context.Heros.FirstOrDefaultAsync(m => m.Id == id);

            if (heros == null)
            {
                return NotFound();
            }
            else 
            {
                Heros = heros;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Heros == null)
            {
                return NotFound();
            }
            var heros = await _context.Heros.FindAsync(id);

            if (heros != null)
            {
                Heros = heros;
                _context.Heros.Remove(Heros);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
