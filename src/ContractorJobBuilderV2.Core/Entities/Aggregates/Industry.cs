using Ardalis.GuardClauses;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;

namespace ContractorJobBuilderV2.Core.Entities.Aggregates
{
    public class Industry : BaseEntity<IndustryId>, IAggregateRoot
    {
        public static readonly Industry Carpentry = new Industry(IndustryType.Carpentry, new TitleAndDescription("Carpentry Jobs", string.Empty));
        public static readonly Industry Plumbing = new Industry(IndustryType.Plumbing, new TitleAndDescription("Plumbing Jobs", string.Empty));
        public static readonly Industry Electrical = new Industry(IndustryType.Electrical, new TitleAndDescription("Electrical Jobs", string.Empty));

        private Industry(IndustryId industryId)
        {
            Id = industryId;
        }

        private Industry(int type, TitleAndDescription titleAndDescription) : this(new IndustryId())
        {
            Type = type;
            TitleAndDescription = titleAndDescription;
        }

        /// <summary>
        /// Used as a workaround for EF core's limitation around owned types and value objects :(
        /// </summary>
        /// <param name="type"></param>
        private Industry(int type) : this(new IndustryId())
        {
            Type = type;
        }

        public int Type { get; private set; }
        public TitleAndDescription TitleAndDescription { get; private set; }

        public Job CreateJobForIndustry(string title, string description = "")
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.OutOfRange(title.Length, nameof(title), 0, 255);

            Job job = new Job(new TitleAndDescription(title, description), IndustryType.FromValue(Type));

            return job;
        }
    }
}
