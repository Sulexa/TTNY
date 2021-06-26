using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class CollectCommand : IRequest
    {
        public Guid UserId { get; set; }

        public CollectCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
