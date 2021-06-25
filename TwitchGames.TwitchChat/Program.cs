using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using TwitchGames.Shared.Bus;
using TwitchGames.TwitchChat.BotCommands;
using TwitchGames.TwitchChat.BotCommands.Ttny;
using TwitchGames.TwitchChat.Models;
using TwitchGames.TwitchChat.Services;

namespace TwitchGames.TwitchChat
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            IServiceProvider serviceProvider;
            using (var scope = host.Services.CreateScope())
            {
                serviceProvider = scope.ServiceProvider;

                var logger = serviceProvider.GetRequiredService<ILoggerFactory>()
                    .CreateLogger<Program>();

                logger.LogInformation("Starting application");

                var bot = serviceProvider.GetRequiredService<IBot>();
                bot.Connect();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(GetConfiguration()).CreateLogger();

            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(GetConfiguration().GetConnectionString("RabbitMq"));
                    });
                        x.AddRequestClient<AddOrUpdateTwitchUser>();
                    })
                    .AddMassTransitHostedService(true);

                    services.AddScoped<IBot, Bot>()
                    .AddScoped<IBotCommandHandler, BotCommandHandler>()
                    .AddScoped<ITtnyJoinTownCommandHandler, TtnyJoinTownCommandHandler>()
                    .AddScoped<ITwitchConfig>((x) =>
                    {
                        var config = GetConfiguration();
                        return config.GetSection("Twitch").Get<TwitchConfig>();
                    });
                    services.AddMediatR(typeof(TtnyJoinTownCommandHandler));
                });
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
    }
}
