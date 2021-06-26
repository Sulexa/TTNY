using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownEntity;

namespace TwitchGames.Ttny.Dal.Interfaces
{
    public interface ITownRepository : IBaseRepository<Town, TtnyDbContext>
    {
    }
}
