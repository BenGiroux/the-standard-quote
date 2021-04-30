using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Web.ApiModels
{
    public class JobTaskItemForUpdateDto
    {
        public string PreviousSummary { get; set; }
        public string Summary { get; set; }
    }
}
