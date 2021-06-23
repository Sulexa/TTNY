using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TwitchGames.Ttny.Dal.Entities.TownUserEntity
{
    public class TownUserEntityTypeConfiguration : IEntityTypeConfiguration<TownUser>
    {
        public void Configure(EntityTypeBuilder<TownUser> builder)
        {
            builder
                .HasKey(tu => new { tu.TownId, tu.UserId });
        }
    }
}
