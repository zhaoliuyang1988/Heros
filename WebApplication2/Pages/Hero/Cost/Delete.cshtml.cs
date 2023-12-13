using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Hero.Cost
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Costs Costs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Costs == null)
            {
                return NotFound();
            }

            var costs = await _context.Costs.FirstOrDefaultAsync(m => m.Id == id);

            if (costs == null)
            {
                return NotFound();
            }
            else 
            {
                Costs = costs;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Costs == null)
            {
                return NotFound();
            }
            var costs = await _context.Costs.FindAsync(id);

            if (costs != null)
            {
                Costs = costs;
                _context.Costs.Remove(Costs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
