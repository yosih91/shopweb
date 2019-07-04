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
    public class IndexModel : PageModel
    {
        private readonly test.Data.FruitslContext _context;

        public IndexModel(test.Data.FruitslContext context)
        {
            _context = context;
        }

        public IList<Fruits> Fruits { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList names { get; set; }
        [BindProperty(SupportsGet = true)]
        public string proGenre { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            var prod = from m in _context.Fruits
                       select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                prod = prod.Where(s => s.Name.Contains(SearchString));
            }


            Fruits = await prod.ToListAsync();
        }

        }
    }

