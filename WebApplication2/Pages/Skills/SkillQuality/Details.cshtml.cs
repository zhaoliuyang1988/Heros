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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

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
    }
}
