using Microsoft.EntityFrameworkCore;
using TwitchGames.Users.Dal.Entities.UserEntity;

namespace TwitchGames.Users.Dal.Entities
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }

}
