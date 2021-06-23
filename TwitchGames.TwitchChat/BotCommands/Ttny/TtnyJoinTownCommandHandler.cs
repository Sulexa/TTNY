using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TwitchGames.TwitchChat.Models;

namespace TwitchGames.TwitchChat.BotCommands.Ttny
{
    public interface ITtnyJoinTownCommandHandler : ICommandHandler
    {
    }

    public class TtnyJoinTownCommandHandler : ITtnyJoinTownCommandHandler
    {
        private readonly ILogger<TtnyJoinTownCommandHandler> _logger;

        public TtnyJoinTownCommandHandler(ILogger<TtnyJoinTownCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Guid userId, BotCommandDto botCommandDto)
        {
            _logger.LogInformation("Joining town");
        }
    }
}
