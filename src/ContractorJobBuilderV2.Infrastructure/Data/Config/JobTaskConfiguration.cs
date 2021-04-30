using ContractorJobBuilderV2.Core.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using ContractorJobBuilderV2.Infrastructure.Extensions;

namespace ContractorJobBuilderV2.Infrastructure.Data.Config
{
    public class JobTaskConfiguration : IEntityTypeConfiguration<JobTask>
    {
        public void Configure(EntityTypeBuilder<JobTask> builder)
        {
            builder
                .Property(p => p.Id)
                .HasConversion(c => c.Id, c => new JobTaskId(c));

            builder
                .Property(p => p.JobId)
                .HasConversion(c => c.Id, c => new JobId(c));

            builder
                .OwnsOne(j => j.TitleAndDescription, sa =>
                {
                    sa.Property(p => p.Title).HasColumnName("Title");
                    sa.Property(p => p.Description).HasColumnName("Description");
                });

            builder
                .Property(j => j.JobTaskItems)
                .HasJsonConversion();

            builder
                .ToTable("JobTasks")
                .HasKey(j => j.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever();
        }
    }
}
