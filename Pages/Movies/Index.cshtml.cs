using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetCoreMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageDotnetCore.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly DotNetCoreMovies.Models.DotNetCoreMoviesContext _context;

        public IndexModel(DotNetCoreMovies.Models.DotNetCoreMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        // public async Task OnGetAsync()
        // {
        //     //Movie = await _context.Movie.ToListAsync();

        //     var movies = from m in _context.Movie
        //                 select m;
        //     if(!string.IsNullOrEmpty(SearchString))
        //     {
        //         movies = movies.Where(m => m.MovieName.Contains(SearchString));
        //     }
            
        //     Movie = await movies.ToListAsync();
        // }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                            select m;
            
            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.MovieName.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(MovieGenre))
            {
                if(MovieGenre != "All")
                {
                    movies = movies.Where(m => m.Genre == MovieGenre);
                }                
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
