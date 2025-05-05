using CareerGenie.Context;
using CareerGenie.DataAccess.Contracts;
using CareerGenie.DataAccess.Repositories;

namespace CareerGenie.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        private IUserRepository? _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        // private IJobRepository? _jobRepository;
        // public IJobRepository JobRepository => _jobRepository ??= new JobRepository(_context);

        // private IJobApplicationRepository? _jobApplicationRepository;
        // public IJobApplicationRepository JobApplicationRepository =>
        //     _jobApplicationRepository ??= new JobApplicationRepository(_context);

        // private IJobEmbeddingRepository? _jobEmbeddingRepository;
        // public IJobEmbeddingRepository JobEmbeddingRepository =>
        //     _jobEmbeddingRepository ??= new JobEmbeddingRepository(_context);

        // private IResumeEmbeddingRepository? _resumeEmbeddingRepository;
        // public IResumeEmbeddingRepository ResumeEmbeddingRepository =>
        //     _resumeEmbeddingRepository ??= new ResumeEmbeddingRepository(_context);

        // private ISkillMatchRepository? _skillMatchRepository;
        // public ISkillMatchRepository SkillMatchRepository =>
        //     _skillMatchRepository ??= new SkillMatchRepository(_context);

        // private IResumeProfileRepository? _resumeProfileRepository;
        // public IResumeProfileRepository ResumeProfileRepository =>
        //     _resumeProfileRepository ??= new ResumeProfileRepository(_context);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        // IDisposable
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
