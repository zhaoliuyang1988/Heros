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
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<SkillTargets> SkillTargets { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SkillTargets != null)
            {
                SkillTargets = await _context.SkillTargets.ToListAsync();
            }
        }
    }
}
