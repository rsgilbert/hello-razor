using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hello_razor.Models;

namespace hello_razor.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly HelloRazorMovieContext _context;

        public DetailsModel(HelloRazorMovieContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Console.WriteLine("id is " + id);
            if (id == null || _context.Movie == null)
            {
                return Page();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
