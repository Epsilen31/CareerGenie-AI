namespace CareerGenie.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        // IJobApplicationRepository JobApplicationRepository { get; }
        // IJobEmbeddingRepository JobEmbeddingRepository { get; }
        // IJobRepository JobRepository { get; }
        // IResumeEmbeddingRepository ResumeEmbeddingRepository { get; }
        // ISkillMatchRepository SkillMatchRepository { get; }
        // IResumeProfileRepository ResumeProfileRepository { get; }
    }
}
