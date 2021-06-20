using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TwitchGames.Shared.UnitOfWorkLibrary.Interfaces;
using TwitchGames.Shared.UnitOfWorkLibrary.Models;

namespace TwitchGames.Shared.UnitOfWorkLibrary.Extensions
{
    public static class UnitOfWorkServiceCollectionExtension
    {
        /// <summary>
        /// Add unit of work services
        /// </summary>
        /// <param name="services">Startup service collection</param>
        public static IServiceCollection AddUnitOfWorkServices<TDbContext>(this IServiceCollection services) where TDbContext: DbContext
        {
            services.TryAddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
            return services;
        }
    }
}
