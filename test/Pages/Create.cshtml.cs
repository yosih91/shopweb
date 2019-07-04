using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test.Data;
using test.Models;

namespace test.Controller
{
    public class CreateModel : PageModel
    {
        private readonly test.Data.FruitslContext _context;

        public CreateModel(test.Data.FruitslContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fruits Fruits { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fruits.Add(Fruits);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}