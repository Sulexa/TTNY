using System;

namespace TwitchGames.Shared.Bus
{
    public abstract class UserIdentifierBase
    {
        public Guid UserId { get; set; }
    }
}
