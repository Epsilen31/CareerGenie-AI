using CareerGenie.DataAccess.Contracts;
using MediatR;

namespace CareerGenie.Services.Features.User
{
    public class DeleteUser
    {
        public record Command(Guid UserId) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await _unitOfWork.UserRepository.DeleteUserAsync(request.UserId, cancellationToken);
                await _unitOfWork.UserRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
