using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TwitchGames.Users.Dal.Entities.UserEntity;

namespace TwitchGames.Users.Dal.Entities
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\\user.db");
    }
    public class UserContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlite("Data Source=D:\\user.db");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}
