using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class SkillMatchConfiguration : IEntityTypeConfiguration<SkillMatch>
    {
        public void Configure(EntityTypeBuilder<SkillMatch> builder)
        {
            builder.ToTable("SkillMatches");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MatchScore).IsRequired();

            builder.HasOne(x => x.ResumeProfile).WithMany().HasForeignKey(x => x.ResumeProfileId);

            builder.HasOne(x => x.Job).WithMany().HasForeignKey(x => x.JobId);
        }
    }
}
