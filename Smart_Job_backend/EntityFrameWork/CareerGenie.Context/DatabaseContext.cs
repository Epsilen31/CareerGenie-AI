using CareerGenie.Context.Configurations;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerGenie.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SkillMatchConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new ResumeProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ResumeEmbeddingConfiguration());
            modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new JobEmbeddingConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SkillMatch> SkillMatch { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<ResumeProfile> ResumeProfile { get; set; }
        public DbSet<ResumeEmbedding> ResumeEmbeddings { get; set; }
        public DbSet<JobEmbedding> JobEmbeddings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
