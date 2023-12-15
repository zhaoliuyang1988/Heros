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
      public SkillModel SkillModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SkillModel == null)
            {
                return NotFound();
            }

            var skillmodel = await _context.SkillModel.FirstOrDefaultAsync(m => m.Id == id);

            if (skillmodel == null)
            {
                return NotFound();
            }
            else 
            {
                SkillModel = skillmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SkillModel == null)
            {
                return NotFound();
            }
            var skillmodel = await _context.SkillModel.FindAsync(id);

            if (skillmodel != null)
            {
                SkillModel = skillmodel;
                _context.SkillModel.Remove(SkillModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
