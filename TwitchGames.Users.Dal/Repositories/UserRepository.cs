using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Entities.UserEntity;
using TwitchGames.Users.Dal.Interfaces;

namespace TwitchGames.Users.Dal.Repositories
{
    public class UserRepository : BaseRepository<User, UserDbContext>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByTwitchIdAsync(string twitchId)
        {
            return await this._context.Users.SingleOrDefaultAsync(u => u.TwitchId == twitchId);
        }
    }
}
