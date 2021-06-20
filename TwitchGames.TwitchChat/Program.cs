using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TwitchGames.Shared.UnitOfWorkLibrary.Extensions;
using TwitchGames.TwitchChat.Models;
using TwitchGames.TwitchChat.Services;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Interfaces;
using TwitchGames.Users.Dal.Repositories;

namespace TwitchGames.TwitchChat
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();

            //setup our DI
            ServiceProvider serviceProvider = InitServiceProvider(config);

            //configure console logging
            serviceProvider
                .GetRequiredService<ILoggerFactory>();

            var logger = serviceProvider.GetRequiredService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogInformation("Starting application");
            //var twitchConfig = config.GetSection("Twitch").Get<TwitchConfig>();

            //var userDbContextFactory = new UserContextFactory();

            var bot = serviceProvider.GetRequiredService<IBot>();
            bot.Connect();
            //using (var dbContext = userDbContextFactory.CreateDbContext(Array.Empty<string>()))
            //{
            //    var bot = new Bot(config["Twitch:Username"], config["Twitch:AccessToken"], new UserRepository(dbContext), dbContext);
            //    Console.ReadLine();
            //}

            Console.ReadLine();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            return config;
        }

        private static ServiceProvider InitServiceProvider(IConfigurationRoot config)
        {
            var serviceCollection = new ServiceCollection()
                   .AddLogging(builder => builder.AddConsole())
                   .AddUnitOfWorkServices<UserDbContext>()
                   .AddScoped<IUserRepository, UserRepository>()
                   .AddScoped<IBot, Bot>()
                   .AddScoped<ITwitchConfig>((x) =>
                   {
                       var config = GetConfiguration();
                       return config.GetSection("Twitch").Get<TwitchConfig>();
                   })
                   .AddDbContext<UserDbContext>(
                       options => options.UseSqlite(config.GetConnectionString("Sqlite")));

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var userDbContext = serviceProvider.GetRequiredService<UserDbContext>();

            userDbContext.Database.Migrate();
            
            return serviceProvider;
        }


    }
}
