using Microsoft.EntityFrameworkCore;

namespace Mission06_Porter.Models
{
    public class MovieListContext : DbContext // liaison
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options) // constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryID = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 2, CategoryName = "Drama" },
                new Category { CategoryID = 3, CategoryName = "Television" },
                new Category { CategoryID = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 5, CategoryName = "Comedy" },
                new Category { CategoryID = 6, CategoryName = "Family" },
                new Category { CategoryID = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 8, CategoryName = "VHS" }

                );

            base.OnModelCreating(modelBuilder);
       
            modelBuilder.Entity<Movie>()
                .Property(m => m.Edited)
                .HasConversion<int>(); // Converts bool to INTEGER (0/1)

            modelBuilder.Entity<Movie>()
                .Property(m => m.CopiedToPlex)
                .HasConversion<int>(); // Converts bool to INTEGER (0/1)
    }
}
}
