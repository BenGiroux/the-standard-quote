using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContractorJobBuilderV2.Infrastructure.Data.Config
{
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder
                .Property(p => p.Id)
                .HasConversion(c => c.Id, c => new IndustryId(c));

            builder
                .ToTable("Industries")
                .HasKey(i => i.Id);

            builder
                .OwnsOne(j => j.TitleAndDescription, sa =>
                {
                    sa.Property(p => p.Title).HasColumnName("Title");
                    sa.Property(p => p.Description).HasColumnName("Description");
                });
        }
    }
}
