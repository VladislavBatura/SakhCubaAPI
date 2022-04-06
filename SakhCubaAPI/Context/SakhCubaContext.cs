using Microsoft.EntityFrameworkCore;
using SakhCubaAPI.Models.DBModels;

namespace SakhCubaAPI.Context
{
    public class SakhCubaContext : DbContext
    {
        public SakhCubaContext(DbContextOptions<SakhCubaContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<News> News { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Decision> Decisions { get; set; }
    }
}
