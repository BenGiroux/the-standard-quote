using System.Collections.Generic;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<JobTaskForCreationDto> JobTasks { get; set; } = new List<JobTaskForCreationDto>();
    }
}
