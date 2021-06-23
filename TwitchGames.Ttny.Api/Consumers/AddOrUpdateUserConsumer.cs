using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus;

namespace TwitchGames.Ttny.Api.Consumers
{
    public class AddOrUpdateUserConsumer : IConsumer<AddOrUpdateUser>
    {
        private readonly ILogger<AddOrUpdateUserConsumer> _logger;

        public AddOrUpdateUserConsumer(ILogger<AddOrUpdateUserConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<AddOrUpdateUser> context)
        {
            _logger.LogInformation("User reçu {DisplayName}", context.Message.DisplayName);


            return Task.CompletedTask;
        }
    }
}
