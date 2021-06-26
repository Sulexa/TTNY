using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Ttny.Domain.Request;

namespace TwitchGames.Ttny.Domain.RequestHandler
{
    public class JoinTownCommandHandler : IRequestHandler<JoinTownCommand>
    {
        public Task<Unit> Handle(JoinTownCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
