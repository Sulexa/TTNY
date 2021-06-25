using Microsoft.EntityFrameworkCore;
using TwitchGames.Ttny.Dal.Entities.TownEntity;
using TwitchGames.Ttny.Dal.Entities.TownEventEntity;
using TwitchGames.Ttny.Dal.Entities.TownUserEntity;
using TwitchGames.Ttny.Dal.Entities.UserEntity;

namespace TwitchGames.Ttny.Dal.Entities
{
    public class TtnyDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Town> Towns => Set<Town>();
        public DbSet<TownEvent> TownEvents => Set<TownEvent>();
        public DbSet<TownUser> TownUsers => Set<TownUser>();

        public TtnyDbContext(DbContextOptions<TtnyDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TownUserEntityTypeConfiguration().Configure(modelBuilder.Entity<TownUser>());
            //new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
