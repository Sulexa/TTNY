using MediatR;
using System;

namespace TwitchGames.Users.Domain.Request
{
    public class AddOrUpdateTwitchUserCommand : IRequest<Guid>
    {
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public AddOrUpdateTwitchUserCommand(string twitchId, string displayName, string colorHex)
        {
            TwitchId = twitchId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
