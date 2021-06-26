using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus.Ttny;

namespace TwitchGames.Ttny.Api.Consumers
{
    public class JoinTownConsumer : IConsumer<JoinTown>
    {
        private readonly ILogger<JoinTownConsumer> _logger;

        public JoinTownConsumer(ILogger<JoinTownConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<JoinTown> context)
        {
            //_logger.LogInformation("User reçu {DisplayName}", context.Message.DisplayName);


            return Task.CompletedTask;
        }
    }
}
