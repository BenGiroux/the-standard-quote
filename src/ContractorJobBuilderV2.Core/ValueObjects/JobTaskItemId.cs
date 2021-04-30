using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using System;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class JobTaskItemId : ValueObject, IIdentity<Guid>
    {
        public Guid Id { get; private set; }

        public JobTaskItemId()
        {
            Id = Guid.NewGuid();
        }

        public JobTaskItemId(Guid id)
        {
            Id = id;
        }
    }
}
