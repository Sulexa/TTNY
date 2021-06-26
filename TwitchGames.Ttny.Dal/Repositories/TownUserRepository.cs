using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Ttny.Dal.Entities;
using TwitchGames.Ttny.Dal.Entities.TownUserEntity;
using TwitchGames.Ttny.Dal.Interfaces;

namespace TwitchGames.Ttny.Dal.Repositories
{
    public class TownUserRepository : BaseRepository<TownUser, TtnyDbContext>, ITownUserRepository
    {
        public TownUserRepository(TtnyDbContext context) : base(context)
        {
        }
    }
}
