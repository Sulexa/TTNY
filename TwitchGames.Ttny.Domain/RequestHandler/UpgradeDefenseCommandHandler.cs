using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Ttny.Domain.Request;

namespace TwitchGames.Ttny.Domain.RequestHandler
{
    public class UpgradeDefenseCommandHandler : IRequestHandler<UpgradeDefenseCommand>
    {
        public Task<Unit> Handle(UpgradeDefenseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
