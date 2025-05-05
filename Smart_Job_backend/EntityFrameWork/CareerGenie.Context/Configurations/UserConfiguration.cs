using CareerGenie.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerGenie.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(x => x.ResumeProfile)
                .WithOne(x => x.User)
                .HasForeignKey<ResumeProfile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
