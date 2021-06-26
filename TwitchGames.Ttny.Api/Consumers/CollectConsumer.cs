using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus.Ttny;

namespace TwitchGames.Ttny.Api.Consumers
{
    public class CollectConsumer : IConsumer<Collect>
    {
        private readonly ILogger<CollectConsumer> _logger;

        public CollectConsumer(ILogger<CollectConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Collect> context)
        {
            //_logger.LogInformation("User reçu {DisplayName}", context.Message.DisplayName);


            return Task.CompletedTask;
        }
    }
}
