using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database");
        }
    }
}
