using Microsoft.EntityFrameworkCore;
using PredictScore.Core.Entities;
using PredictScore.Repository.Extensions;

namespace PredictScore.Repository
{
    public class PredictScoreDbContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PredictionSeason> PredictionSeasons { get; set; }
        public DbSet<PredictionSeasonRules> PredictionSeasonRules { get; set; }
        public DbSet<PredictionMatch> PredictionMatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Data Source=(local)\\MSSQLSERVER19;Initial Catalog=PredictScore;Integrated Security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Match>(
                entity =>
                {
                    entity.HasOne(e => e.HomeTeam).WithMany().OnDelete(DeleteBehavior.NoAction);
                    entity.HasOne(e => e.AwayTeam).WithMany().OnDelete(DeleteBehavior.NoAction);
                }
            );

            modelBuilder.Entity<Group>(
                entity =>
                {
                    entity.HasMany(e => e.Players).WithMany(p => p.Groups).UsingEntity<Dictionary<string, object>>(
                        x => x.HasOne<Player>().WithMany().OnDelete(DeleteBehavior.NoAction),
                        x => x.HasOne<Group>().WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
                    entity.HasOne(g => g.Owner);
                }
            );

            modelBuilder
                .Seed<Sport>()
                .Seed<Team>("NflTeams.json");
        }
    }
}