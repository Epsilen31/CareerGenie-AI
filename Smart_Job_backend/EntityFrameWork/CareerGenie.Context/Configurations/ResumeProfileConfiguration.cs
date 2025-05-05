using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class ResumeProfileConfiguration : IEntityTypeConfiguration<ResumeProfile>
    {
        public void Configure(EntityTypeBuilder<ResumeProfile> builder)
        {
            builder.ToTable("ResumeProfiles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Skills).HasMaxLength(500);
            builder.Property(x => x.Experience).HasMaxLength(1000);
            builder.Property(x => x.Education).HasMaxLength(500);
            builder.Property(x => x.ResumeUrl).HasMaxLength(255);
        }
    }
}
