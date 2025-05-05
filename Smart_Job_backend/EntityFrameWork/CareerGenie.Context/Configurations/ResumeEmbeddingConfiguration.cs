using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class ResumeEmbeddingConfiguration : IEntityTypeConfiguration<ResumeEmbedding>
    {
        public void Configure(EntityTypeBuilder<ResumeEmbedding> builder)
        {
            builder.ToTable("ResumeEmbeddings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VectorId).IsRequired();

            builder
                .HasOne(x => x.ResumeProfile)
                .WithOne()
                .HasForeignKey<ResumeEmbedding>(x => x.ResumeProfileId);
        }
    }
}
