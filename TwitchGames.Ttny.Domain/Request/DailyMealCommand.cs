using MediatR;
using System;

namespace TwitchGames.Ttny.Domain.Request
{
    public class DailyMealCommand : IRequest
    {
        public Guid TownId { get; set; }
        public DailyMealCommand(Guid townId)
        {
            TownId = townId;
        }
    }
}
