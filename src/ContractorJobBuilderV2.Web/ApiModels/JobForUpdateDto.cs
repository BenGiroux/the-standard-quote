using ContractorJobBuilderV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobForUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<JobTaskForCreationDto> JobTasks { get; set; } = new List<JobTaskForCreationDto>();
    }
}
