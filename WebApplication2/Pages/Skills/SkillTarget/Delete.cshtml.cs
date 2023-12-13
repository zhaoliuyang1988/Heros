using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Skills.SkillTarget
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public SkillTargets SkillTargets { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SkillTargets == null)
            {
                return NotFound();
            }

            var skilltargets = await _context.SkillTargets.FirstOrDefaultAsync(m => m.Id == id);

            if (skilltargets == null)
            {
                return NotFound();
            }
            else 
            {
                SkillTargets = skilltargets;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SkillTargets == null)
            {
                return NotFound();
            }
            var skilltargets = await _context.SkillTargets.FindAsync(id);

            if (skilltargets != null)
            {
                SkillTargets = skilltargets;
                _context.SkillTargets.Remove(SkillTargets);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
