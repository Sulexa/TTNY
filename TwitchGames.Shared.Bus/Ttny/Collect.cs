using System;

namespace TwitchGames.Shared.Bus.Ttny
{
    public class Collect : UserIdentifierBase
    {
        public Collect(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
