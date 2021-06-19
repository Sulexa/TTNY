using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Entities.UserEntity;
using TwitchGames.Users.Dal.Interfaces;

namespace TwitchGames.Users.Dal.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
    }
}
