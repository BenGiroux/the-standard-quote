using Ardalis.Specification;
using ContractorJobBuilderV2.Core.Aggregates;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Core.Specifications
{
    public class GetJobsWithTasksSpecification : Specification<Job>
    {
        public GetJobsWithTasksSpecification(IndustryType industryType)
        {
            Query.Where(q => q.IndustryId == industryType);
            Query.Include(j => j.JobTasks);
        }
    }
}
