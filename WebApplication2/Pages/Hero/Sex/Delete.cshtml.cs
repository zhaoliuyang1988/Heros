using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Hero.Sex
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Groups Groups { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var groups = await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);

            if (groups == null)
            {
                return NotFound();
            }
            else 
            {
                Groups = groups;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }
            var groups = await _context.Groups.FindAsync(id);

            if (groups != null)
            {
                Groups = groups;
                _context.Groups.Remove(Groups);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
