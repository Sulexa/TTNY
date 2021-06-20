using System;
using TwitchGames.Shared.UnitOfWorkLibrary.Interfaces;
using TwitchGames.TwitchChat.Models;
using TwitchGames.Users.Dal.Entities;
using TwitchGames.Users.Dal.Entities.UserEntity;
using TwitchGames.Users.Dal.Interfaces;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchGames.TwitchChat.Services
{
    public class Bot: IBot
    {
        private readonly TwitchClient _client;
        private readonly ITwitchConfig _twitchConfig;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public Bot(ITwitchConfig twitchConfig, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._twitchConfig = twitchConfig;
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;

            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new(clientOptions);
            _client = new TwitchClient(customClient);

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
            Console.WriteLine($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object? sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("TwitchGames up and running!");
            _client.SendMessage(e.Channel, "TwitchGames up and running!");
        }

        private void Client_OnChatCommandReceived(object? sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText)
            {
                case ("join"):
                    this._userRepository.Add(new User
                    {
                        TwitchId = e.Command.ChatMessage.UserId,
                        DisplayName = e.Command.ChatMessage.DisplayName,
                        ColorHex = e.Command.ChatMessage.ColorHex
                    });
                    this._unitOfWork.Complete();


                    Console.WriteLine($"{e.Command.ChatMessage.DisplayName} joined the game!");
                    break;
                default:
                    break;
            }
            //if (e.ChatMessage.Message.Contains("badword"))
            //    _client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        //private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        //{
        //    Console.WriteLine(e.ChatMessage.Message);
        //    //if (e.ChatMessage.Message.Contains("badword"))
        //    //    _client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        //}

        //private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        //{
        //    if (e.WhisperMessage.Username == "my_friend")
        //        _client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        //}

        //private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        //{
        //    if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
        //        _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
        //    else
        //        _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        //}
    }
}
