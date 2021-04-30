using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using System;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class JobTaskId : ValueObject, IIdentity<Guid>
    {
        public Guid Id { get; private set; }

        public JobTaskId()
        {
            Id = Guid.NewGuid();
        }

        public JobTaskId(Guid id)
        {
            Id = id;
        }
    }
}
