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
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<HeroModel> HeroModel { get;set; } = default!;
        public IList<SkillModel> SkillModels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.HeroModel != null)
            {
                HeroModel = await _context.HeroModel.ToListAsync();
            }

            if (_context.SkillModel != null)
            {
                SkillModels = await _context.SkillModel.ToListAsync();
            }
        }
    }
}
