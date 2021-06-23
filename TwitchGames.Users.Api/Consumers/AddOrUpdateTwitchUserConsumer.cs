using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus;
using TwitchGames.Users.Domain.Request;

namespace TwitchGames.Users.Api.Consumers
{
    public class AddOrUpdateTwitchUserConsumer : IConsumer<AddOrUpdateTwitchUser>
    {
        readonly ILogger<AddOrUpdateTwitchUserConsumer> _logger;
        private readonly IMediator _mediator;

        public AddOrUpdateTwitchUserConsumer(ILogger<AddOrUpdateTwitchUserConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddOrUpdateTwitchUser> context)
        {
            _logger.LogInformation("Received Twitch user: {DisplayName}", context.Message.DisplayName);
            var userId = await this._mediator.Send(new AddOrUpdateTwitchUserCommand(context.Message.TwitchId, context.Message.DisplayName, context.Message.ColorHex));
            await context.RespondAsync(new AddOrUpdateTwitchUserResult(userId));
        }
    }
}
