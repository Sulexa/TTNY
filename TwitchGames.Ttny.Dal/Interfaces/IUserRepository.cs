using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.UserEntity;

namespace TwitchGames.Ttny.Dal.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, TtnyDbContext>
    {
    }
}
