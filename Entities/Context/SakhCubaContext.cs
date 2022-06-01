using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Models.DBModels;

namespace SakhCubaAPI.Context
{
    public class SakhCubaContext : DbContext
    {
        public SakhCubaContext(DbContextOptions<SakhCubaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JWT_Users>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }

        public DbSet<News> News { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Decision> Decisions { get; set; }
        public DbSet<JWT_Users> Users { get; set; }
    }
}
