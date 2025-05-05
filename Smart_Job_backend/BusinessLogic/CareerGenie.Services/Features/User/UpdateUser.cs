using CareerGenie.DataAccess.Contracts;
using CareerGenie.Services.DTOs;
using MediatR;

namespace CareerGenie.Services.Features.User
{
    public class UpdateUser
    {
        public class Command : IRequest<UserDto>
        {
            public UserDto User { get; set; }

            public Command(UserDto user)
            {
                User = user;
            }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetUserByIdAsync(
                    request.User.Id,
                    cancellationToken
                );
                if (user == null)
                    throw new InvalidOperationException("User not found");

                user.Name = request.User.Name;
                user.Email = request.User.Email;

                await _unitOfWork.UserRepository.UpdateUserAsync(user, cancellationToken);
                await _unitOfWork.UserRepository.SaveChangesAsync(cancellationToken);
                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                };
            }
        }
    }
}
