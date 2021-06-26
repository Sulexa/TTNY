using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Ttny.Domain.Request;

namespace TwitchGames.Ttny.Domain.RequestHandler
{
    public class DailyMealCommandHandler : IRequestHandler<DailyMealCommand>
    {
        public Task<Unit> Handle(DailyMealCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
