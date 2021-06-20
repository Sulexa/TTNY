using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TwitchGames.Users.Dal.Entities.UserEntity
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.TwitchId)
                .IsUnique();
        }
    }
}
