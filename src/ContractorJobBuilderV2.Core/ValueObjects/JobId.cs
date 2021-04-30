using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using System;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class JobId : ValueObject, IIdentity<Guid>
    {
        public Guid Id { get; private set; }

        public JobId()
        {
            Id = Guid.NewGuid();
        }

        public JobId(Guid id)
        {
            Id = id;
        }
    }
}
