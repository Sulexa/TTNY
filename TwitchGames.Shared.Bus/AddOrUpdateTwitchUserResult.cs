using System;

namespace TwitchGames.Shared.Bus
{
    public class AddOrUpdateTwitchUserResult
    {
        public Guid UserId { get; set; }

        public AddOrUpdateTwitchUserResult(Guid userId)
        {
            UserId = userId;
        }
    }
}
