using CareerGenie.Entities.Entities;

namespace CareerGenie.DataAccess.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
        Task CreateUserAsync(User user, CancellationToken cancellationToken);
        Task UpdateUserAsync(User user, CancellationToken cancellationToken);
        Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
