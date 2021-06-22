using MediatR;

namespace TwitchGames.Users.Domain.Request
{
    public class AddTwitchUserCommand : IRequest
    {
        public string TwitchId { get; set; }
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public AddTwitchUserCommand(string twitchId, string displayName, string colorHex)
        {
            TwitchId = twitchId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
