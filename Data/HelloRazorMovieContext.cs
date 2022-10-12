using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hello_razor.Models;

    public class HelloRazorMovieContext : DbContext
    {
        public HelloRazorMovieContext (DbContextOptions<HelloRazorMovieContext> options)
            : base(options)
        {
        }

        public DbSet<hello_razor.Models.Movie> Movie { get; set; } = default!;
    }
