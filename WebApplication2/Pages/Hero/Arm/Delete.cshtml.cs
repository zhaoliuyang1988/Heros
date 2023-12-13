using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Hero.Arm
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Arms Arms { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Arms == null)
            {
                return NotFound();
            }

            var arms = await _context.Arms.FirstOrDefaultAsync(m => m.Id == id);

            if (arms == null)
            {
                return NotFound();
            }
            else 
            {
                Arms = arms;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Arms == null)
            {
                return NotFound();
            }
            var arms = await _context.Arms.FindAsync(id);

            if (arms != null)
            {
                Arms = arms;
                _context.Arms.Remove(Arms);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
