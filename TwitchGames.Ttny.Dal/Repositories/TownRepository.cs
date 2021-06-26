using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownEntity;
using TwitchGames.Ttny.Dal.Interfaces;

namespace TwitchGames.Ttny.Dal.Repositories
{
    public class TownRepository : BaseRepository<Town, TtnyDbContext>, ITownRepository
    {
        public TownRepository(TtnyDbContext context) : base(context)
        {
        }
    }
}
