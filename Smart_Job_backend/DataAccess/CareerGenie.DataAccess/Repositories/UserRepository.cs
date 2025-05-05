using CareerGenie.Context;
using CareerGenie.DataAccess.Contracts;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerGenie.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context
                .Users.Include(u => u.ResumeProfile)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(
            string email,
            CancellationToken cancellationToken
        )
        {
            return await _context
                .Users.Include(u => u.ResumeProfile)
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public Task UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync([userId], cancellationToken);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
