using Microsoft.EntityFrameworkCore;
using PlatformService.Entities;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}