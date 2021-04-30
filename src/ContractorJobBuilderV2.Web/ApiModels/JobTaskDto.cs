using ContractorJobBuilderV2.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public ICollection<JobTaskItem> JobTaskItems { get; set; } = new List<JobTaskItem>();
    }
}
