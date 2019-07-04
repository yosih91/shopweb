using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controller
{
    public class DetailsModel : PageModel
    {
        private readonly test.Data.FruitslContext _context;

        public DetailsModel(test.Data.FruitslContext context)
        {
            _context = context;
        }

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
    }
}
