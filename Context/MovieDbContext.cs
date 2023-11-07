using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Entities;

namespace MoviesWebApi.Context
{
    public class MovieDbContext: DbContext 
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movies> movies { get; set; }
        public DbSet<Ratings> ratings { get; set; }
        public DbSet<Genres> genres { get; set; }
    }
}
