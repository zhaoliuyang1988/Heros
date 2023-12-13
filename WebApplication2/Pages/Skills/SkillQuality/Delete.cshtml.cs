using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Skills.SkillQuality
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public SkillQualitys SkillQualitys { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SkillQualitys == null)
            {
                return NotFound();
            }

            var skillqualitys = await _context.SkillQualitys.FirstOrDefaultAsync(m => m.Id == id);

            if (skillqualitys == null)
            {
                return NotFound();
            }
            else 
            {
                SkillQualitys = skillqualitys;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SkillQualitys == null)
            {
                return NotFound();
            }
            var skillqualitys = await _context.SkillQualitys.FindAsync(id);

            if (skillqualitys != null)
            {
                SkillQualitys = skillqualitys;
                _context.SkillQualitys.Remove(SkillQualitys);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
