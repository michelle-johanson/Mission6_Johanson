using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) // Constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}