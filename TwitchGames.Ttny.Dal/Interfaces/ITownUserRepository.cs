using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownUserEntity;

namespace TwitchGames.Ttny.Dal.Interfaces
{
    public interface ITownUserRepository : IBaseRepository<TownUser, TtnyDbContext>
    {
    }
}
