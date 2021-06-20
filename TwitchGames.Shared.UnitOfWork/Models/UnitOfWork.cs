using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TwitchGames.Shared.UnitOfWorkLibrary.Interfaces;

namespace TwitchGames.Shared.UnitOfWorkLibrary.Models
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext: DbContext
    {
        private readonly TDbContext _context;

        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Do a save change on all change done
        /// </summary>
        /// <returns></returns>
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Do a save change on all change done
        /// </summary>
        /// <returns></returns>
        public void Complete()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Detaches all of the DbEntityEntry objects that have been added to the ChangeTracker.
        /// </summary>
        public void DetachAll()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
