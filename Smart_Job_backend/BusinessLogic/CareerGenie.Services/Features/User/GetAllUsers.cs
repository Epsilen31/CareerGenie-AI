using CareerGenie.DataAccess.Contracts;
using CareerGenie.Services.DTOs;
using MediatR;

namespace CareerGenie.Services.Features.User
{
    public class GetAllUsers
    {
        public class Query : IRequest<IEnumerable<UserDto>>;

        public class Handler : IRequestHandler<Query, IEnumerable<UserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<UserDto>> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                var users = await _unitOfWork.UserRepository.GetAllUsersAsync(cancellationToken);
                return users.Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email ?? string.Empty,
                    CreatedAt = user.CreatedAt,
                });
            }
        }
    }
}
