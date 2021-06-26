using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class UpgradeDefenseCommand : IRequest
    {
        public Guid UserId { get; set; }

        public UpgradeDefenseCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
