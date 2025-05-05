using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Company).HasMaxLength(100);
            builder.Property(x => x.Location).HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnType("text");
            builder.Property(x => x.SkillsRequired).HasColumnType("json");
        }
    }
}
