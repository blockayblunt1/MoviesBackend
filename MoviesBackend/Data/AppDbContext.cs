using Microsoft.EntityFrameworkCore;
using MovieBackend.Models;

namespace MovieBackend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.Title);
    }
}
