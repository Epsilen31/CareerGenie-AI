using CareerGenie.Entities.Entities;

namespace CareerGenie.DataAccess.Contracts
{
    public interface IResumeProfileRepository
    {
        Task<ResumeProfile?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<ResumeProfile?> FindByIdAsync(
            Guid resumeProfileId,
            CancellationToken cancellationToken
        );
        Task AddResumeProfileAsync(
            ResumeProfile resumeProfile,
            CancellationToken cancellationToken
        );
        Task UpdateResumeProfileAsync(
            ResumeProfile resumeProfile,
            CancellationToken cancellationToken
        );
        Task RemoveResumeProfileByIdAsync(
            Guid resumeProfileId,
            CancellationToken cancellationToken
        );
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
