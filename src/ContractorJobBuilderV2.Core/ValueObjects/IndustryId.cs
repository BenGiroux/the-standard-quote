using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using System;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class IndustryId : ValueObject, IIdentity<Guid>
    {
        public Guid Id { get; set; }

        public IndustryId()
        {
            Id = Guid.NewGuid();
        }

        public IndustryId(Guid id)
        {
            Id = id;
        }
    }
}
