using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class JobEmbeddingConfiguration : IEntityTypeConfiguration<JobEmbedding>
    {
        public void Configure(EntityTypeBuilder<JobEmbedding> builder)
        {
            builder.ToTable("JobEmbeddings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VectorId).IsRequired();

            builder.HasOne(x => x.Job).WithOne().HasForeignKey<JobEmbedding>(x => x.JobId);
        }
    }
}
