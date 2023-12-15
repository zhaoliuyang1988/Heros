﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public HeroModel HeroModel { get; set; } = default!;

        public IList<SkillModel> SkillModels { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HeroModel == null)
            {
                return NotFound();
            }

            if (_context.SkillModel != null)
            {
                SkillModels = await _context.SkillModel.ToListAsync();
            }

            var heromodel = await _context.HeroModel.FirstOrDefaultAsync(m => m.Id == id);
            if (heromodel == null)
            {
                return NotFound();
            }
            else
            {
                HeroModel = heromodel;
            }
            return Page();
        }
    }
}
