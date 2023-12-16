using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductModel ProductModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductModel == null)
            {
                return NotFound();
            }

            var productmodel = await _context.ProductModel.FirstOrDefaultAsync(m => m.Id == id);

            if (productmodel == null)
            {
                return NotFound();
            }
            else 
            {
                ProductModel = productmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductModel == null)
            {
                return NotFound();
            }
            var productmodel = await _context.ProductModel.FindAsync(id);

            if (productmodel != null)
            {
                ProductModel = productmodel;
                _context.ProductModel.Remove(ProductModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
