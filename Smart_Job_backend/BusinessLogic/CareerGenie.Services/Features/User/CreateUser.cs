using CareerGenie.DataAccess.Contracts;
using CareerGenie.Services.DTOs;
using MediatR;

namespace CareerGenie.Services.Features.User
{
    public class CreateUser
    {
        public class Command : IRequest<Unit>
        {
            public UserDto User { get; set; }
            public string Password { get; set; }

            public Command(UserDto user, string password)
            {
                User = user;
                Password = password;
            }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Validate email
                if (string.IsNullOrWhiteSpace(request.User.Email))
                    throw new ArgumentException("Email is required.");

                // Check for existing user
                var userAlreadyExists = await _unitOfWork.UserRepository.EmailExistsAsync(
                    request.User.Email,
                    cancellationToken
                );

                if (userAlreadyExists)
                    throw new InvalidOperationException("A user with this email already exists.");

                // Create new user entity
                var newUser = new Entities.Entities.User
                {
                    Id = Guid.NewGuid(),
                    Email = request.User.Email,
                    Name = request.User.Name,
                    Password = request.Password,
                    CreatedAt = DateTime.UtcNow,
                };

                // Save to database
                await _unitOfWork.UserRepository.CreateUserAsync(newUser, cancellationToken);
                await _unitOfWork.UserRepository.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
