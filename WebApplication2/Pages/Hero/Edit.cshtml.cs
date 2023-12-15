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
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public HeroModel HeroModel { get; set; } = default!;

        public SelectList SelectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HeroModel == null)
            {
                return NotFound();
            }

            if (_context.SkillModel != null)
            {
                var skills = await _context.SkillModel.ToListAsync();
                SelectList = new SelectList(await _context.SkillModel.ToListAsync(), "Id", "Name");
            }

            var heromodel =  await _context.HeroModel.FirstOrDefaultAsync(m => m.Id == id);
            if (heromodel == null)
            {
                return NotFound();
            }
            HeroModel = heromodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HeroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroModelExists(HeroModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HeroModelExists(int id)
        {
          return (_context.HeroModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
