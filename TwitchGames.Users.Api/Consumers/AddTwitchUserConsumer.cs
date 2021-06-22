using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus;
using TwitchGames.Users.Domain.Request;

namespace TwitchGames.Users.Api.Consumers
{
    public class AddTwitchUserConsumer : IConsumer<AddTwitchUser>
    {
        readonly ILogger<AddTwitchUserConsumer> _logger;
        private readonly IMediator _mediator;

        public AddTwitchUserConsumer(ILogger<AddTwitchUserConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddTwitchUser> context)
        {
            _logger.LogInformation("Received Twitch user: {DisplayName}", context.Message.DisplayName);
            await this._mediator.Send(new AddTwitchUserCommand(context.Message.TwitchId, context.Message.DisplayName, context.Message.ColorHex));
        }
    }
}
