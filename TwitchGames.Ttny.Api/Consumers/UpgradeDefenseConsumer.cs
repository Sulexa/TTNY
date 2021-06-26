using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus.Ttny;

namespace TwitchGames.Ttny.Api.Consumers
{
    public class UpgradeDefenseConsumer : IConsumer<UpgradeDefense>
    {
        private readonly ILogger<UpgradeDefenseConsumer> _logger;

        public UpgradeDefenseConsumer(ILogger<UpgradeDefenseConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UpgradeDefense> context)
        {
            //_logger.LogInformation("User reçu {DisplayName}", context.Message.DisplayName);


            return Task.CompletedTask;
        }
    }
}
