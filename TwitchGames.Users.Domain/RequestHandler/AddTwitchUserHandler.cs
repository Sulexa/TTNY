using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TwitchGames.Shared.UnitOfWorkLibrary.Interfaces;
using TwitchGames.Users.Dal.Entities.UserEntity;
using TwitchGames.Users.Dal.Interfaces;
using TwitchGames.Users.Domain.Request;

namespace TwitchGames.Users.Domain.RequestHandler
{
    public class AddTwitchUserHandler : IRequestHandler<AddTwitchUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public AddTwitchUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddTwitchUserCommand request, CancellationToken cancellationToken)
        {
            this._userRepository.Add(new User
            {
                TwitchId = request.TwitchId,
                DisplayName = request.DisplayName,
                ColorHex = request.ColorHex
            });

            await this._unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
