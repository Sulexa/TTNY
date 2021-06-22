using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
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
            //var config = GetConfiguration();

            //setup our DI
            //ServiceProvider serviceProvider = InitServiceProvider(config);

            //configure console logging
            //using (var dbContext = userDbContextFactory.CreateDbContext(Array.Empty<string>()))
            //{
            //    var bot = new Bot(config["Twitch:Username"], config["Twitch:AccessToken"], new UserRepository(dbContext), dbContext);
            //    Console.ReadLine();
            //}



            //var busControl = Bus.Factory.CreateUsingInMemory(configure =>
            //{
            //    configure.ReceiveEndpoint("event-listener", endpoint =>
            //    {
            //        endpoint.Consumer<MessageConsumer>();
            //    });
            //});

            //await busControl.StartAsync();
            //var publishEndpoint = serviceProvider.GetRequiredService<IPublishEndpoint>();
            //await publishEndpoint.Publish(new Message($"The time is {DateTimeOffset.Now}"));
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, services, configuration) => configuration
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    //.WriteTo.Http("http://localhost:5000")
                )
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq();
                    })
                   .AddMassTransitHostedService(true);

                    services.AddScoped<IBot, Bot>()
                    .AddScoped<ITwitchConfig>((x) =>
                    {
                        var config = GetConfiguration();
                        return config.GetSection("Twitch").Get<TwitchConfig>();
                    });
                });

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
