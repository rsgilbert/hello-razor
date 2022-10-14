using Microsoft.EntityFrameworkCore;
// using hello_razor.


namespace hello_razor.Models 
{
    public  static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new HelloRazorMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<HelloRazorMovieContext>>()
            )) {
                if(context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null HelloRazorMovieContext");
                }
                if(context.Movie.Any())
                {
                    // DB has been seeded
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title="Mr Nice Guy",
                        ReleaseDate = DateTime.Parse("2005-03-23"),
                        Genre = "Chinese action",
                        Price = 2500
                    },
                    new Movie
                    {
                        Title = "Terminator",
                        ReleaseDate = DateTime.Parse("1999-01-21"),
                        Genre = "Scifi",
                        Price = 1000
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}