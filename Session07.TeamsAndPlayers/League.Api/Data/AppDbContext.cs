using League.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace League.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }


    }
}
