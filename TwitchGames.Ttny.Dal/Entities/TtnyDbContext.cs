using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\\ttny.db");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TownUserEntityTypeConfiguration().Configure(modelBuilder.Entity<TownUser>());
            //new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
    public class TtnyContextFactory : IDesignTimeDbContextFactory<TtnyDbContext>
    {
        public TtnyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TtnyDbContext>();
            optionsBuilder.UseSqlite("Data Source=D:\\ttny.db");

            return new TtnyDbContext(optionsBuilder.Options);
        }
    }
}
