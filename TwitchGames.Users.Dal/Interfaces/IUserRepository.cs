using System.Threading.Tasks;
using TwitchGames.Users.Dal.Entities.UserEntity;

namespace TwitchGames.Users.Dal.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByTwitchIdAsync(string twitchId);
    }
}