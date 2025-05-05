using CareerGenie.DataAccess.Contracts;
using CareerGenie.Services.DTOs;
using MediatR;

namespace CareerGenie.Services.Features.User
{
    public class GetUserById
    {
        public class Query : IRequest<UserDto>
        {
            public Guid UserId { get; set; }

            public Query(Guid userId)
            {
                UserId = userId;
            }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _unitOfWork.UserRepository.GetUserByIdAsync(
                        request.UserId,
                        cancellationToken
                    );
                    if (user == null)
                    {
                        throw new KeyNotFoundException(
                            $"User with ID {request.UserId} was not found."
                        );
                    }

                    return new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email ?? string.Empty,
                        CreatedAt = user.CreatedAt,
                    };
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        "An error occurred while retrieving the user by ID.",
                        ex
                    );
                }
            }
        }
    }
}
