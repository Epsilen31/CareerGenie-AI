using CareerGenie.Context;
using CareerGenie.DataAccess.Contracts;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerGenie.DataAccess.Repositories
{
    public class ResumeProfileRepository : IResumeProfileRepository
    {
        private readonly DatabaseContext _context;

        public ResumeProfileRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResumeProfile?> FindByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken
        )
        {
            return await _context
                .ResumeProfile.AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
        }

        public async Task<ResumeProfile?> FindByIdAsync(
            Guid resumeProfileId,
            CancellationToken cancellationToken
        )
        {
            return await _context
                .ResumeProfile.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == resumeProfileId, cancellationToken);
        }

        public async Task AddResumeProfileAsync(
            ResumeProfile resumeProfile,
            CancellationToken cancellationToken
        )
        {
            await _context.ResumeProfile.AddAsync(resumeProfile, cancellationToken);
        }

        public Task UpdateResumeProfileAsync(
            ResumeProfile resumeProfile,
            CancellationToken cancellationToken
        )
        {
            _context.ResumeProfile.Update(resumeProfile);
            return Task.CompletedTask;
        }

        public async Task RemoveResumeProfileByIdAsync(
            Guid resumeProfileId,
            CancellationToken cancellationToken
        )
        {
            var profile = await _context.ResumeProfile.FindAsync(
                new object[] { resumeProfileId },
                cancellationToken
            );
            if (profile != null)
            {
                _context.ResumeProfile.Remove(profile);
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
