using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMovies.Models
{
    public class DotNetCoreMoviesContext : DbContext
    {
        public DotNetCoreMoviesContext(DbContextOptions<DotNetCoreMoviesContext> options)
        :base(options)
        {
            
        }

        public DbSet<DotNetCoreMovies.Models.Movie> Movie { get; set; }
    }
}