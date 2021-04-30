using Ardalis.GuardClauses;
using ContractorJobBuilderV2.Core.Entities;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel;
using System.Collections.Generic;
using System.Linq;

namespace ContractorJobBuilderV2.Core.Aggregates
{
    public class JobTask : BaseEntity<JobTaskId>
    {
        private readonly List<JobTaskItem> _jobTaskItems = new List<JobTaskItem>();

        private JobTask(JobTaskId jobTaskId)
        {
            Id = jobTaskId;
        }

        public JobTask(Job job, TitleAndDescription titleAndDescription) : this(new JobTaskId())
        {
            JobId = job.Id;
            TitleAndDescription = titleAndDescription;
        }

        /// <summary>
        /// Used as a workaround for EF core's limitation around owned types and value objects :(
        /// </summary>
        /// <param name="jobId"></param>
        private JobTask(JobId jobId) : this(new JobTaskId())
        {
            JobId = jobId;
        }

        public JobTask UpdateTitleAndDescription(TitleAndDescription titleAndDescription)
        {
            TitleAndDescription = titleAndDescription;

            return this;
        }

        public void PlaceTaskInPosition(int position)
        {
            Guard.Against.Negative(position, nameof(position));

            Order = position;
        }

        public void IncrementOrder()
        {
            Order++;
        }

        public void DecrementOrder()
        {
            Order--;
        }

        public void ClearAllJobTaskItems()
        {
            _jobTaskItems.Clear();
        }

        public void AddNewJobTaskItem(JobTaskItem jobTaskItem)
        {
            if(!_jobTaskItems.Contains(jobTaskItem))
            {
                _jobTaskItems.Add(jobTaskItem);
            }
        }

        public void UpdateJobTaskItem(JobTaskItem previousJobTaskItem, JobTaskItem updatedJobTaskItem)
        {
            int jobTaskToUpdate = _jobTaskItems.IndexOf(previousJobTaskItem);

            _jobTaskItems[jobTaskToUpdate] = updatedJobTaskItem;
        }

        public List<JobTaskItem> JobTaskItems => _jobTaskItems.ToList();
        public JobId JobId { get; private set; }
        public TitleAndDescription TitleAndDescription { get; private set; }
        public int Order { get; private set; } = 0;
    }
}
