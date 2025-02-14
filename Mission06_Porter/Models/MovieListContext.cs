using Microsoft.EntityFrameworkCore;

namespace Mission06_Porter.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options) 
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
