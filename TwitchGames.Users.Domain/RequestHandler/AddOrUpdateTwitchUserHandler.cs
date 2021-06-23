using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Shared.Bus;
using TwitchGames.Shared.UnitOfWorkLibrary.Interfaces;
using TwitchGames.Users.Dal.Entities.UserEntity;
using TwitchGames.Users.Dal.Interfaces;
using TwitchGames.Users.Domain.Request;

namespace TwitchGames.Users.Domain.RequestHandler
{
    public class AddOrUpdateTwitchUserHandler : IRequestHandler<AddOrUpdateTwitchUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddOrUpdateTwitchUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            this._publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(AddOrUpdateTwitchUserCommand request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByTwitchIdAsync(request.TwitchId);
            if(user == null)
            {
                user = new User
                {
                    TwitchId = request.TwitchId,
                    DisplayName = request.DisplayName,
                    ColorHex = request.ColorHex
                };

                this._userRepository.Add(user);
            }
            else
            {
                user.DisplayName = request.DisplayName;
                user.ColorHex = request.ColorHex;
            }

            await this._unitOfWork.CompleteAsync();

            await this._publishEndpoint.Publish(new AddOrUpdateUser(user.UserId, user.DisplayName, user.ColorHex));

            return user.UserId;
        }
    }
}
