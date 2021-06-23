using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using TwitchGames.Shared.Bus;
using TwitchGames.TwitchChat.BotCommands;
using TwitchGames.TwitchChat.Models;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchGames.TwitchChat.Services
{
    public class Bot: IBot
    {
        private const int MESSAGE_ALLOWED_IN_PERDIOD = 750;
        private const int THROTTLING_PERIOD = 30;

        private readonly TwitchClient _client;
        private readonly ITwitchConfig _twitchConfig;
        private readonly ILogger<Bot> _logger;
        private readonly IBotCommandHandler _botCommandHandler;

        public Bot(ITwitchConfig twitchConfig, ILogger<Bot> logger, IBotCommandHandler botCommandHandler)
        {
            this._twitchConfig = twitchConfig;
            this._logger = logger;
            _botCommandHandler = botCommandHandler;

            var customClient = GetWebSocketClient();
            _client = new TwitchClient(customClient);
        }

        private static WebSocketClient GetWebSocketClient()
        {
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = MESSAGE_ALLOWED_IN_PERDIOD,
                ThrottlingPeriod = TimeSpan.FromSeconds(THROTTLING_PERIOD)
            };
            WebSocketClient customClient = new(clientOptions);
            return customClient;
        }

        public void Connect()
        {
            ConnectionCredentials credentials = new(_twitchConfig.Username, _twitchConfig.AccessToken);
            _client.Initialize(credentials, _twitchConfig.Channel);

            _client.OnLog += Client_OnLog;
            _client.OnJoinedChannel += Client_OnJoinedChannel;
            _client.OnConnected += Client_OnConnected;
            _client.OnChatCommandReceived += Client_OnChatCommandReceived;

            _client.Connect();
        }

        private void Client_OnLog(object? sender, OnLogArgs e)
        {
            _logger.LogInformation($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object? sender, OnConnectedArgs e)
        {
            _logger.LogInformation($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            _logger.LogInformation("TwitchGames up and running!");
            _client.SendMessage(e.Channel, "TwitchGames up and running!");
        }

        private async void Client_OnChatCommandReceived(object? sender, OnChatCommandReceivedArgs e)
        {
            await this._botCommandHandler.ExecuteCommandAsync(e.Command.CommandText, new BotCommandDto(
                            e.Command.ChatMessage.UserId,
                            e.Command.ChatMessage.DisplayName,
                            e.Command.ChatMessage.ColorHex));
        }

    }
}
