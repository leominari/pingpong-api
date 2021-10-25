using campeonato.Models;
using Microsoft.EntityFrameworkCore;

namespace campeonato.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentPlayer> TournamentPlayers { get; set; }
        public DbSet<Game> Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TournamentPlayer

            modelBuilder.Entity<TournamentPlayer>()
                .HasKey(bc => new {bc.PlayerId, bc.TournamentId});

            modelBuilder.Entity<TournamentPlayer>()
                .HasOne(bc => bc.Player)
                .WithMany(b => b.Tournaments)
                .HasForeignKey(bc => bc.PlayerId);

            modelBuilder.Entity<TournamentPlayer>()
                .HasOne(bc => bc.Tournament)
                .WithMany(c => c.Players)
                .HasForeignKey(bc => bc.TournamentId);

            #endregion
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}