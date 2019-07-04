using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controller
{
    public class EditModel : PageModel
    {
        private readonly test.Data.FruitslContext _context;

        public EditModel(test.Data.FruitslContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fruits Fruits { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fruits = await _context.Fruits.FirstOrDefaultAsync(m => m.Id == id);

            if (Fruits == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fruits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitsExists(Fruits.Id))
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

        private bool FruitsExists(int id)
        {
            return _context.Fruits.Any(e => e.Id == id);
        }
    }
}
