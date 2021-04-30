using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobTaskForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public ICollection<JobTaskItemForCreationDto> JobTaskItems { get; set; } = new List<JobTaskItemForCreationDto>();
    }
}
