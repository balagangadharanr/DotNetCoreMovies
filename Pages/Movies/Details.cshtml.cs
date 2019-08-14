using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetCoreMovies.Models;

namespace RazorPageDotnetCore.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly DotNetCoreMovies.Models.DotNetCoreMoviesContext _context;

        public DetailsModel(DotNetCoreMovies.Models.DotNetCoreMoviesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
