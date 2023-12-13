using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Skill.SkillType
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public SkillTypes SkillTypes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SkillTypes == null)
            {
                return NotFound();
            }

            var skilltypes = await _context.SkillTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (skilltypes == null)
            {
                return NotFound();
            }
            else 
            {
                SkillTypes = skilltypes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SkillTypes == null)
            {
                return NotFound();
            }
            var skilltypes = await _context.SkillTypes.FindAsync(id);

            if (skilltypes != null)
            {
                SkillTypes = skilltypes;
                _context.SkillTypes.Remove(SkillTypes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
