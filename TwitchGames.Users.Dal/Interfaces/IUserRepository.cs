using System.Threading.Tasks;
using TwitchGames.Shared.BaseRepositoryLibrary;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Entities.UserEntity;

namespace TwitchGames.Users.Dal.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, UserDbContext>
    {
        Task<User> GetUserByTwitchIdAsync(string twitchId);
    }
}