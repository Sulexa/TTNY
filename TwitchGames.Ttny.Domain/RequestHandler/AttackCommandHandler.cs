using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Ttny.Domain.Request;

namespace TwitchGames.Ttny.Domain.RequestHandler
{
    public class AttackCommandHandler : IRequestHandler<AttackCommand>
    {
        public Task<Unit> Handle(AttackCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
