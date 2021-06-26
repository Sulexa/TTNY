using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.UserEntity;
using TwitchGames.Ttny.Dal.Interfaces;

namespace TwitchGames.Ttny.Dal.Repositories
{
    public class UserRepository : BaseRepository<User, TtnyDbContext>, IUserRepository
    {
        public UserRepository(TtnyDbContext context) : base(context)
        {
        }
    }
}
