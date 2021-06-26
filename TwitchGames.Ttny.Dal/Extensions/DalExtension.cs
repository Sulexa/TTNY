using Microsoft.Extensions.DependencyInjection;
using TwitchGames.Ttny.Dal.Interfaces;
using TwitchGames.Ttny.Dal.Repositories;

namespace TwitchGames.Ttny.Dal.Extensions
{
    public static class DalExtension
    {
        /// <summary>
        /// Add repositories dependancy injection
        /// </summary>
        /// <param name="services">Startup service collection</param>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITownRepository, TownRepository>();
            services.AddScoped<ITownUserRepository, TownUserRepository>();
            services.AddScoped<ITownEventRepository, TownEventRepository>();
            return services;
        }
    }
}
