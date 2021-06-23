using System;
using System.Threading.Tasks;
using TwitchGames.TwitchChat.Models;

namespace TwitchGames.TwitchChat.BotCommands
{
    public interface ICommandHandler
    {
        Task Handle(Guid userId, BotCommandDto botCommandDto);
    }
}