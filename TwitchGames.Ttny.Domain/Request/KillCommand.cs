using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class KillCommand : IRequest
    {
        public Guid TownId { get; set; }
        public Guid PlayerToKill { get; set; }

        public KillCommand(Guid townId, Guid playerToKill)
        {
            TownId = townId;
            PlayerToKill = playerToKill;
        }
    }
}
