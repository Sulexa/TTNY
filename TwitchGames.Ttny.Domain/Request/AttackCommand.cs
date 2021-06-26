using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class AttackCommand : IRequest
    {
        public Guid TownId { get; set; }
        public AttackCommand(Guid townId)
        {
            TownId = townId;
        }
    }
}
