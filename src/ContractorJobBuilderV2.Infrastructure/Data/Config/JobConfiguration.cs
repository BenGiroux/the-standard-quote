using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContractorJobBuilderV2.Infrastructure.Data.Config
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .Property(j => j.Id)
                .HasConversion(j => j.Id, c => new JobId(c));

            builder
                .ToTable("Jobs")
                .HasKey(i => i.Id);

            builder
                .OwnsOne(j => j.TitleAndDescription, sa =>
                {
                    sa.Property(p => p.Title).HasColumnName("Title");
                    sa.Property(p => p.Description).HasColumnName("Description");
                });

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder
                .HasMany(k => k.JobTasks)
                .WithOne()
                    .Metadata
                    .PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
