using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hello_razor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace hello_razor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly HelloRazorMovieContext _context;

        public IndexModel(HelloRazorMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }

        public SelectList ? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            var movies = from m in _context.Movie select m;
            if(!string.IsNullOrEmpty(SearchString))
                movies = movies.Where(s => s.Title.Contains(SearchString)); // db will use: WHERE instr(m.Title, "o") > 0;
            if(!string.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(m => m.Genre.Equals(MovieGenre));
            Movie = await movies.ToListAsync();
        }
    }
}
