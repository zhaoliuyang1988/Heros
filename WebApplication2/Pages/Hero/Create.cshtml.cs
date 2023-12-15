using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Hero
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public CreateModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            if (_context.SkillModel != null)
            {
                var skills = await _context.SkillModel.ToListAsync();
                SelectList = new SelectList(await _context.SkillModel.ToListAsync(), "Id", "Name");
            }
            return Page();
        }

        [BindProperty]
        public HeroModel HeroModel { get; set; } = default!;



        public SelectList SelectList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HeroModel == null || HeroModel == null)
            {
                return Page();
            }

            _context.HeroModel.Add(HeroModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
