using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownEventEntity;
using TwitchGames.Ttny.Dal.Interfaces;

namespace TwitchGames.Ttny.Dal.Repositories
{
    public class TownEventRepository : BaseRepository<TownEvent, TtnyDbContext>, ITownEventRepository
    {
        public TownEventRepository(TtnyDbContext context) : base(context)
        {
        }
    }
}
