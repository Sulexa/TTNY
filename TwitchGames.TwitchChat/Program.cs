using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TwitchGames.TwitchChat.Services;

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

            var bot = new Bot(config["Twitch:Username"], config["Twitch:AccessToken"]);

            Console.ReadLine();
        }
    }
}
