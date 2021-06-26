using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownEventEntity;

namespace TwitchGames.Ttny.Dal.Interfaces
{
    public interface ITownEventRepository : IBaseRepository<TownEvent, TtnyDbContext>
    {
    }
}
