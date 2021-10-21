using campeonato.Models;
using Microsoft.EntityFrameworkCore;

namespace campeonato.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}