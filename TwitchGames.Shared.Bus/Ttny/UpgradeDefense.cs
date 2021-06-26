using System;

namespace TwitchGames.Shared.Bus.Ttny
{
    public class UpgradeDefense: UserIdentifierBase
    {
        public UpgradeDefense(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
