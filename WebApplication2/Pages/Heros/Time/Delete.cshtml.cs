﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Heros.Time
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Times Times { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Times == null)
            {
                return NotFound();
            }

            var times = await _context.Times.FirstOrDefaultAsync(m => m.Id == id);

            if (times == null)
            {
                return NotFound();
            }
            else 
            {
                Times = times;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Times == null)
            {
                return NotFound();
            }
            var times = await _context.Times.FindAsync(id);

            if (times != null)
            {
                Times = times;
                _context.Times.Remove(Times);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
