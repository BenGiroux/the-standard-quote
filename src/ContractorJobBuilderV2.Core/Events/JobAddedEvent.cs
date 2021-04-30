using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.SharedKernel;

namespace ContractorJobBuilderV2.Core.Events
{
    public class JobAddedEvent : BaseDomainEvent
    {
        public Job CompletedJob { get; set; }

        public JobAddedEvent(Job completedJob)
        {
            CompletedJob = completedJob;
        }
    }
}