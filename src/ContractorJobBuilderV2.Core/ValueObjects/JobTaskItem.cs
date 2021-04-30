using Ardalis.GuardClauses;
using ContractorJobBuilderV2.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Core.ValueObjects
{
    public class JobTaskItem : ValueObject
    {
        public string Summary { get; private set; }

        public JobTaskItem(string summary)
        {
            Guard.Against.NullOrEmpty(summary, nameof(summary));
            Guard.Against.OutOfRange(summary.Length, nameof(summary), 0, 1000);

            Summary = summary;
        }
    }
}
