using System.Threading.Tasks;

namespace TwitchGames.Shared.UnitOfWorkLibrary.Interfaces
{
    public interface IUnitOfWork
    {
        void Complete();
        Task CompleteAsync();
        void DetachAll();
    }
}