using System.Threading.Tasks;

namespace TwitchGames.Shared.UnitOfWorkLibrary.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void DetachAll();
    }
}