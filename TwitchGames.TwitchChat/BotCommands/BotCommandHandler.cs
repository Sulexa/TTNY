using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus;
using TwitchGames.TwitchChat.BotCommands.Ttny;
using TwitchGames.TwitchChat.Models;

namespace TwitchGames.TwitchChat.BotCommands
{
    public class BotCommandHandler : IBotCommandHandler
    {
        private readonly IRequestClient<AddOrUpdateTwitchUser> _requestClient;
        private readonly Dictionary<string, Action<Guid, BotCommandDto>> _commandDictionnary;

        public BotCommandHandler(IRequestClient<AddOrUpdateTwitchUser> requestClient, ITtnyJoinTownCommandHandler ttnyJoinTownCommandHandler)
        {
            _requestClient = requestClient;

            _commandDictionnary = new Dictionary<string, Action<Guid, BotCommandDto>>()
            {
                { "ttny_join", async (userId, botCommandDto) => {await ttnyJoinTownCommandHandler.Handle(userId, botCommandDto); } }
            };
        }

        public async Task ExecuteCommandAsync(string commandName, BotCommandDto botCommandeDto)
        {
            if (!this._commandDictionnary.ContainsKey(commandName))
            {
                return;
            }

            Guid twitchUserId = await AddOrUpdateTwitchUser(botCommandeDto);

            this._commandDictionnary[commandName](twitchUserId, botCommandeDto);
        }

        private async Task<Guid> AddOrUpdateTwitchUser(BotCommandDto botCommandeDto)
        {
            var response = await _requestClient.GetResponse<AddOrUpdateTwitchUserResult>(
                new AddOrUpdateTwitchUser(
                    botCommandeDto.TwitchId,
                    botCommandeDto.DisplayName,
                    botCommandeDto.ColorHex));

            var twitchUserId = response.Message.UserId;

            return twitchUserId;
        }
    }

}