using Ardalis.GuardClauses;
using ContractorJobBuilderV2.Core.Aggregates;
using ContractorJobBuilderV2.Core.Events;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractorJobBuilderV2.Core.Entities.Aggregates
{
    public class Job : BaseEntity<JobId>, IAggregateRoot
    {
        private readonly List<JobTask> _jobTasks = new List<JobTask>();

        private Job(JobId jobId)
        {
            Id = jobId;
            Events.Add(new JobAddedEvent(this));
        }

        public Job(TitleAndDescription titleAndDescription, int industryId) : this(new JobId())
        {
            TitleAndDescription = titleAndDescription;
            IndustryId = industryId;
        }

        /// <summary>
        /// Used as a workaround for EF core's limitation around owned types and value objects :(
        /// </summary>
        /// <param name="industryType"></param>
        private Job() : this(new JobId())
        {
        }

        public Job UpdateTitleAndDescription(TitleAndDescription titleAndDescription)
        {
            TitleAndDescription = titleAndDescription;

            return this;
        }

        public JobTask AddNewJobTask(TitleAndDescription titleAndDescription)
        {
            JobTask jobTask = new JobTask(this, titleAndDescription);

            int maxOrderValue = _jobTasks.Any() ? _jobTasks.Max(j => j.Order) + 1 : 0;
            jobTask.PlaceTaskInPosition(maxOrderValue);

            _jobTasks.Add(jobTask);

            return jobTask;
        }

        public JobTask UpdateJobTask(JobTaskId jobTaskId, TitleAndDescription titleAndDescription, int order, IEnumerable<JobTaskItem> jobTaskItems)
        {
            JobTask existingJobTask = _jobTasks.SingleOrDefault(jt => jt.Id == jobTaskId);

            Guard.Against.Null(existingJobTask, nameof(existingJobTask));

            int currentOrder = existingJobTask.Order;
            int newTaskOrder = order > _jobTasks.Max(jt => jt.Order) ? _jobTasks.Max(jt => jt.Order) : order;

            existingJobTask
                .UpdateTitleAndDescription(titleAndDescription);

            existingJobTask.ClearAllJobTaskItems();
            if (jobTaskItems.Any())
            {
                foreach (var jobTaskItem in jobTaskItems)
                {
                    existingJobTask.AddNewJobTaskItem(jobTaskItem);
                }
            }

            if (existingJobTask.Order == newTaskOrder)
            {
                return existingJobTask;
            }

            existingJobTask.PlaceTaskInPosition(newTaskOrder);

            // If the new task order is greater than the current order of the job task,
            // everything task below it in order gets decremented
            if (newTaskOrder > currentOrder)
            {
                ReorderJobTasks(
                    _jobTasks.Where(j => j.Order <= newTaskOrder && j.Id != existingJobTask.Id),
                    jt => jt.DecrementOrder(),
                    jt => jt.Order != 0
                );
            }
            else
            {
                ReorderJobTasks(
                    _jobTasks.Where(j => j.Order >= newTaskOrder && j.Id != existingJobTask.Id),
                    jt => jt.IncrementOrder(),
                    jt => jt.Order + 1 < _jobTasks.Count
                );
            }

            return existingJobTask;
        }

        public JobTask InsertNewJobTaskAt(TitleAndDescription titleAndDescription, int position)
        {
            JobTask jobTaskAtPosition = _jobTasks.SingleOrDefault(j => j.Order == position);

            if (jobTaskAtPosition == null)
            {
                return AddNewJobTask(titleAndDescription);
            }

            ReorderJobTasks(
                _jobTasks.Where(j => j.Order >= jobTaskAtPosition.Order),
                jt => jt.IncrementOrder(),
                jt => true
            );

            var jobTask = new JobTask(this, titleAndDescription);
            jobTask.PlaceTaskInPosition(position);
            _jobTasks.Add(jobTask);

            return jobTaskAtPosition;
        }

        private void ReorderJobTasks(IEnumerable<JobTask> jobTasks, Action<JobTask> reorderOperation, Func<JobTask, bool> reorderCondition)
        {
            foreach (var jobTaskToUpdate in jobTasks)
            {
                if(reorderCondition.Invoke(jobTaskToUpdate))
                {
                    reorderOperation?.Invoke(jobTaskToUpdate);
                }
            }
        }

        public void ClearAllJobTasks()
        {
            _jobTasks.Clear();
        }

        public IReadOnlyList<JobTask> JobTasks => _jobTasks;
        public TitleAndDescription TitleAndDescription { get; private set; }
        public int IndustryId { get; private set; }
    }
}
