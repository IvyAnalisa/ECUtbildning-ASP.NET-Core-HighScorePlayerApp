

using IvyGame.Models.Domain;
using Microsoft.EntityFrameworkCore;
using IvyGame.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IvyGame.Data
{
    public class IvyGameContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HighScore> HighScore { get; set; }
        public DbSet<Game> Game { get; set; }
        public IvyGameContext(DbContextOptions<IvyGameContext> options)

            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var administratorRole = new IdentityRole("Administrator");

            // Säkerställ att tabellen AspNetRoles har rollen "Administrator"
            builder
                .Entity<IdentityRole>()
                .HasData(administratorRole);
        }
        public DbSet<IvyGame.Models.DTO.HighScoreDto>? HighScoreDto { get; set; }
    }
}
