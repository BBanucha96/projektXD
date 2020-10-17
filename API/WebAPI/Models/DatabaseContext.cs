using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<UsersMatches> UsersMatches { get; set; }
        public DbSet<UsersRanks> UsersRanks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database");
        }
    }
}
