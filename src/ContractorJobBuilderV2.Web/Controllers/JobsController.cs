using AutoMapper;
using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Aggregates;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
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
    [Route("api/industries")]
    public class JobsController : BaseApiController
    {
        private readonly IRepository<JobId> _repository;
        private readonly IMapper _mapper;

        public JobsController(IRepository<JobId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{industryId:int}/jobs/{jobId:Guid}", Name = nameof(GetJob))]
        [HttpHead]
        public async Task<ActionResult<JobDto>> GetJob(int industryId, Guid jobId)
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

            return Ok(_mapper.Map<JobDto>(existingJob));
        }

        [HttpGet("{industryId:int}/jobs")]
        [HttpHead]
        public async Task<ActionResult<List<JobDto>>> GetJobs(int industryId)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            List<Job> items = await _repository.ListAsync(new GetJobsWithTasksSpecification(industryType));

            return Ok(items.Select(i => _mapper.Map<JobDto>(i)));
        }

        [HttpPost("{industryId:int}/jobs")]
        public async Task<ActionResult<JobDto>> CreateJob(int industryId, [FromBody] JobForCreationDto request)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var job = industryType.Industry.CreateJobForIndustry(
                request.Title,
                request.Description
            );

            if (request.JobTasks.Any())
            {
                foreach (var jobTask in request.JobTasks)
                {
                    job.AddNewJobTask(
                        new TitleAndDescription(jobTask.Title, jobTask.Description)
                    );
                }
            }

            Job createdJob = await _repository.AddAsync(job);
            var mappedJob = _mapper.Map<JobDto>(createdJob);

            return CreatedAtRoute(
                nameof(GetJob),
                new { industryId = industryId, jobId = createdJob.Id.Id },
                mappedJob
            );
        }

        [HttpPut("{industryId:int}/jobs/{jobId:Guid}")]
        public async Task<ActionResult> UpdateJob(int industryId, Guid jobId, [FromBody] JobForUpdateDto request) {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var existingJob = await _repository.GetByIdAsync(new GetJobWithTasksSpecification(new JobId(jobId)));

            if (existingJob == null || existingJob.IndustryId != industryType.Value)
            {
                return NotFound();
            }

            existingJob.UpdateTitleAndDescription(new TitleAndDescription(request.Title, request.Description));
            
            // PUT is a full update, so we need to clear all job tasks
            existingJob.ClearAllJobTasks();

            if (request.JobTasks.Any())
            {
                foreach (var jobTask in request.JobTasks)
                {
                    existingJob.AddNewJobTask(
                        new TitleAndDescription(jobTask.Title, jobTask.Description)
                    );
                }
            }

            await _repository.UpdateAsync(existingJob);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetJobsOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT");
            return Ok();
        }
    }
}
