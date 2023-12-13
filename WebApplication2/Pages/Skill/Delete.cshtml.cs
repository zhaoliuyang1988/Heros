using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Skill
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Skills Skills { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);

            if (skills == null)
            {
                return NotFound();
            }
            else 
            {
                Skills = skills;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }
            var skills = await _context.Skills.FindAsync(id);

            if (skills != null)
            {
                Skills = skills;
                _context.Skills.Remove(Skills);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
