using Ardalis.Specification;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using System;
using System.Linq;

namespace ContractorJobBuilderV2.Core.Specifications
{
    public class GetJobWithTasksSpecification : Specification<Job>
    {
        public GetJobWithTasksSpecification(JobId jobId)
        {
            Query.Where(q => q.Id == jobId);
            Query.Include(j => j.JobTasks);
        }
    }
}
