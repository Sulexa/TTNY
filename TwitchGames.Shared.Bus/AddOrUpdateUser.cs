using System;

namespace TwitchGames.Shared.Bus
{
    public class AddOrUpdateUser: UserIdentifierBase
    {
        public string DisplayName { get; set; }
        public string ColorHex { get; set; }

        public AddOrUpdateUser(Guid userId, string displayName, string colorHex)
        {
            UserId = userId;
            DisplayName = displayName;
            ColorHex = colorHex;
        }
    }
}
