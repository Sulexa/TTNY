using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class JoinTownCommand: IRequest
    {
        public Guid UserId { get; set; }

        public JoinTownCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
