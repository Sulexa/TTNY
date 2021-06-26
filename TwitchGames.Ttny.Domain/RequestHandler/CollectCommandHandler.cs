using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Ttny.Domain.Request;

namespace TwitchGames.Ttny.Domain.RequestHandler
{
    public class CollectCommandHandler : IRequestHandler<CollectCommand>
    {
        public Task<Unit> Handle(CollectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
