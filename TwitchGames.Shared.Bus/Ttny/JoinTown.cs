using System;

namespace TwitchGames.Shared.Bus.Ttny
{
    public class JoinTown : UserIdentifierBase
    {
        public JoinTown(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
