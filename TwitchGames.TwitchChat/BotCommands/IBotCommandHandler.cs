using System.Threading.Tasks;
using TwitchGames.TwitchChat.Models;

namespace TwitchGames.TwitchChat.BotCommands
{
    public interface IBotCommandHandler
    {
        Task ExecuteCommandAsync(string commandName, BotCommandDto botCommandeDto);
    }
}