using AutoMapper;
using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Specifications;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using ContractorJobBuilderV2.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Controllers.Api
{
    [Route("api/industries/{industryId:int}/jobs/{jobId:Guid}/jobtask/{jobTaskId:Guid}/jobtaskitem")]
    public class JobTaskItemsController : BaseApiController
    {
        private readonly IRepository<JobId> _repository;
        private readonly IMapper _mapper;

        public JobTaskItemsController(IRepository<JobId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<JobDto>> CreateJobTaskItem(int industryId, Guid jobId, Guid jobTaskId, [FromBody] JobTaskItemForCreationDto request)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var existingJob = await _repository.GetByIdAsync(new GetJobWithTasksSpecification(new JobId(jobId)));

            if (existingJob == null || existingJob.IndustryId != industryType.Value)
            {
                return NotFound();
            }

            var jobTask = existingJob.JobTasks.SingleOrDefault(jt => jt.Id.Id == jobTaskId);

            if (jobTask == null)
            {
                return NotFound();
            }

            jobTask.AddNewJobTaskItem(new JobTaskItem(request.Summary));

            await _repository.UpdateAsync(existingJob);

            return CreatedAtRoute(
                "GetJob",
                new { industryId, jobId },
                _mapper.Map<JobDto>(existingJob)
            );
        }

        [HttpPut]
        public async Task<ActionResult<JobDto>> UpdateJobTaskItem(int industryId, Guid jobId, Guid jobTaskId, [FromBody] JobTaskItemForUpdateDto request)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var existingJob = await _repository.GetByIdAsync(new GetJobWithTasksSpecification(new JobId(jobId)));

            if (existingJob == null || existingJob.IndustryId != industryType.Value)
            {
                return NotFound();
            }

            var jobTask = existingJob.JobTasks.SingleOrDefault(jt => jt.Id.Id == jobTaskId);

            if (jobTask == null)
            {
                return NotFound();
            }

            var previousJobTaskItem = jobTask.JobTaskItems.SingleOrDefault(jti => jti.Summary == request.PreviousSummary);
            jobTask.UpdateJobTaskItem(_mapper.Map<JobTaskItem>(previousJobTaskItem), new JobTaskItem(request.Summary));

            await _repository.UpdateAsync(existingJob);

            return CreatedAtRoute(
                "GetJob",
                new { industryId, jobId },
                _mapper.Map<JobDto>(existingJob)
            );
        }

        [HttpOptions]
        public IActionResult GetJobTaskItemsOptions()
        {
            Response.Headers.Add("Allow", "POST, PUT");
            return Ok();
        }
    }
}
