using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.AppliedOn)
                .HasColumnType("datetime(6)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            builder.HasOne(x => x.User).WithMany(x => x.Applications).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Job).WithMany(x => x.Applications).HasForeignKey(x => x.JobId);
        }
    }
}
