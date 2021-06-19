using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TwitchGames.TwitchChat.Services;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Repositories;

namespace TwitchGames.TwitchChat
{
    class Program
    {
        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var userDbContextFactory = new UserContextFactory();
            using (var dbContext = userDbContextFactory.CreateDbContext(Array.Empty<string>()))
            {
                var bot = new Bot(config["Twitch:Username"], config["Twitch:AccessToken"], new UserRepository(dbContext), dbContext);
                Console.ReadLine();
            }

        }
    }
}
