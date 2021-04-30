using Ardalis.GuardClauses;
using ContractorJobBuilderV2.SharedKernel;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class TitleAndDescription : ValueObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public TitleAndDescription(string title, string description)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.OutOfRange(title.Length, nameof(title), 0, 255);
            Guard.Against.OutOfRange(description.Length, nameof(description), 0, 500);

            Title = title;
            Description = description;
        }
    }
}
