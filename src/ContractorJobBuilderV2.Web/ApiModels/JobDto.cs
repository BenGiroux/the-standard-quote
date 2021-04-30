using ContractorJobBuilderV2.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<JobTaskDto> JobTasks { get; set; } = new List<JobTaskDto>();
    }
}
